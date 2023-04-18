using System;
using System.Windows.Forms;
using 框架;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Threading;
using System.IO;

namespace ERP
{
    public partial class 主界面 : Form
    {
        public static 主界面 frm主界面 = null;
        private DevExpress.XtraTab.XtraTabControl CurrentTabControl;
        private Thread 消息线程 = null;
        private string 退出模式 = "直接退出"; 

        public 主界面()
        {
            InitializeComponent();
        }

        #region 获取焦点控件
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();

        private Control 获取焦点控件()
        {
            Control focusedControl = null;
            IntPtr focusedHandle = GetFocus();
            if (focusedHandle != IntPtr.Zero)
                focusedControl = Control.FromChildHandle(focusedHandle);
            return focusedControl;
        }
        #endregion

        private void 接收消息()
        {
            string 脚本 = "Exec p消息获取 " + SQL.引号(SQL.操作员);

            while (true)
            {
                if (SQL.连接状态)
                {
                    try
                    {
                        DataTable dt = SQL.查询(SQL.DB.Report_DB, 脚本, "不记日志").Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            this.nf1.ShowBalloonTip(5000, dr["发送人"].ToString(), dr["内容"].ToString(), ToolTipIcon.Info);
                        }
                    }
                    catch 
                    {
                        SQL.连接状态 = false;
                    };
                }
                else
                {
                    SQL.连接状态 = SQL.服务器连接();
                }
                消息线程.Join(5000);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sslbl内存占用.Text = (Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024).ToString() + "M";
            if (SQL.连接状态)
            { 
                sslbl服务器.ForeColor = Color.Green; 
            }
            else
            { 
                sslbl服务器.ForeColor = Color.Red;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                系统初始化();
            }
            catch (Exception ex)
            {
                string 异常 = "系统在初始化过程中发生异常\n[" + ex.Message + "]" + "\n是否重启SHS-ERP?";

                if (消息.提示选择(异常, MessageBoxIcon.Question))
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void 加载系统菜单(ToolStripMenuItem 上级菜单, DataTable dt菜单, string 上级ID)
        {
            foreach (DataRow dr in dt菜单.Select("上级ID=" + 上级ID, "排序 " + ("0".Equals(上级ID) ? "Desc" : "Asc")))
            {
                ToolStripMenuItem tsi = new ToolStripMenuItem();
                tsi.Text = dr["名称"].ToString();
                tsi.Tag = dr;
                if ("0".Equals(上级ID))
                    mmu主菜单.Items.Insert(0, tsi);
                else
                    上级菜单.DropDownItems.Add(tsi);
                tsi.Click += new EventHandler(tsi_Click);
                加载系统菜单(tsi, dt菜单, dr["fID"].ToString());
            }
        }

        void tsi_Click(object sender, EventArgs e)
        {
            打开界面((sender as ToolStripItem).Tag);
        }

        private void 系统初始化()
        {
            try
            {
                this.Visible = false;
                //设置全局变量
                SQL.IP = SQL.获取IP();
                SQL.机器名 = SQL.获取机器名();
                SQL.当前工程 = "SHS-ERP.exe";

                using (new DevExpress.Utils.WaitDialogForm("正在连接服务器，请稍候……"))
                {
                    SQL.连接状态 = SQL.服务器连接();
                }

                if (SQL.连接状态)
                {
                    //系统更新
                    系统更新.更新();
                }
                else
                {
                    文件操作.记日志("服务器连接失败,跳过更新");
                    SQL.连接状态 = false;
                }

                //登陆
                登陆界面 frm = new 登陆界面();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    //登陆成功
                    using (new DevExpress.Utils.WaitDialogForm("正在登陆，请稍候……"))
                    {
                        //设置用户菜单
                        using (DataSet ds = SQL.查询(SQL.DB.Report_DB, "Exec p获取用户菜单 " + SQL.引号(SQL.操作员ID), "文本日志"))
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                加载系统菜单(null, ds.Tables[0], "0");
                                DataRow dr工作中心 = ds.Tables[0].Select("名称='工作中心'", "排序 Asc")[0];
                                打开界面(dr工作中心);
                            }
                        }


                        //设置状态栏
                        if (SQL.服务器 == "(local)") sslbl服务器.Text = "正式环境【内网】";
                        else if (SQL.服务器 == "127.0.0.1") sslbl服务器.Text = "正式环境【外网】";

                        sslbl操作员.Text = SQL.操作员;
                        sslbl时间.Text = DateTime.Now.ToString();

                        timer1.Enabled = true;

                        if (消息线程 == null)
                        {
                            消息线程 = new Thread(new ThreadStart(接收消息));
                            消息线程.IsBackground = true;
                            消息线程.Start();
                        }
                        this.Show();
                        退出模式 = "询问退出";
                    }
                }
                else
                {
                    //取消登陆
                    Close();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void 打开界面(object 功能)
        {
            string 界面定位 = string.Empty;
            string 执行结果 = "成功";
            DateTime 开始时间 = SQL.当前时间();


            if (功能 != null)
            {
                DataRow dr = 功能 as DataRow;
                if (dr["项目名称"].ToString().Length >= 2 && dr["界面定位"].ToString().Length > 3)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        界面定位 = dr["界面定位"].ToString();

                        //获取当前操作的工程
                        SQL.当前工程 = dr["项目名称"].ToString().ToString() == "SHS-ERP" ? "SHS-ERP.exe" : dr["项目名称"].ToString() + ".dll";

                        // 查看窗体是否已经打开
                        foreach (Form childForm in this.MdiChildren)
                        {
                            if (childForm.GetType().FullName.Equals(界面定位))
                            {
                                childForm.BringToFront();
                                return;
                            }
                        }

                        if (dr["名称"].ToString() == "工作中心")
                        {
                            工作中心 frm = new 工作中心();
                            frm.frmMain = this;
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        else
                        {
                            System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(Application.StartupPath + "\\" + SQL.当前工程);
                            Type type = ass.GetType(界面定位);
                            Object obj = Activator.CreateInstance(type);
                            Form frmChild = (Form)obj;
                            基本窗体 frm = (基本窗体)frmChild;
                            frm.Text = dr["名称"].ToString();
                            if (dr["类型"].ToString() == "列表" || dr["类型"].ToString() == "报表")
                            {
                                frm.MdiParent = this;
                                frm.WindowState = FormWindowState.Maximized;
                                frm.Show();
                            }
                            else
                            {
                                frm.StartPosition = FormStartPosition.CenterScreen;
                                frm.ShowDialog();
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        执行结果 = "失败,失败原因如下:" + ex.InnerException.Message.ToString();
                        throw new Exception(ex.InnerException.Message.ToString() + "：【" + 界面定位 + "】");
                    }
                    finally 
                    {
                        string 描述 = "打开窗体[" + dr["名称"].ToString() + "]";
                        SQL.记录日志(描述, 描述, 执行结果, 开始时间);
                        this.Cursor = Cursors.Default; 
                    }
                }
            }
        }

        private void tm1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DevExpress.XtraTab.ViewInfo.BaseTabHitInfo tabHitInfo = tm1.CalcHitInfo(new Point(e.X, e.Y));
                if (tabHitInfo != null && tabHitInfo.Page != null)
                {
                    DevExpress.XtraTabbedMdi.XtraMdiTabPage page = (DevExpress.XtraTabbedMdi.XtraMdiTabPage)tabHitInfo.Page;
                    this.cm菜单页.Show(page.MdiChild, page.TabControl.OwnerControl.PointToClient(Control.MousePosition));
                }
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                (this.cm菜单页.SourceControl as Form).Close();
                (this.cm菜单页.SourceControl as Form).Dispose();
            }
            catch { }
        }

        private void 关闭其他ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form frm in this.MdiChildren)
                {
                    if (!frm.Equals(this.cm菜单页.SourceControl))
                    {
                        frm.Close();
                        frm.Dispose();
                    }
                }
            }
            catch { }
        }

        private void 关闭全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form frm in this.MdiChildren)
                {
                    frm.Close();
                    frm.Dispose();
                }
            }
            catch { }
        }

        private void GetCurrentTabControl(Control ctn)
        {
            if (CurrentTabControl != null) return;
            if (ctn == null || !ctn.HasChildren) return;

            foreach (Control ctl in ctn.Controls)
            {
                if (ctl is DevExpress.XtraTab.XtraTabControl)
                    CurrentTabControl = ctl as DevExpress.XtraTab.XtraTabControl;
                else if (ctl.HasChildren)
                    GetCurrentTabControl(ctl);
            }
        }

        private void tm1_SetNextMdiChild(object sender, DevExpress.XtraTabbedMdi.SetNextMdiChildEventArgs e)
        {
            this.CurrentTabControl = null;
            GetCurrentTabControl(this.ActiveMdiChild);
            if (this.CurrentTabControl == null) return;

            int tabIndex = this.CurrentTabControl.SelectedTabPageIndex;
            int tabCount = this.CurrentTabControl.TabPages.Count;

            if (e.ForwardNavigation)
            {
                if (tabIndex + 1 < tabCount)
                    this.CurrentTabControl.SelectedTabPageIndex = tabIndex + 1;
                else
                    this.CurrentTabControl.SelectedTabPageIndex = 0;
            }
            else
            {
                if (tabIndex == 0)
                    this.CurrentTabControl.SelectedTabPageIndex = tabCount - 1;
                else
                    this.CurrentTabControl.SelectedTabPageIndex = tabIndex - 1;
            }
            e.Handled = true;
        }

        private void tm1_SelectedPageChanged(object sender, EventArgs e)
        {
            DevExpress.XtraTabbedMdi.XtraTabbedMdiManager page = (DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)sender;
            if (page.MdiParent.ActiveMdiChild != null)
            {
            string value = page.MdiParent.ActiveMdiChild.ToString();
            value = value.Substring(0, value.IndexOf("."));

            SQL.当前工程 = value == "SHS-ERP" ? "SHS-ERP.exe" : value + ".dll";
            SQL.当前窗体 = page.MdiParent.ActiveMdiChild.Name.ToString();
            }
        }

        private void nf1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void 主界面_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (消息线程 != null)
            {
                消息线程.Abort();
                消息线程 = null;
            }
            nf1.Visible = false;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            退出系统提示();
        }

        private  void 退出系统提示()
        {
            using (退出系统 frm = new 退出系统())
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Cancel)
                {
                    退出模式 = "取消退出";
                }
                else if (frm.DialogResult == DialogResult.Retry)
                {
                    退出模式 = "确认注销";
                }
                else
                {
                    退出模式 = "确认退出";
                }          
            }
        }

        private void 主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
            }
            else
            {
                this.BringToFront();
            }
        }

        private void 主界面_FormClosing(object sender, FormClosingEventArgs e)
        {          
            if (退出模式 == "询问退出")
            {
                退出系统提示();
            }
            if (退出模式 == "直接退出")
            {
                try
                {
                    if (System.IO.Directory.Exists(Application.StartupPath + "\\导出"))
                        System.IO.Directory.Delete(Application.StartupPath + "\\导出", true);
                }
                catch { }
            }
            else if (退出模式 == "取消退出")
            {
                退出模式 = "询问退出";
                e.Cancel = true;
            }
            else if (退出模式 == "确认退出")
            {
                try
                {
                    DirectoryInfo Dir = new DirectoryInfo(Application.StartupPath + @"\导出\");
                    foreach (FileInfo fi in Dir.GetFiles("*.*"))
                    {
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(fi.FullName); 
                    }
                }
                catch
                { }
            }
            else if (退出模式 == "确认注销")
            {
                退出模式 = "确认退出";
                Application.Restart();
            };

            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    文件操作.记日志("系统关闭,关闭原因:Application.Exit");
                    break;
                case CloseReason.FormOwnerClosing:
                    文件操作.记日志("系统关闭,关闭原因:所有者窗体被关闭");
                    break;
                case CloseReason.MdiFormClosing:
                    文件操作.记日志("系统关闭,关闭原因:MDI父窗体被关闭");
                    break;
                case CloseReason.TaskManagerClosing:
                    文件操作.记日志("系统关闭,关闭原因:任务管理器将其关闭");
                    break;
                case CloseReason.UserClosing:
                    文件操作.记日志("系统关闭,关闭原因:用户关闭");
                    break;
                case CloseReason.WindowsShutDown:
                    文件操作.记日志("系统关闭,关闭原因:操作系统关闭");
                    break;
                case CloseReason.None:
                default:
                    文件操作.记日志("系统关闭,关闭原因:未知理由");
                    break;
            }
        }


    }
}
