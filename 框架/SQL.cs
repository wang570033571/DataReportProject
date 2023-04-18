using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace 框架
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SQL")]
    public static class SQL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1802:UseLiteralsWhereAppropriate")]
        public static int 超时秒数 = 300;
        public static string 脚本 = "";
        public static string 结果 = "";
        public static string 操作员 = "";
        public static string 部门 = "";
        public static string 操作员ID = "";
        public static string 部门ID = "";
        public static string 部门类型 = "";
        public static string 门店ID = "";
        public static string 门店 = "";
        public static string 门店名称 = "";
        public static string 品牌编码 = "";
        public static string IP = "";
        public static string 机器名 = "";
        public static string 登陆名 = "";
        public static string 服务器 = "127.0.0.1";
        public static string 用户名 = "sa";
        public static string 密码 = "sa";
        public static string 当前工程 = "";
        public static string 当前窗体 = "";
        public static string 工号 = "";
        public static string 职级 = "";
        public static string 公司ID = "";
        public static string 公司 = "";
        public static bool 连接状态 = true;
        public static Dictionary<string, string> 岗位 = new Dictionary<string, string>();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]

        //internal static PasService.PasService pasService = new 框架.PasService.PasService();

        //public enum DB
        //{
        //    系统,流程,OA,统计,财务,邮件, Report_DB
        //}

        public enum DB
        {
            Report_DB, Process_DB, OA, 统计, 财务, 邮件
        }

        public static string 执行(DB 数据库, string 脚本, string 备注)
        {
            if (脚本.Length == 0) throw new Exception("没有可以执行的脚本");
            DateTime 开始时间 = 当前时间();
            string 执行结果 = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (SqlConnection 连接 = new SqlConnection(连接字符串(数据库)))
                {
                    using (SqlCommand 命令 = new SqlCommand(脚本, 连接))
                    {
                        连接.Open();
                        命令.CommandTimeout = 超时秒数;
                        using (SqlTransaction 事务 = 连接.BeginTransaction())
                        {
                            try
                            {
                                命令.Transaction = 事务;
                                命令.ExecuteNonQuery();
                                事务.Commit();
                                执行结果 = "成功";
                                return 执行结果;
                            }
                            catch (System.Data.SqlClient.SqlException e)
                            {
                                事务.Rollback();
                                执行结果 = "失败,原因如下【" + e.Message + "】";
                                return 执行结果;
                            }
                        }
                    }
                }
            }
            finally
            {
                SQL.记录日志(备注, 脚本, 执行结果, 开始时间);
                Cursor.Current = Cursors.Default;
            }
        }

        public static DataSet 查询(DB 数据库, string 脚本, string 备注)
        {
            if (脚本.Length == 0) throw new Exception("没有可以执行的脚本");
            DateTime 开始时间 = 当前时间();
            string 执行结果 = "";

            DataSet ds = new DataSet();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (SqlConnection 连接 = new SqlConnection(连接字符串(数据库)))
                {
                    using (SqlDataAdapter 填充 = new SqlDataAdapter(脚本, 连接))
                    {
                        连接.Open();
                        填充.SelectCommand.CommandTimeout = 超时秒数;
                        填充.Fill(ds, "ds");
                        执行结果 = "成功";
                        return ds;
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                执行结果 = "失败,原因如下【" + e.Message + "】";
                throw new Exception(e.Message);
            }
            finally
            {
                SQL.记录日志(备注, 脚本, 执行结果, 开始时间);
                Cursor.Current = Cursors.Default;
            }
        }

        public static void 查询(DB 数据库, string 脚本, string 备注, DevExpress.XtraGrid.Views.Grid.GridView 数据窗口)
        {
            if (脚本.Length == 0) throw new Exception("没有可以执行的脚本");
            DateTime 开始时间 = 当前时间();
            string 执行结果 = "";

            DataSet ds = new DataSet();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (SqlConnection 连接 = new SqlConnection(连接字符串(数据库)))
                {
                    using (SqlDataAdapter 填充 = new SqlDataAdapter(脚本, 连接))
                    {
                        连接.Open();
                        填充.SelectCommand.CommandTimeout = 超时秒数;
                        填充.Fill(ds, "ds");
                        int i = 数据窗口.FocusedRowHandle;
                        if (ds == null || ds.Tables.Count == 0)
                        {
                            数据窗口.GridControl.DataSource = null;
                        }
                        else
                        {
                            数据窗口.GridControl.DataSource = ds.Tables[0];
                            数据窗口.SelectRow(i);
                            数据窗口.FocusedRowHandle = i;
                        }
                        执行结果 = "成功";
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                执行结果 = "失败,原因如下【" + e.Message + "】";
                throw new Exception(e.Message);
            }
            finally
            {
                SQL.记录日志(备注, 脚本, 执行结果, 开始时间);
                Cursor.Current = Cursors.Default;
            }
        }

        public static string 取值(DB 数据库, string 脚本, string 备注)
        {
            if (脚本.Length == 0) throw new Exception("没有可以执行的脚本");
            DateTime 开始时间 = 当前时间();
            string 返回值 = "";
            string 执行结果 = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (SqlConnection 连接 = new SqlConnection(连接字符串(数据库)))
                {
                    using (SqlCommand 命令 = new SqlCommand(脚本, 连接))
                    {
                        try
                        {
                            连接.Open();
                            命令.CommandTimeout = 超时秒数;
                            返回值 = Convert.ToString(命令.ExecuteScalar());
                            执行结果 = "成功";
                            return 返回值;
                        }
                        catch (System.Data.SqlClient.SqlException e)
                        {
                            执行结果 = "失败,原因如下【" + e.Message + "】";
                            throw new Exception(e.Message);
                        }
                    }
                }
            }
            finally
            {
                SQL.记录日志(备注, 脚本, 执行结果, 开始时间);
                Cursor.Current = Cursors.Default;
            }
        }

        public static string 上传(DB 数据库, string 脚本, string 备注, byte[] 附件)
        {
            if (脚本.Length == 0) throw new Exception("没有可以执行的脚本");
            DateTime 开始时间 = 当前时间();
            if (附件 == null) 附件 = BitConverter.GetBytes(0);
            //脚本中必须要有名称为"@附件"的参数,类型为Image,内容为文件流
            string 执行结果 = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (SqlConnection 连接 = new SqlConnection(连接字符串(数据库)))
                {
                    using (SqlCommand 命令 = new SqlCommand(脚本, 连接))
                    {
                        System.Data.SqlClient.SqlParameter 参数 = new System.Data.SqlClient.SqlParameter("@附件", SqlDbType.Image);
                        参数.Value = 附件;
                        命令.Parameters.Add(参数);
                        连接.Open();
                        命令.CommandTimeout = 超时秒数;
                        using (SqlTransaction 事务 = 连接.BeginTransaction())
                        {
                            try
                            {
                                命令.Transaction = 事务;
                                命令.ExecuteNonQuery();
                                事务.Commit();
                                执行结果 = "成功";
                                return 执行结果;
                            }
                            catch (System.Data.SqlClient.SqlException e)
                            {
                                事务.Rollback();
                                执行结果 = "失败,原因如下【" + e.Message + "】";
                                return 执行结果;
                            }
                        }
                    }
                }
            }
            finally
            {
                SQL.记录日志(备注, 脚本, 执行结果, 开始时间);
                Cursor.Current = Cursors.Default;
            }
        }

        public static string 下载(string 文件名, byte[] 文件流)
        {
            DateTime 开始时间 = 当前时间();
            string 返回值 = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string 路径 = Application.StartupPath + @"\附件\";
                文件操作.文件流转换成文件(路径, 文件名, 文件流);
                返回值 = "成功";
                return 返回值;
            }
            catch (Exception e)
            {
                返回值 = "失败,原因如下【" + e.Message + "】";
                return 返回值;
            }
            finally
            {
                文件操作.记日志(脚本 + ":" + 返回值 + ",执行时间为:" + 执行秒数(开始时间, 当前时间()) + "秒");
                Cursor.Current = Cursors.Default;
            }
        }

        public static string 连接字符串(DB 数据库)
        {
            //"Persist Security Info=False;User ID=ld;pwd=ld;Initial Catalog=ERP4;Data Source=192.76.1.19";
            string 返回值;
            try
            {
                返回值 = "Persist Security Info=False;"
                            + "User ID=" + 用户名 + ";"
                            + "pwd=" + 密码 + ";"
                            + "Initial Catalog=" + 数据库.ToString() + ";"
                            + "Data Source=" + 服务器 + ";"
                            + "Workstation ID=" + 机器名 + ";";


                //返回值 = "Data Source = " + 服务器 + "; Initial Catalog = " + 数据库.ToString() + "; User ID = " + 用户名 + "; PassWord = " + 密码 + ";";
                return 返回值;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string 执行秒数(DateTime 开始时间, DateTime 结束时间)
        {
            TimeSpan 时间差 = 结束时间 - 开始时间;
            return Convert.ToString(时间差.Seconds);
        }

        public static string 根据名称获取ID(DB 数据库, string 名称, string 表)
        {
            string 脚本, 返回值;
            脚本 = "Select top 1 fID from " + 表 + " With (Nolock) Where 名称=" + 引号(名称);
            返回值 = 取值(数据库, 脚本, "根据名称获取ID");
            return 返回值;
        }

        public static string 根据名称获取ID(DB 数据库, string 名称, string 表, string Select字段, string Where字段)
        {
            string 脚本, 返回值;
            脚本 = "Select top 1 " + Select字段 + " from " + 表 + " With (Nolock) Where " + Where字段 + "=" + 引号(名称);
            返回值 = 取值(数据库, 脚本, "根据名称获取ID");
            return 返回值;
        }

        public static string 根据ID获取名称(DB 数据库, string ID, string 表)
        {
            string 脚本, 返回值;
            脚本 = "Select top 1 名称 from " + 表 + " With (Nolock) Where fID=" + 引号(ID);
            返回值 = 取值(数据库, 脚本, "根据ID获取名称");
            return 返回值;
        }

        public static string 根据ID获取名称(DB 数据库, string ID, string 表, string Select字段, string Where字段)
        {
            string 脚本, 返回值;
            脚本 = "Select top 1 " + Select字段 + " from " + 表 + " With (Nolock) Where " + Where字段 + "=" + 引号(ID);
            返回值 = 取值(数据库, 脚本, "获取名称ID");
            return 返回值;
        }

        public static string 引号(string 内容)
        {
            string 返回值;
            返回值 = 内容.Replace("'", "''");
            return "\'" + 返回值 + "\'";
        }

        public static string 引号(string 内容, int 百分号标志)
        {
            //百分号标志:0:前百分号,1:后百分号,2表示双百分号
            string 返回值;
            返回值 = 内容.Replace("'", "''");

            switch (百分号标志)
            {
                case 0: 返回值 = "%" + 返回值; break;
                case 1: 返回值 = 返回值 + "%"; break;
                case 2: 返回值 = "%" + 返回值 + "%"; break;
            }

            return "\'" + 返回值 + "\'";
        }

        public static void 加载下拉框(DB 数据库, ComboBox 下拉框, string 脚本, bool 重载标志)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (重载标志 == true) 下拉框.Items.Clear();
                if (下拉框.Items.Count > 0) return;

                DataSet ds = 查询(数据库, 脚本, "加载下拉框");
                if (ds == null || ds.Tables[0].Rows.Count <= 0) return;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    下拉框.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static void 加载下拉框(DB 数据库, ComboBox 下拉框, string 脚本, string 显示字段)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                下拉框.DataSource = null;
                下拉框.Items.Clear();
                object[] objs;
                if (下拉框.Tag != null)
                {
                    objs = 下拉框.Tag as object[];
                }
                else
                {
                    objs = new object[4];
                    objs[0] = "";
                    objs[1] = 脚本;
                    objs[2] = 显示字段;
                }
                using (DataSet ds = 查询(数据库, 脚本, "加载下拉框"))
                {
                    if (ds != null)
                    {
                        objs[3] = ds.Tables[0];
                        下拉框.Tag = objs;
                        下拉框.DataSource = ds.Tables[0].DefaultView;
                        下拉框.DisplayMember = 显示字段;
                        下拉框.ValueMember = "fID";
                        下拉框.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static void 加载下拉框(DB 数据库, ComboBox 下拉框, string 脚本, string 显示字段, bool 是否重载)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (是否重载)
                {
                    下拉框.DataSource = null;
                }

                if (下拉框.DataSource != null) return;

                using (DataSet ds = 查询(数据库, 脚本, "加载下拉框"))
                {
                    if (ds != null)
                    {
                        下拉框.DisplayMember = 显示字段;
                        下拉框.ValueMember = "fID";
                        下拉框.DataSource = ds.Tables[0];
                        下拉框.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static void 加载下拉复选框(DB 数据库, DevExpress.XtraEditors.CheckedComboBoxEdit 下拉框, string 脚本)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                下拉框.Properties.Items.Clear();

                DataSet ds = 查询(数据库, 脚本, "加载下拉框");
                if (ds == null || ds.Tables[0].Rows.Count <= 0) return;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    下拉框.Properties.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static void 创建树(DB 数据库, TreeView 树, TreeNode 父节点, string 脚本, int 图标索引, bool 重载标志)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //如果需要重载,则把节点清空
                //如果不需要重载,则判断是否存在节点,如果存在,则不添加,防止重复添加
                if (重载标志)
                {
                    if (父节点 == null)
                    {
                        树.Nodes.Clear();
                    }
                    else
                    {
                        父节点.Nodes.Clear();
                    }
                }
                else
                {
                    if (父节点 == null)
                    {
                        if (树.Nodes.Count > 0)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (父节点.Nodes.Count > 0)
                        {
                            return;
                        }
                    }
                }

                DataSet ds = SQL.查询(数据库, 脚本, "文本日志");
                if (ds == null || ds.Tables[0].Rows.Count <= 0) return;

                //所有树的图标都在图标(Form)里面
                图标 image = new 图标();
                树.ImageList = image.il树;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeNode 节点 = new TreeNode();
                    if (父节点 == null)
                    {
                        节点.Text = ds.Tables[0].Rows[i][0].ToString();
                        节点.ImageIndex = 图标索引;
                        节点.SelectedImageIndex = 图标索引 == 0 ? 3 : 图标索引;
                        节点.Tag = ds.Tables[0].Rows[i];
                        树.Nodes.Add(节点);
                    }
                    else
                    {
                        节点.Text = ds.Tables[0].Rows[i][0].ToString();
                        节点.ImageIndex = 图标索引;
                        节点.SelectedImageIndex = 图标索引 == 0 ? 3 : 图标索引;
                        节点.Tag = ds.Tables[0].Rows[i];
                        父节点.Nodes.Add(节点);
                        父节点.Expand();
                    }
                }
            }
            catch (Exception ex)
            {
                消息.显示(ex, ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static void 创建树(DB 数据库, TreeView 树, TreeNode 父节点, string 脚本, int 图标索引, bool 重载标志, string 显示字段)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (父节点 != null && 父节点.Nodes.Count == 1)
                {
                    父节点.Nodes.Clear();
                }

                //如果需要重载,则把节点清空
                //如果不需要重载,则判断是否存在节点,如果存在,则不添加,防止重复添加
                if (重载标志)
                {
                    if (父节点 == null)
                    {
                        树.Nodes.Clear();
                    }
                    else
                    {
                        父节点.Nodes.Clear();
                    }
                }
                else
                {
                    if (父节点 == null)
                    {
                        if (树.Nodes.Count > 0)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (父节点.Nodes.Count > 0)
                        {
                            return;
                        }
                    }
                }

                DataSet ds = SQL.查询(数据库, 脚本, "文本日志");
                if (ds == null || ds.Tables[0].Rows.Count <= 0) return;

                //所有树的图标都在图标(Form)里面
                图标 image = new 图标();
                树.ImageList = image.il树;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TreeNode 节点 = new TreeNode();
                    if (父节点 == null)
                    {
                        节点.Text = dr[显示字段].ToString();
                        节点.Tag = dr;
                        节点.ImageIndex = 图标索引;
                        节点.SelectedImageIndex = 图标索引;
                        树.Nodes.Add(节点);
                        if (图标索引 == 0) 节点.Nodes.Add("正在加载...");
                    }
                    else
                    {
                        节点.Text = dr[显示字段].ToString();
                        节点.Tag = dr;
                        节点.ImageIndex = 图标索引;
                        节点.SelectedImageIndex = 图标索引;
                        父节点.Nodes.Add(节点);
                        父节点.Expand();
                        if (图标索引 == 0) 节点.Nodes.Add("正在加载...");
                    }
                }
            }
            catch (Exception ex)
            {
                消息.显示(ex, ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static void 创建树(DB 数据库, TreeView 树, TreeNode 父节点, DataTable 数据集, string 上级ID, string 显示字段)
        {
            if (父节点 == null) 树.Nodes.Clear(); else 父节点.Nodes.Clear();

            图标 image = new 图标();
            树.ImageList = image.il树;

            foreach (DataRow dr in 数据集.Select("上级ID=" + 引号(上级ID), "排序 ASC"))
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr[显示字段].ToString();
                tn.Tag = dr;

                if (dr.Table.Columns.Contains("是否末级"))
                {
                    if (dr["是否末级"].ToString() == "1")
                    {
                        tn.ImageIndex = 1;
                        tn.SelectedImageIndex = 2;
                    }
                    else
                    {
                        tn.ImageIndex = 0;
                        tn.SelectedImageIndex = 0;
                    }
                }
                else
                {
                    tn.ImageIndex = 0;
                    tn.SelectedImageIndex = 0;
                }

                if (dr.Table.Columns.Contains("类型"))
                {
                    if (dr["类型"].ToString() == "子菜单")
                    {
                        tn.ImageIndex = 2;
                        tn.SelectedImageIndex = 2;
                    }
                }

                if (父节点 == null)
                    树.Nodes.Add(tn);
                else
                    父节点.Nodes.Add(tn);

                创建树(数据库, 树, tn, 数据集, dr["fID"].ToString(), 显示字段);
            }
        }

        public static string 获取IP()
        {
            string 返回值 = "";
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in localIPs)
            {
                //根据AddressFamily判断是否为ipv4,如果是InterNetWork则为ipv6
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) 返回值 = ip.ToString();
            }
            if ("".Equals(返回值)) 返回值 = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            return 返回值;
        }

        public static string 获取机器名()
        {
            return Dns.GetHostName();
        }

        public static string 获取菜单ID(string 界面定位)
        {
            string 返回值 = "";
            返回值 = SQL.取值(DB.Report_DB, "Select fID from 菜单 With (Nolock) Where 类型<>'链接' And 界面定位=" + 引号(界面定位), "文本日志");
            return 返回值;
        }

        public static void 设置控件值(Control 控件, DataRow dr)
        {
            foreach (Control 子控件 in 控件.Controls)
            {
                if (子控件.Controls.Count > 0)
                {
                    设置控件值(子控件, dr);
                }

                if (!(子控件 is Label) && !(子控件 is TextBox) && !(子控件 is ComboBox)
                    && !(子控件 is DateTimePicker) && !(子控件 is CheckBox) && !(子控件 is MaskedTextBox)
                    && !(子控件 is PictureBox) && !(子控件 is RadioButton) && !(子控件 is DevExpress.XtraEditors.CheckedComboBoxEdit)
                    || 子控件.Tag == null) continue;

                if (子控件.Tag.ToString().Length <= 0) continue;

                if (子控件 is Label)
                {
                    Label lbl = (子控件 as Label);
                    if (lbl.Tag.ToString() != "")
                    {
                        lbl.Text = dr[lbl.Tag.ToString()].ToString();
                    }
                }

                if (子控件 is TextBox)
                {
                    TextBox txt = (子控件 as TextBox);
                    if (txt.Tag.ToString() != "")
                    {
                        txt.Text = dr[txt.Tag.ToString()].ToString();
                    }
                }

                if (子控件 is ComboBox)
                {
                    ComboBox cbb = (子控件 as ComboBox);
                    cbb.Text = dr[cbb.Tag.ToString()].ToString();
                }

                if (子控件 is CheckBox)
                {
                    CheckBox cb = (子控件 as CheckBox);
                    if (dr[cb.Tag.ToString()].ToString().Equals("1"))
                    {
                        cb.Checked = true;
                    }
                    else
                    {
                        cb.Checked = false;
                    }
                }

                if (子控件 is DateTimePicker)
                {
                    DateTimePicker dtp = (子控件 as DateTimePicker);
                    if (dtp.Tag.ToString() != "")
                    {
                        dtp.Text = dr[dtp.Tag.ToString()].ToString();
                    }
                }

                if (子控件 is PictureBox)
                {
                    PictureBox pb = (子控件 as PictureBox);
                    pb.Image = 文件操作.文件流转图片((dr[pb.Tag.ToString()] as byte[]));
                    pb.ImageLocation = "";
                }

                if (子控件 is RadioButton)
                {
                    RadioButton rb = (子控件 as RadioButton);
                    if (rb.Tag.ToString() != "")
                    {
                        rb.Checked = Convert.ToBoolean(dr[rb.Tag.ToString()]);
                    }
                }
                if (子控件 is DevExpress.XtraEditors.CheckedComboBoxEdit)
                {
                    DevExpress.XtraEditors.CheckedComboBoxEdit txt = (子控件 as DevExpress.XtraEditors.CheckedComboBoxEdit);
                    if (txt.Tag.ToString() != "")
                    {
                        txt.Text = dr[txt.Tag.ToString()].ToString();
                    }
                }
            }
        }

        public static void 设置控件fID只读(Control 控件)
        {
            foreach (Control 子控件 in 控件.Controls)
            {
                if (子控件.Controls.Count > 0)
                {
                    设置控件fID只读(子控件);
                }

                if (!(子控件 is TextBox) && !(子控件 is ComboBox) && !(子控件 is DateTimePicker) && !(子控件 is CheckBox) && !(子控件 is MaskedTextBox)
                    || 子控件.Tag == null) continue;

                if (子控件.Tag.ToString().Length <= 0) continue;

                if (子控件 is TextBox)
                {
                    TextBox txt = (子控件 as TextBox);
                    if (txt.Tag.ToString() != "")
                    {
                        if (txt.Tag.ToString().Equals("fID"))
                        {
                            txt.ReadOnly = true;
                            return;
                        }
                    }
                }
            }
        }

        public static void 设置控件只读(Control 控件)
        {
            foreach (Control 子控件 in 控件.Controls)
            {
                if (子控件.Controls.Count > 0)
                {
                    设置控件只读(子控件);
                }

                if (!(子控件 is TextBox) && !(子控件 is ComboBox) && !(子控件 is DateTimePicker) &&
                    !(子控件 is CheckBox) && !(子控件 is MaskedTextBox) && !(子控件 is Button) && !(子控件 is RadioButton)
                    || 子控件.Tag == null) continue;

                //if (子控件.Tag.ToString().Length <= 0) continue;

                if (子控件 is TextBox)
                {
                    TextBox txt = (子控件 as TextBox);
                    if (txt.Tag.ToString() != "")
                    {
                        txt.ReadOnly = true;
                        txt.BackColor = System.Drawing.SystemColors.Info;
                    }
                }
                if (子控件 is ComboBox)
                {
                    ComboBox cbb = (子控件 as ComboBox);
                    if (cbb.Tag.ToString() != "")
                    {
                        cbb.Enabled = false;
                    }
                }

                if (子控件 is CheckBox)
                {
                    CheckBox cb = (子控件 as CheckBox);
                    if (cb.Tag.ToString() != "")
                    {
                        cb.Enabled = false;
                    }
                }

                if (子控件 is DateTimePicker)
                {
                    DateTimePicker dtp = (子控件 as DateTimePicker);
                    if (dtp.Tag.ToString() != "")
                    {
                        dtp.Enabled = false;
                    }
                }

                if (子控件 is Button)
                {
                    Button btn = (子控件 as Button);
                    if (btn.Tag.ToString() != "")
                    {
                        btn.Enabled = false;
                    }
                }

                if (子控件 is RadioButton)
                {
                    RadioButton rb = (子控件 as RadioButton);
                    if (rb.Tag.ToString() != "")
                    {
                        rb.Enabled = false;
                    }
                }
            }
        }

        public static void 设置控件值(DB 数据库, Control 控件, string SQL脚本)
        {
            设置控件fID只读(控件);
            DataSet ds = SQL.查询(数据库, SQL脚本, "文本日志");
            if (ds.Tables[0].Rows.Count == 0) return;
            DataRow dr = ds.Tables[0].Rows[0];
            SQL.设置控件值(控件, dr);
        }

        public static string 获取查询脚本(Control 控件)
        {
            string 返回值 = "";
            if (控件.Tag.ToString().Equals(""))
            {
                消息.提示("无法找到需要查询的表,请联系管理员");
                return 返回值;
            }
            返回值 = "Select * from " + 控件.Tag.ToString() + " With (Nolock) Where 1=1";

            foreach (Control c in 控件.Controls)
            {
                if (!(c is TextBox) && !(c is ComboBox) && !(c is DateTimePicker) && !(c is CheckBox) && !(c is MaskedTextBox)
                    || c.Tag == null || c.Text.Trim().Length <= 0) continue;

                if (c.Tag.ToString().Length <= 0) continue;

                if (c.Tag.ToString().ToUpper().IndexOf("BETWEEN") >= 0)
                {
                    返回值 += "\n And " + c.Tag.ToString().Replace("@值", 获取日期范围(c.Text.Trim()));
                }
                else
                {
                    string value = 获取查询值(c); // 不过滤空格等字符

                    if (value.Trim().Length > 0)
                        返回值 += "\n And " + c.Tag.ToString().Replace("@值", value);
                }
            }
            return 返回值;
        }

        public static string 获取查询脚本(Control 控件,string 记录数)
        {
            string 返回值 = "";
            if (控件.Tag.ToString().Equals(""))
            {
                消息.提示("无法找到需要查询的表,请联系管理员");
                return 返回值;
            }

            返回值 = "Select Top " + 记录数 + " * from " + 控件.Tag.ToString() + " With (Nolock) Where 1=1";

            foreach (Control c in 控件.Controls)
            {
                if (!(c is TextBox) && !(c is ComboBox) && !(c is DateTimePicker) && !(c is CheckBox) && !(c is MaskedTextBox)
                    || c.Tag == null || c.Text.Trim().Length <= 0) continue;

                if (c.Tag.ToString().Length <= 0) continue;

                if (c.Tag.ToString().ToUpper().IndexOf("BETWEEN") >= 0)
                {
                    返回值 += "\n And " + c.Tag.ToString().Replace("@值", 获取日期范围(c.Text.Trim()));
                }
                else
                {
                    string value = 获取查询值(c); // 不过滤空格等字符

                    if (value.Trim().Length > 0)
                        返回值 += "\n And " + c.Tag.ToString().Replace("@值", value);
                }
            }
            return 返回值;
        }

        public static void 清空控件(System.Windows.Forms.Control control)
        {
            if (control.Tag != null)
            {
                try
                {
                    switch (control.GetType().Name)
                    {
                        // 文本框
                        case "TextBox":
                            (control as TextBox).Text = null;
                            break;
                        case "MaskedTextBox":
                            (control as MaskedTextBox).Text = null;
                            break;
                        // 下拉框
                        case "ComboBox":
                            (control as ComboBox).Text = "";
                            (control as ComboBox).SelectedItem = null;
                            break;
                        // 日期选择
                        case "DateTimePicker":
                            (control as DateTimePicker).Checked = false;
                            break;
                        // 复选框
                        case "CheckBox":
                            (control as CheckBox).CheckState = CheckState.Indeterminate;
                            break;
                    }
                }
                catch { }
            }

            // 清空子控件
            if (control.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Control c in control.Controls)
                {
                    清空控件(c);
                }
            }
        }

        internal static string 获取查询值(Control c)
        {
            string value = "";
            try
            {
                switch (c.GetType().Name)
                {
                    // 文本框
                    case "TextBox":
                        TextBox txt = (c as TextBox);
                        if (txt.Tag.ToString().ToUpper().IndexOf("LIKE") >= 0)
                        {
                            value = txt.Text;
                        }
                        else
                        {
                            value = 引号(txt.Text);
                        }
                        break;
                    case "MaskedTextBox":
                        value = 引号((c as MaskedTextBox).Text);
                        if (value.Trim().Equals(".")) value = "";
                        break;
                    // 下拉框
                    case "ComboBox":
                        ComboBox cbb = (c as ComboBox);
                        if (cbb.Tag.ToString().ToUpper().IndexOf("LIKE") >= 0)
                        {
                            value = cbb.Text;
                        }
                        else
                        {
                            value = 引号(cbb.Text);
                        }

                        break;
                    // 日期选择
                    case "DateTimePicker":
                        if ((c as DateTimePicker).Checked)
                        {
                            DateTime date = (c as DateTimePicker).Value;
                            if (c.Tag.ToString().ToUpper().IndexOf("<") >= 0)
                                value = date.Year.ToString() + "-" + date.Month + "-" + date.Day + " 23:59:59.999";
                            else
                                value = date.Year.ToString() + "-" + date.Month + "-" + date.Day + " 00:00:00.000";
                        }
                        else value = "";
                        break;
                    // 复选框 -- 注意：Tag值是完全值，@值不需返回用空格代替
                    case "CheckBox":
                        if (((CheckBox)c).CheckState == CheckState.Checked)
                            value = "1";
                        else if (((CheckBox)c).CheckState == CheckState.Unchecked)
                            value = "0";
                        else
                            value = "";
                        break;
                    default:
                        value = c.Text;
                        break;
                }
            }
            catch { }
            return value;
        }

        public static string 获取日期范围(string value)
        {
            if (value.Length <= 0) return "";

            return SQL.取值(DB.Report_DB, "Select dbo.f获取日期范围(Getdate()," + 引号(value) + ")", "不记日志");
        }

        public static DateTime 当前时间()
        {
            DateTime 返回值;
            string 脚本 = "Select Getdate()";
            using (SqlConnection 连接 = new SqlConnection(连接字符串(DB.Report_DB)))
            {
                using (SqlCommand 命令 = new SqlCommand(脚本, 连接))
                {
                    try
                    {
                        连接.Open();
                        命令.CommandTimeout = 超时秒数;
                        返回值 = Convert.ToDateTime(命令.ExecuteScalar());
                        return 返回值;
                    }
                    catch
                    {
                        return DateTime.Now;
                    }
                }
            }
        }

        public static string 当前时间字符串()
        {
            return 当前时间().ToString();
        }

        public static DateTime 获取结束日期(DateTime 日期)
        {
            DateTime 返回值;
            返回值 = 获取短日期(日期).AddDays(0.999999);
            return 返回值;
        }

        public static DateTime 获取短日期(DateTime 日期)
        {
            DateTime 返回值;
            返回值 = new DateTime(日期.Year, 日期.Month, 日期.Day);
            return 返回值;
        }

        public static DateTime 获取当月第一天()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month,1);
        }

        public static DateTime 获取当月最后一天()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
        }

        public static DateTime 获取月第一天(DateTime 日期)
        {
            return new DateTime(日期.Year, 日期.Month, 1);
        }

        public static DateTime 获取月最后一天(DateTime 日期)
        {
            return new DateTime(日期.Year, 日期.Month, 1).AddMonths(1).AddDays(-1);
        }
        
        public static void 记录日志(string 描述, string 脚本, string 结果, DateTime 开始日期)
        {
            try
            {
                if (描述 == "不记日志")
                {
                    return;
                }
                else if (描述 == "文本日志")
                {
                    文件操作.记日志(脚本 + ":" + 结果 + ",执行时间为:" + 执行秒数(开始日期, 当前时间()) + "秒");
                }
                else if (描述 == "")
                {
                    消息.提示("日志描述不能为空");
                }
                else
                {
                    文件操作.记日志(脚本 + ":" + 结果 + ",执行时间为:" + 执行秒数(开始日期, 当前时间()) + "秒");

                    string 文件全名 = Application.StartupPath + "\\" + 当前工程;
                    string 版本号 = 文件操作.获取文件版本号(文件全名);
                    SQL.脚本 = "Exec p日志记录 "
                                + SQL.引号(当前工程) + ","
                                + SQL.引号(版本号) + ","
                                + SQL.引号(机器名) + ","
                                + SQL.引号(IP) + ","
                                + SQL.引号(操作员) + ","
                                + SQL.引号(描述) + ","
                                + SQL.引号(脚本) + ","
                                + SQL.引号(结果) + ","
                                + SQL.引号(开始日期.ToString());
                    SQL.执行(SQL.DB.Report_DB, SQL.脚本, "不记日志");
                }
            }
            catch
            { }
        }

        public static bool 服务器连接()
        {
            try
            {
                SqlConnection 连接 = new SqlConnection(连接字符串(DB.Report_DB));
                连接.Open();
                if (连接.State == ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static string 数据集转字符串(DataTable dt)
        {
            string 返回值 = "";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (返回值 == "")
                    {
                        返回值 = dr[0].ToString();
                    }
                    else
                    {
                        返回值 += "," + dr[0].ToString();
                    }
                }
            }
            return 返回值;
        }

        public static string 获取符号前字符串(string 字符串, string 符号)
        {
            int i = 字符串.IndexOf(符号);
            return 字符串.Substring(0, i);
        }

        public static string 获取符号后字符串(string 字符串, string 符号)
        {
            int i = 字符串.IndexOf(符号) + 1;
            int count = 字符串.Length;
            return 字符串.Substring(i, count - i);
        }

        public static void 设置查询控件(Panel panel1)
        {
            if (panel1.Tag == null) return;
            if (panel1.Tag.ToString() == "") return;
            int x左 = 999, x右 = 0, y上 = 999;
            int 窗体宽度 = panel1.FindForm().ClientRectangle.Left + panel1.FindForm().ClientRectangle.Width;
            int 容器高度 = panel1.Height;
            string 查询类型 = "";

            //获取最后一个控件的坐标
            foreach (Control c in panel1.Controls)
            {
                if (c.Name != "lbl记录数" && c.Name != "txt记录数")
                {
                    if (c.Left < x左) x左 = c.Left;
                    if (c.Left + c.Width > x右) x右 = c.Left + c.Width;
                    if (c.Top < y上) y上 = c.Top;
                }
            }

            //获取查询控件
            string 窗体 = panel1.FindForm().GetType().FullName;
            string 视图 = panel1.Tag.ToString();
            SQL.脚本 = "Select * from v字段 With (Nolock) Where 窗体=" + SQL.引号(窗体) + " And 视图=" + SQL.引号(视图);
            SQL.脚本 += "And 是否查询 = 1 Order By 排序";
            DataSet ds = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "设置查询控件");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ((x右 + 100) > 窗体宽度)
                {
                    x右 = x左 - 8;
                    y上 = y上 + 21 + 8;
                    容器高度 = 容器高度 + 21 + 8;
                    panel1.Height = 容器高度;
                }

                Label lbl = new Label();
                lbl.Text = dr["字段"].ToString();
                lbl.Left = x右 + 8;
                lbl.Top = y上 + 2;
                lbl.AutoSize = true;
                panel1.Controls.Add(lbl);

                x右 = x右 + lbl.Width;

                查询类型 = dr["查询类型"].ToString();
                if (查询类型 == "")
                {
                    TextBox txt = new TextBox();
                    txt.Tag = dr["字段"].ToString() + " = @值";
                    txt.Left = x右 + 8;
                    txt.Top = y上;
                    txt.Width = 100;
                    panel1.Controls.Add(txt);
                    x右 = x右 + txt.Width;
                }
                else if (查询类型.ToUpper().ToString() == "LIKE")
                {
                    TextBox txt = new TextBox();
                    txt.Tag = dr["字段"].ToString() + " Like " + dr["查询脚本"].ToString();
                    txt.Left = x右 + 8;
                    txt.Top = y上;
                    txt.Width = 100;
                    panel1.Controls.Add(txt);
                    x右 = x右 + txt.Width;
                }
                else if (查询类型.ToUpper().ToString() == "BETWEEN")
                {
                    ComboBox cbb = new ComboBox();
                    cbb.Tag = dr["字段"].ToString() + " Between @值";
                    SQL.加载下拉框(SQL.DB.Report_DB, cbb, "Select 名称 from v日期周期 With (Nolock) Order By fID", false);
                    cbb.Left = x右 + 8;
                    cbb.Top = y上;
                    cbb.Width = 100;
                    panel1.Controls.Add(cbb);
                    x右 = x右 + cbb.Width;
                }
                else if (查询类型 == "下拉")
                {
                    ComboBox cbb = new ComboBox();
                    cbb.Tag = dr["字段"].ToString() + " = @值";
                    SQL.DB 数据库 = (SQL.DB)Enum.Parse(typeof(SQL.DB), dr["数据库"].ToString());
                    SQL.加载下拉框(数据库, cbb, dr["查询脚本"].ToString(), true);
                    cbb.Left = x右 + 8;
                    cbb.Top = y上;
                    cbb.Width = 100;
                    panel1.Controls.Add(cbb);
                    x右 = x右 + cbb.Width;
                }
            }
        }
        
        public static void 表格加载下拉框(DB 数据库, DevExpress.XtraGrid.Views.Grid.GridView gv, string 字段, string 脚本)
        {
            表格加载下拉框(数据库, gv, 字段,脚本, true);
        }

        public static void 表格加载下拉框(DB 数据库, DevExpress.XtraGrid.Views.Grid.GridView gv, string 字段, string 脚本,bool 是否编辑)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv.Columns)
            {
                if (col.FieldName == 字段)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemComboBox repCbo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                    DataSet ds = SQL.查询(数据库, 脚本, "[" + 字段 + "]" + "加载下拉框");
                    if (ds == null || ds.Tables[0].Rows.Count <= 0) return;
                    for (int index = 0; index < ds.Tables[0].Rows.Count; index++)
                    {
                        repCbo.Items.Add(ds.Tables[0].Rows[index][0]);
                    }

                    if (!是否编辑) repCbo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                    gv.Columns[col.FieldName].ColumnEdit = repCbo;
                }
            }
        }

        public static void 表格加载下拉复选框(DB 数据库, DevExpress.XtraGrid.Views.Grid.GridView gv, string 字段, string 脚本)
        {
            DevExpress.XtraGrid.Columns.GridColumn gridColumn = gv.Columns[字段];
            if (gridColumn == null) return;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repCbo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            DataSet ds = SQL.查询(数据库, 脚本, "[" + 字段 + "]" + "加载下拉框");
            if (ds == null || ds.Tables[0].Rows.Count <= 0) return;
            for (int index = 0; index < ds.Tables[0].Rows.Count; index++)
            {
                repCbo.Items.Add(ds.Tables[0].Rows[index][0]);
            }
            gridColumn.ColumnEdit = repCbo;
        }

        public static DataRow 选择数据(SQL.DB 数据库, string 表名, string 列名, string 查询字段, string 查询条件, bool 是否加载数据)
        {
            选择数据 frm = new 选择数据(数据库, 表名, 列名, 查询字段, 查询条件, 是否加载数据, false);
            if (frm.ShowDialog() == DialogResult.Yes)
                return frm.drSelect;
            else
                return null;
        }

        public static DataTable 选择数据集(SQL.DB 数据库, string 表名, string 列名, string 查询字段, string 查询条件, bool 是否加载数据)
        {
            选择数据 frm = new 选择数据(数据库, 表名, 列名, 查询字段, 查询条件, 是否加载数据, true);
            if (frm.ShowDialog() == DialogResult.Yes)
                return frm.dtData;
            else
                return null;
        }

        /// <summary>
        /// 判断是否为数字
        /// </summary>
        public static bool 判断是否为数字(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                   !objTwoDotPattern.IsMatch(strNumber) &&
                   !objTwoMinusPattern.IsMatch(strNumber) &&
                   objNumberPattern.IsMatch(strNumber);
        }

        #region 图片缩略处理

        /// <summary>
        /// 对图片进行处理,返回一个Image类别的对象
        /// </summary>
        public static Image 图片缩略Img(string 图片路径, int 新图片宽度, int 新图片高度)
        {
            Image 图片 = Image.FromFile(图片路径); // 加载原图片

            return 图片缩略Img(图片, 新图片宽度, 新图片高度);
        }

        /// <summary>
        /// 对图片进行处理,返回一个Image类别的对象
        /// </summary>
        public static Image 图片缩略Img(Image 图片, int 新图片宽度, int 新图片高度)
        {
            // 对原图片进行缩放
            Image newImg = 图片.GetThumbnailImage(新图片宽度, 新图片高度, new Image.GetThumbnailImageAbort(IsTrue), IntPtr.Zero);

            return newImg;
        }

        /// <summary>
        /// 在Image类别对图片进行缩放的时候,需要一个返回bool类别的委托
        /// </summary>
        private static bool IsTrue()
        {
            return true;
        }

        /// <summary>  
        /// 对图片进行处理,返回一个Bitmap类别的对象
        /// </summary> 
        public static Bitmap 图片缩略Bmp(string 图片路径, int 新图片宽度, int 新图片高度)
        {
            Bitmap oldBmp = new Bitmap(图片路径);
            Bitmap bmp = new Bitmap(新图片宽度, 新图片高度);
            Graphics grap = Graphics.FromImage(bmp);

            // 原图片的开始绘制位置,及宽和高 (控制Rectangle的组成参数,便可实现对图片的剪切)
            Rectangle oldRect = new Rectangle(0, 0, oldBmp.Width, oldBmp.Height);

            // 绘制在新画板中的位置,及宽和高 (在这里是完全填充)  
            Rectangle newRect = new Rectangle(0, 0, 新图片宽度, 新图片高度);

            // 指定新图片的画面质量  
            grap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

            // 把原图片指定位置的图像绘制到新画板中  
            grap.DrawImage(oldBmp, newRect, oldRect, GraphicsUnit.Pixel);

            /*
            * 画图的步骤到此就已经完成了
            * 在绘制完成新图片后,还可以使用 Graphics对象的一些方法,为图片添加自定义的内容
            * grap.DrawString(...);添加文字
            * grap.DrawPie(...);添加扇形
            * grap.DrawLine(...);添加直线
            * */

            // 添加文字  
            Brush bru = Brushes.Red; // 笔刷      
            Font font = new Font(new FontFamily("华文行楷"), 30, FontStyle.Regular, GraphicsUnit.World); // 字体
            PointF pf = new PointF(3, 3); // 坐标  
            grap.DrawString("羊", font, bru, pf); // 填充文字 

            return bmp;
        }

        #endregion

        #region 发送邮件

        public static bool 发送邮件(string 标题, string 邮件内容, string 接收人, string 接收邮箱, string 文件名)
        {
            return 发送邮件(标题,邮件内容,接收人,接收邮箱,文件名,"","","");
        }

        public static bool 发送邮件(string 标题, string 邮件内容, string 接收人, string 文件名, string 单号, string 来源)
        {
            return 发送邮件(标题, 邮件内容, 接收人,"", 文件名, "", 单号, 来源);
        }
        
        public static bool 发送邮件(string 标题, string 邮件内容, string 接收人, string 接收邮箱, string 文件名,string 类型,string 单号,string 来源)
        {
            byte[] 内容;
            string 文件长度 = "0";

            if (文件名.Length > 0)
            {
                FileInfo 文件 = new FileInfo(Application.StartupPath + @"\导出\" + 文件名);
                内容 = 文件操作.文件转换成文件流(文件.FullName);

                文件长度 = Convert.ToString(文件.Length / 1000);
            }
            else { 内容 = null; }

            SQL.脚本 = "Exec p发送邮件 " + SQL.引号(标题) + ","
                                        + SQL.引号(邮件内容) + ","
                                        + SQL.引号(SQL.操作员ID) + ","
                                        + SQL.引号(接收人) + ","
                                        + SQL.引号(接收邮箱) + ","
                                        + SQL.引号(SQL.操作员) + ","
                                        + SQL.引号(文件名) + ","
                                        + "@附件" + ","
                                        + SQL.引号(文件长度) + ","
                                        + SQL.引号(类型) + ","
                                        + SQL.引号(单号) + ","
                                        + SQL.引号(来源);

            SQL.结果 = SQL.上传(SQL.DB.邮件, SQL.脚本, "邮件文件上传", 内容);
            if (SQL.结果 != "成功")
            {
                消息.提示("操作" + SQL.结果);
                return false;
            }

            return true;
        }

        public static bool 发送流程邮件附件(string 流程ID, string 流程内容, string 单号, string 文件名)
        {
            if (文件名.Trim().Length <= 0) return false;

            FileInfo 文件 = new FileInfo(Application.StartupPath + @"\导出\" + 文件名);
            byte[] 内容 = 文件操作.文件转换成文件流(文件.FullName);

            SQL.脚本 = "Exec 流程.dbo.p流程定义实例化_带附件 " + 流程ID + ","
                                        + SQL.引号(单号) + ","
                                        + SQL.引号(流程内容) + ","
                                        + SQL.引号(文件.Name) + ","
                                        + "@附件" + ","
                                        + SQL.引号(Convert.ToString(文件.Length / 1000)) + ","
                                        + SQL.引号(SQL.操作员);

            SQL.结果 = SQL.上传(SQL.DB.Process_DB, SQL.脚本, "邮件文件上传", 内容);
            if (SQL.结果 != "成功")
            {
                消息.提示("操作" + SQL.结果);

                SQL.脚本 = "Exec 流程.dbo.p流程定义实例化_带附件 " + 流程ID + ","
                                            + SQL.引号(单号) + ","
                                            + SQL.引号(流程内容) + ","
                                            + SQL.引号(文件.Name) + ","
                                            + "NULL,"
                                            + "0,"
                                            + SQL.引号(SQL.操作员) + ","
                                            + "0";
                SQL.执行(SQL.DB.Process_DB, SQL.脚本, "邮件文件上传回滚");

                return false;
            }

            return true;
        }
        
        public static bool 发送流程邮件附件(string 流程ID, string 流程内容, string 单号, string 文件名,string 来源)
        {
            if (文件名.Trim().Length <= 0) return false;

            FileInfo 文件 = new FileInfo(Application.StartupPath + @"\导出\" + 文件名);
            byte[] 内容 = 文件操作.文件转换成文件流(文件.FullName);

            SQL.脚本 = "Exec 流程.dbo.p流程定义实例化_附件 " + 流程ID + ","
                                                            + SQL.引号(单号) + ","
                                                            + SQL.引号(流程内容) + ","
                                                            + SQL.引号(文件.Name) + ","
                                                            + "@附件" + ","
                                                            + SQL.引号(Convert.ToString(文件.Length / 1000)) + ","
                                                            + SQL.引号(来源) + ","
                                                            + SQL.引号(SQL.操作员);

            SQL.结果 = SQL.上传(SQL.DB.Process_DB, SQL.脚本, "邮件文件上传", 内容);
            if (SQL.结果 != "成功")
            {
                消息.提示("操作" + SQL.结果);

                SQL.脚本 = "Exec 流程.dbo.p流程定义实例化_带附件 " + 流程ID + ","
                                            + SQL.引号(单号) + ","
                                            + SQL.引号(流程内容) + ","
                                            + SQL.引号(文件.Name) + ","
                                            + "NULL,"
                                            + "0,"
                                            + SQL.引号(SQL.操作员) + ",'',"
                                            + "0";
                SQL.执行(SQL.DB.Process_DB, SQL.脚本, "邮件文件上传回滚");

                return false;
            }

            return true;
        }
        
        public static bool 发送流程邮件附件(string 流程ID, string 流程内容, string 单号, string 图片名称, Dictionary<string, byte[]> 文件名)
        {
            if (图片名称.Trim().Length > 0)
            {
                bool 流程发送 = 发送流程邮件附件(流程ID, 流程内容, 单号, 图片名称);
                if (流程发送 == false) return false;
            }

            foreach (var item in 文件名)
            {
                if (item.Key.ToString().Trim().Length <= 0) continue;

                SQL.脚本 = "Exec 流程.dbo.p流程定义实例化_带附件 " + 流程ID + ","
                                            + SQL.引号(单号) + ","
                                            + SQL.引号(流程内容) + ","
                                            + SQL.引号(item.Key) + ","
                                            + "@附件" + ","
                                            + SQL.引号(Convert.ToString(item.Value.Length)) + ","
                                            + SQL.引号(SQL.操作员);

                SQL.结果 = SQL.上传(SQL.DB.Process_DB, SQL.脚本, "邮件文件上传", item.Value);
                if (SQL.结果 != "成功")
                {
                    消息.提示("操作" + SQL.结果);

                    SQL.脚本 = "Exec 流程.dbo.p流程定义实例化_带附件 " + 流程ID + ","
                                                + SQL.引号(单号) + ","
                                                + SQL.引号(流程内容) + ","
                                                + SQL.引号(item.Key) + ","
                                                + "NULL,"
                                                + "0,"
                                                + SQL.引号(SQL.操作员) + ","
                                                + "0";
                    SQL.执行(SQL.DB.Process_DB, SQL.脚本, "邮件文件上传回滚");

                    return false;
                }
            }

            return true;
        }

        #endregion

        #region 打印数据

        /// <summary>
        /// 打印数据
        /// </summary>
        /// <param name="数据集">打印的数据集</param>
        /// <param name="报表窗体">窗体的命名空间</param>
        public static void 打印(DataSet 数据集, string 报表窗体)
        {
            打印(数据集, 报表窗体, true, 0);
        }

        /// <summary>
        /// 打印数据(默认直接打印，并可以设置打印的张数)
        /// </summary>
        /// <param name="数据集">打印的数据集</param>
        /// <param name="报表窗体">窗体的命名空间</param>
        /// <param name="是否显示预览">是否直接打印：True->预览打印,False->不预览，直接打印</param>
        /// <param name="打印页数">设置为默认直接打印时，打印的张数</param>
        public static void 打印(DataSet 数据集, string 报表窗体, bool 是否显示预览, int 打印页数)
        {
            string 项目名称 = string.Empty;

            if (报表窗体.IndexOf('.') == 0) return;

            if (打印页数 > 100) 打印页数 = 2;

            //获取工程项目的名称
            项目名称 = 报表窗体.Substring(0, 报表窗体.IndexOf('.')).ToString();
            System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(Application.StartupPath + "\\" + 项目名称 + ".dll");
            Type 类型 = ass.GetType("报表.报表接口");
            Object 对象 = ass.CreateInstance("报表.报表接口");

            Object objReport = Activator.CreateInstance(ass.GetType(报表窗体));

            System.Reflection.MethodInfo method = 类型.GetMethod("打印报表");
            method.Invoke(对象, new Object[] { objReport, 数据集, 是否显示预览, 打印页数 });
        }

        /// <summary>
        /// 报表导出
        /// </summary>
        /// <param name="数据集">打印的数据集</param>
        /// <param name="报表窗体">窗体的命名空间</param>
        /// <param name="保存路径和文件名">保存路径和文件名</param>
        public static void 导出报表(DataSet 数据集, string 报表窗体, ExportType 导出类型, string 文件名)
        {
            string 项目名称 = string.Empty;

            if (报表窗体.IndexOf('.') == 0) return;

            //删除历史记录
            if (File.Exists(Application.StartupPath + @"\导出\" + 文件名))
            {
                try
                {
                    File.Delete(Application.StartupPath + @"\导出\" + 文件名);
                    文件操作.记日志("删除文件[" + 文件名 + "]成功");
                } //删除原有文件
                catch (Exception ex)
                {
                    string 文件路径名 = Application.StartupPath + @"\导出\" + 文件名 + ".tmp";
                    文件操作.记日志("删除文件[" + 文件名 + "]失败,更名为[" + 文件名 + "].tmp,失败原因:[" + ex.Message + "]");
                }
            }

            //导出文件
            string 路径 = Application.StartupPath + @"\导出\";
            if (!Directory.Exists(路径)) Directory.CreateDirectory(路径);

            //获取工程项目的名称
            项目名称 = 报表窗体.Substring(0, 报表窗体.IndexOf('.')).ToString();
            System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(Application.StartupPath + "\\" + 项目名称 + ".dll");
            Type 类型 = ass.GetType("报表.报表接口");
            Object 对象 = ass.CreateInstance("报表.报表接口");

            Object objReport = Activator.CreateInstance(ass.GetType(报表窗体));

            System.Reflection.MethodInfo method = 类型.GetMethod("导出报表");
            method.Invoke(对象, new Object[] { objReport, 数据集, 导出类型.ToString(), 路径 + 文件名 });
        }

        /// <summary>
        /// 报表导出类型
        /// </summary>
        public enum ExportType
        {
            CSV,
            HTML,
            IMAGE,
            PDF,
            RTF,
            TEXT,
            XLSX,
            XLS
        }

        #endregion

        #region 上传下载文件
        ///<summary>
        ///分块上传文件.
        //</summary>
        //<param name="LocalFileName">本地的文件名</param>
        //<param name="BlockSize">每次传输的文件块大小</param>
        //<param name="OverlayLocal">如果文件存在了,是否覆盖</param>
        //<param name="relativePath">指定文件在服务器存放文件夹</param>
        public static bool UpdateFileByBlock(string LocalFileName, int BlockSize, bool OverlayServer, string relativePath, ProgressBar progressBar)
        {
            if (!System.IO.File.Exists(LocalFileName)) return false;

            byte[] FileByte;
            int RValue=0;
            long FileLenth;
            int LoopMax = 1;
            bool Succeed = true;
            int Offset;     //偏移量
            int SpareLenth; //剩余长度.
            string ServerFileName;

            int Con_BlockSize = 1024 * 1024;

            try
            {
                if (progressBar != null)
                {
                    progressBar.Value = 0;
                    progressBar.Minimum = 0;
                    progressBar.Visible = true;
                }

                if (BlockSize <= 1024) BlockSize = Con_BlockSize;

                System.IO.FileStream fs = new System.IO.FileStream(LocalFileName, System.IO.FileMode.Open);

                ServerFileName = new System.IO.FileInfo(LocalFileName).Name;

                FileLenth = new System.IO.FileInfo(LocalFileName).Length;

                LoopMax = Convert.ToInt32(FileLenth / BlockSize + (FileLenth % BlockSize > 0 ? 1 : 0));

                if (progressBar != null) progressBar.Maximum = LoopMax;

                for (int BlockID = 0; BlockID < LoopMax; BlockID++)
                {
                    Offset = BlockID * BlockSize;
                    SpareLenth = Convert.ToInt32(FileLenth - BlockID * BlockSize); //剩余字节数.

                    if (SpareLenth <= BlockSize)
                    {
                        FileByte = new byte[SpareLenth];

                        fs.Seek(Offset, System.IO.SeekOrigin.Begin);

                        fs.Read(FileByte, 0, SpareLenth);
                        //RValue = pasService.UpdateFileByBlock(ServerFileName, OverlayServer, BlockID, FileByte, relativePath);

                        if (RValue != 0) Succeed = false;

                        if (progressBar != null) progressBar.Value++;
                    }
                    else
                    {
                        FileByte = new byte[BlockSize];
                        fs.Seek(Offset, System.IO.SeekOrigin.Begin);

                        fs.Read(FileByte, 0, BlockSize);

                        //RValue = pasService.UpdateFileByBlock(ServerFileName, OverlayServer, BlockID, FileByte, relativePath);

                        if (RValue != 0) Succeed = false;
                        if (progressBar != null) progressBar.Value++;
                    }

                    System.Windows.Forms.Application.DoEvents();

                    if (!Succeed)
                    {
                        fs.Close();
                        //如果上传失败.删除上传的文件.
                        //pasService.DeleteFile(ServerFileName, relativePath);
                        return false; ;
                    }
                }
            }
            catch (Exception ex) { return false; }
            finally { if (progressBar != null) progressBar.Visible = false; }

            return true;
        }

        ///<summary>
        ///分块从WEB服务器下载文件.
        //</summary>
        //<param name="LocalFileName">保存到本地的文件名</param>
        //<param name="ServerFileName">要下载的服务器端文件名</param>
        //<param name="BlockSize">每次传输的文件块大小</param>
        //<param name="OverlayLocal">如果文件本地存在了,是否覆盖</param>
        //<param name="relativePath">指定文件在服务器存放文件夹</param>
        public static bool LoadFileByBlock(string LocalFileName, string ServerFileName, int BlockSize, bool OverlayLocal, string relativePath, ProgressBar progressBar)
        {
            try
            {
                int MaxBlock=0;
                int BlockID = 0;
                byte[] FileByte=null;
                int Con_BlockSize = 1024 * 1024;

                if (LocalFileName.Trim().Length <= 0) return false;

                LocalFileName = LocalFileName + @"\" + ServerFileName;

                if (System.IO.File.Exists(LocalFileName) && !OverlayLocal) return false;

                if (progressBar != null)
                {
                    progressBar.Visible = true;
                    progressBar.Value = 0;
                    progressBar.Minimum = 0;
                }

                if (BlockSize <= 1024) BlockSize = Con_BlockSize;

                //MaxBlock = pasService.LoadFileSplit(ServerFileName, BlockSize, relativePath);

                if (progressBar != null) progressBar.Maximum = MaxBlock;
                if (MaxBlock > 0)
                {
                    if (System.IO.File.Exists(LocalFileName) && OverlayLocal)
                    {
                        try { System.IO.File.Delete(LocalFileName); }
                        catch (Exception ex)
                        {
                            LocalFileName = LocalFileName + ".tmp";
                        }
                    }

                    System.IO.FileStream fs = new System.IO.FileStream(LocalFileName, System.IO.FileMode.CreateNew);

                    for (BlockID = 0; BlockID < MaxBlock; BlockID++)
                    {
                        //FileByte = pasService.LoadFileByBlock(BlockID, BlockSize, ServerFileName, relativePath);

                        if (FileByte == null || FileByte.Length == 0)
                        {
                            fs.Close();
                            try { System.IO.File.Delete(LocalFileName); }//如果失败,删除本地文件.
                            catch (Exception ex) { }

                            return false;
                        }

                        if (progressBar != null) progressBar.Value++;

                        fs.Write(FileByte, 0, FileByte.Length);
                        System.Windows.Forms.Application.DoEvents();
                    }

                    fs.Close();
                    fs = null;
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
            finally { if (progressBar != null) progressBar.Visible = false; }
        }

        /// <summary>
        /// 删除WEB服务器上面的文件
        /// </summary>
        /// <param name="serverFileName">要删除的文件名称</param>
        /// <param name="relativePath">要删除文件在服务器上面的路径</param>
        /// <returns></returns>
        //public static bool DeleteFile(string serverFileName, string relativePath)
        //{
        //    try
        //    {
        //        return pasService.DeleteFile(serverFileName, relativePath);
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        #endregion

        public static bool isNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 用于其他SQL数据库连接
        public static string 执行(string 连接字符串, string 脚本, string 备注)
        {
            if (脚本.Length == 0) throw new Exception("没有可以执行的脚本");
            DateTime 开始时间 = 当前时间();
            string 执行结果 = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (SqlConnection 连接 = new SqlConnection(连接字符串))
                {
                    using (SqlCommand 命令 = new SqlCommand(脚本, 连接))
                    {
                        连接.Open();
                        命令.CommandTimeout = 超时秒数;
                        using (SqlTransaction 事务 = 连接.BeginTransaction())
                        {
                            try
                            {
                                命令.Transaction = 事务;
                                命令.ExecuteNonQuery();
                                事务.Commit();
                                执行结果 = "成功";
                                return 执行结果;
                            }
                            catch (System.Data.SqlClient.SqlException e)
                            {
                                事务.Rollback();
                                执行结果 = "失败,原因如下【" + e.Message + "】";
                                return 执行结果;
                            }
                        }
                    }
                }
            }
            finally
            {
                SQL.记录日志(备注, 脚本, 执行结果, 开始时间);
                Cursor.Current = Cursors.Default;
            }
        }

        public static DataSet 查询(string 连接字符串, string 脚本, string 备注)
        {
            if (脚本.Length == 0) throw new Exception("没有可以执行的脚本");
            DateTime 开始时间 = 当前时间();
            string 执行结果 = "";

            DataSet ds = new DataSet();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (SqlConnection 连接 = new SqlConnection(连接字符串))
                {
                    using (SqlDataAdapter 填充 = new SqlDataAdapter(脚本, 连接))
                    {
                        连接.Open();
                        填充.SelectCommand.CommandTimeout = 超时秒数;
                        填充.Fill(ds, "ds");
                        执行结果 = "成功";
                        return ds;
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                执行结果 = "失败,原因如下【" + e.Message + "】";
                throw new Exception(e.Message);
            }
            finally
            {
                SQL.记录日志(备注, 脚本, 执行结果, 开始时间);
                Cursor.Current = Cursors.Default;
            }
        }

        public static void 查询(string 连接字符串, string 脚本, string 备注, DevExpress.XtraGrid.Views.Grid.GridView 数据窗口)
        {
            if (脚本.Length == 0) throw new Exception("没有可以执行的脚本");
            DateTime 开始时间 = 当前时间();
            string 执行结果 = "";

            DataSet ds = new DataSet();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (SqlConnection 连接 = new SqlConnection(连接字符串))
                {
                    using (SqlDataAdapter 填充 = new SqlDataAdapter(脚本, 连接))
                    {
                        连接.Open();
                        填充.SelectCommand.CommandTimeout = 超时秒数;
                        填充.Fill(ds, "ds");
                        int i = 数据窗口.FocusedRowHandle;
                        if (ds == null || ds.Tables.Count == 0)
                        {
                            数据窗口.GridControl.DataSource = null;
                        }
                        else
                        {
                            数据窗口.GridControl.DataSource = ds.Tables[0];
                            数据窗口.SelectRow(i);
                            数据窗口.FocusedRowHandle = i;
                        }
                        执行结果 = "成功";
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                执行结果 = "失败,原因如下【" + e.Message + "】";
                throw new Exception(e.Message);
            }
            finally
            {
                SQL.记录日志(备注, 脚本, 执行结果, 开始时间);
                Cursor.Current = Cursors.Default;
            }
        }

        public static string 取值(string 连接字符串, string 脚本, string 备注)
        {
            if (脚本.Length == 0) throw new Exception("没有可以执行的脚本");
            DateTime 开始时间 = 当前时间();
            string 返回值 = "";
            string 执行结果 = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (SqlConnection 连接 = new SqlConnection(连接字符串))
                {
                    using (SqlCommand 命令 = new SqlCommand(脚本, 连接))
                    {
                        try
                        {
                            连接.Open();
                            命令.CommandTimeout = 超时秒数;
                            返回值 = Convert.ToString(命令.ExecuteScalar());
                            执行结果 = "成功";
                            return 返回值;
                        }
                        catch (System.Data.SqlClient.SqlException e)
                        {
                            执行结果 = "失败,原因如下【" + e.Message + "】";
                            throw new Exception(e.Message);
                        }
                    }
                }
            }
            finally
            {
                SQL.记录日志(备注, 脚本, 执行结果, 开始时间);
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion


        public static bool 发起审批流程(string 流程ID, string 流程内容, string 单号)
        {

            SQL.脚本 = "Exec 流程.dbo.p流程定义实例化 " + 流程ID + ","
                                        + SQL.引号(单号) + ","
                                        + SQL.引号(流程内容) + ","
                                        + SQL.引号(SQL.操作员) + ","
                                        + SQL.引号("1");

            SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程发起");
            if (SQL.结果 != "成功")
            {
                消息.提示("操作" + SQL.结果);

                SQL.脚本 = "Exec 流程.dbo.p流程定义实例化 " + 流程ID + ","
                                        + SQL.引号(单号) + ","
                                        + SQL.引号(流程内容) + ","
                                        + SQL.引号(SQL.操作员) + ","
                                        + SQL.引号("0");
                SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程回滚");

                return false;
            }

            return true;
        }

        #region 注释代码
        //public static void 加载更多查询条件(Control 父容器, DataTable 查询字段)
        //{
        //    if (查询字段 == null) return;

        //    if (父容器.Controls == null || 父容器.Controls.Count <= 0)
        //    {
        //        int index = 1;
        //        foreach (DataRow dr in 查询字段.Rows)
        //        {
        //            if (dr["关联SQL"].ToString().Trim().Length > 0 || dr["字段类型"].ToString().ToUpper().Equals("DATETIME"))
        //            {
        //                添加标签(父容器, index, dr["字段名"].ToString());
        //                添加下拉框(父容器, index, dr);
        //            }
        //            else if (dr["字段类型"].ToString().ToUpper().Equals("BIT"))
        //            {
        //                添加复选框(父容器, index, dr["字段名"].ToString(), dr["字段名"].ToString());
        //            }
        //            else
        //            {
        //                添加标签(父容器, index, dr["字段名"].ToString());
        //                添加文本框(父容器, index, dr["字段名"].ToString(), dr["字段类型"].ToString().ToUpper(), dr["查询方式"].ToString());
        //            }
        //            index += 1;
        //        }
        //    }
        //}

        //private static void 添加标签(Control 父容器, int index, string caption)
        //{
        //    Label 标签 = new Label();
        //    标签.Text = caption;
        //    标签.Left = index % 4 == 1 ? 20 : index % 4 == 2 ? 270 : index % 4 == 3 ? 520 : 770;
        //    标签.Width = 80;
        //    标签.Top = (index % 4 == 0 ? (int)(index / 4) - 1 : (int)(index / 4)) * 24 + 4;
        //    父容器.Controls.Add(标签);
        //}

        //private static void 添加复选框(Control 父容器, int index, string caption, string fieldName)
        //{
        //    CheckBox 复选框 = new CheckBox();
        //    复选框.Text = caption;
        //    复选框.Top = (index % 4 == 0 ? (int)(index / 4) - 1 : (int)(index / 4)) * 24;
        //    复选框.Left = index % 4 == 1 ? 100 : index % 4 == 2 ? 350 : index % 4 == 3 ? 600 : 850;
        //    复选框.TabIndex = index + 2;
        //    复选框.CheckState = CheckState.Indeterminate;
        //    复选框.Tag = fieldName + "=%val%";
        //    父容器.Controls.Add(复选框);
        //}

        //private static void 添加文本框(Control 父容器, int index, string fieldName, string columnType, string type)
        //{
        //    TextBox 文本框 = new TextBox();
        //    文本框.Width = 150;
        //    文本框.Top = (index % 4 == 0 ? (int)(index / 4) - 1 : (int)(index / 4)) * 24;
        //    文本框.Left = index % 4 == 1 ? 100 : index % 4 == 2 ? 350 : index % 4 == 3 ? 600 : 850;
        //    文本框.TabIndex = index + 2;
        //    文本框.Tag = fieldName + 获取查询方式(type, columnType);
        //    if (columnType.Equals("INT") || columnType.Equals("DECIMAL") || columnType.Equals("DOUBLE"))
        //        文本框.AccessibleName = "1";
        //    else
        //        文本框.AccessibleName = "";
        //    文本框.KeyPress += new KeyPressEventHandler(文本框_KeyPress);
        //    父容器.Controls.Add(文本框);
        //}

        //private static void 文本框_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    TextBox txt = sender as TextBox;
        //    if (txt.AccessibleName.Trim().Equals("1"))
        //    {
        //        if (e.KeyChar.ToString().Equals("\b")) return;

        //        if (e.KeyChar.ToString().Equals("."))
        //        {
        //            if (txt.Text.Trim().Contains(".")) e.Handled = true;
        //        }
        //        else if (!IsNumber(e.KeyChar.ToString()))
        //            e.Handled = true;
        //    }
        //}

        //private static void 添加下拉框(Control 父容器, int index, DataRow dr)
        //{
        //    ComboBox 下拉框 = new ComboBox();
        //    下拉框.Width = 150;
        //    下拉框.Top = (index % 4 == 0 ? (int)(index / 4) - 1 : (int)(index / 4)) * 24;
        //    下拉框.Left = index % 4 == 1 ? 100 : index % 4 == 2 ? 350 : index % 4 == 3 ? 600 : 850;
        //    下拉框.TabIndex = index + 2;
        //    if (dr["字段类型"].ToString().ToUpper().Equals("DATETIME"))
        //    {
        //        下拉框.Tag = dr["字段名"].ToString().ToLower() + " BETWEEN";
        //        下拉框.DropDown += new EventHandler(下拉框_DropDown);
        //    }
        //    else
        //    {
        //        下拉框.Tag = dr["字段名"].ToString().ToLower() + "='%val%'";

        //        Dictionary<string, string> 下拉框数据 = new Dictionary<string, string>();
        //        下拉框数据.Add(下拉框.Tag.ToString().ToLower(), dr["关联SQL"].ToString().Replace("‘", "'"));

        //        设置下拉框绑定(下拉框, 下拉框数据);
        //    }

        //    父容器.Controls.Add(下拉框);
        //}

        //private static string 获取查询方式(string 方式, string 类型)
        //{
        //    string value = string.Empty;

        //    if (方式.ToUpper().Equals("LIKE"))
        //        value = " LIKE '%%val%%'";
        //    else if (方式.ToUpper().Equals("BETWEEN"))
        //        value = " BETWEEN";
        //    else if (类型.Equals("INT") || 类型.Equals("DECIMAL") || 类型.Equals("DOUBLE"))
        //        value = 方式 + "%val%";
        //    else if (方式.Trim().Length > 0)
        //        value = 方式 + "'%val%'";

        //    return value;
        //}

        ///// <summary>
        ///// 判断是否为数字
        ///// </summary>
        ///// <param name="strNumber"></param>
        ///// <returns></returns>
        //public static bool IsNumber(String strNumber)
        //{
        //    Regex objNotNumberPattern = new Regex("[^0-9.-]");
        //    Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
        //    Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
        //    String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
        //    String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
        //    Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

        //    return !objNotNumberPattern.IsMatch(strNumber) &&
        //           !objTwoDotPattern.IsMatch(strNumber) &&
        //           !objTwoMinusPattern.IsMatch(strNumber) &&
        //           objNumberPattern.IsMatch(strNumber);
        //}

        //private static void 下拉框_DropDown(object sender, EventArgs e)
        //{
        //    ComboBox cboEdit = sender as ComboBox;
        //    if (cboEdit.Tag.ToString().ToUpper().IndexOf("BETWEEN") >= 0) 加载下拉框日期(cboEdit);
        //    else 绑定下拉框数据(cboEdit);
        //}

        //public static void 设置下拉框绑定(ComboBox 下拉框, Dictionary<string, string> 下拉框数据)
        //{
        //    下拉框.ValueMember = "fID";
        //    下拉框.DisplayMember = "名称";
        //    if (下拉框.Tag != null)
        //    {
        //        下拉框.DataSource = null;
        //        下拉框.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        if (下拉框数据.ContainsKey(下拉框.Tag.ToString().Trim().ToLower()))
        //        {
        //            下拉框.Tag = new object[3] { 下拉框.Tag.ToString().Trim().ToLower(), 下拉框数据[下拉框.Tag.ToString().Trim().ToLower()], null };
        //            下拉框.DropDown += new EventHandler(下拉框_DropDown);
        //            下拉框.TextChanged += new EventHandler(下拉框_TextChanged);
        //            下拉框.KeyDown += new KeyEventHandler(下拉框_KeyDown);
        //        }
        //        else 下拉框.Tag = new object[3] { 下拉框.Tag.ToString(), null, null };
        //    }
        //}
        #endregion
    }
}

