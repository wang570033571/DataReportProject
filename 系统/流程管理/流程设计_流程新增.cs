using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 框架;
using System.IO;

namespace 系统
{
    public partial class 流程设计_流程新增 : 基本查询窗体
    {
        public string fID = "0";
        private string 附件名 = "";
        private byte[] 附件内容;

        public 流程设计_流程新增()
        {
            InitializeComponent();
            this.Load += new EventHandler(流程设计_流程新增_Load);
        }

        void 流程设计_流程新增_Load(object sender, EventArgs e)
        {
            初始化();
            查询();
        }

        public void 查询()
        {
            SQL.脚本 = "Select * from v流程定义表体 With (Nolock) Where 表头ID=" + SQL.引号(fID);
            SQL.脚本 += "Order By 节点";
            SQL.查询(SQL.DB.Process_DB, SQL.脚本, "查询流程定义表体",gv节点);
        }

        public void 保存()
        {
            string 全屏显示 = "0";
            if (cb全屏显示.Checked) 全屏显示 = "1";
            SQL.脚本 = "Exec p流程定义表头保存 " + SQL.引号(fID) + ","
                                             + SQL.引号(txt名称.Text) + ","
                                             + SQL.引号(txt单证.Text) + ","
                                             + SQL.引号(cbb数据库.Text) + ","
                                             + SQL.引号(cbb视图.Text) + ","
                                             + SQL.引号(cbb明细视图.Text) + ","
                                             + SQL.引号(SQL.操作员) + ","
                                             + SQL.引号(txt模块.Text) + ","
                                             + SQL.引号(全屏显示)+","
                                             + SQL.引号(附件名) + ","
                                             + "@附件";
            SQL.结果 = SQL.上传(SQL.DB.Process_DB, SQL.脚本, "流程定义表头保存", 附件内容);
            if (SQL.结果 == "成功")
            {
                fID = SQL.根据名称获取ID(SQL.DB.Process_DB, txt名称.Text, "流程定义表头");
                消息.提示("操作" + SQL.结果);
            }
            else
            {
                消息.提示("操作" + SQL.结果);
            }
        }

        public void 新增节点()
        {
            if (fID == "0")
            {
                消息.提示("流程ID不能为0");
                return;
            }

            using (流程设计_节点新增 frm = new 流程设计_节点新增())
            {
                frm.表头ID = fID;
                frm.ShowDialog();
                查询();
            }
        }

        public void 编辑节点()
        {
            if (fID == "0")
            {
                消息.提示("流程ID不能为0");
                return;
            }

            using (流程设计_节点新增 frm = new 流程设计_节点新增())
            {
                frm.表头ID = fID;
                frm.fID = gv节点.GetFocusedDataRow()["fID"].ToString();
                frm.ShowDialog();
                查询();
            }
        }

        public void 删除节点()
        {
            SQL.脚本 = "";
            foreach (int i in gv节点.GetSelectedRows())
            {
                SQL.脚本 += "Exec p流程定义表体删除 " + SQL.引号(gv节点.GetDataRow(i)["fID"].ToString()) + ","
                                                + SQL.引号(SQL.操作员) + "\n";
            }
            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程定义表体删除");
                消息.提示("操作" + SQL.结果);
                if (SQL.结果 == "成功") { 查询(); }
            }
        }

        public void 移动节点()
        {
            if (gv节点.RowCount == 0) return;
            using (流程设计_节点移动 frm = new 流程设计_节点移动())
            {
                frm.表头ID = fID;
                frm.改前节点 = this.gv节点.GetFocusedDataRow()["节点"].ToString();
                frm.ShowDialog();
                查询();
            }
        }

        private void cbb数据库_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Report_DB, cbb数据库, "Select 名称 from v数据库 With (Nolock) Order By 1", false);
        }

        private void cbb视图_DropDown(object sender, EventArgs e)
        {
            if (cbb数据库.Text == "")
            {
                消息.提示("请选择数据库");
                return;
            }
            SQL.DB 数据库 = (SQL.DB)Enum.Parse(typeof(SQL.DB), cbb数据库.Text);
            SQL.加载下拉框(数据库, cbb视图, " Select 名称 from v数据库对象 With (Nolock) Where 类型 = '视图' Order By 1", true);
        }

        private void cbb明细视图_DropDown(object sender, EventArgs e)
        {
            if (cbb数据库.Text == "")
            {
                消息.提示("请选择数据库");
                return;
            }
            SQL.DB 数据库 = (SQL.DB)Enum.Parse(typeof(SQL.DB), cbb数据库.Text);
            SQL.加载下拉框(数据库, cbb明细视图, " Select 名称 from v数据库对象 With (Nolock) Where 类型 = '视图' Order By 1", true);
        }

        private void 初始化()
        {
            SQL.脚本 = "Select * from v流程定义表头 With (Nolock) Where fID=" + SQL.引号(fID);
            SQL.设置控件值(SQL.DB.Process_DB, panel1, SQL.脚本);

            //新增,设置默认值
            if (fID != "0")
            {
                DataSet ds = SQL.查询(SQL.DB.Process_DB, "Select 附件名,附件 from 流程定义表头 With (Nolock) Where fID=" + SQL.引号(fID), "获取流程定义附件");
                附件名 = ds.Tables[0].Rows[0]["附件名"].ToString();
                if (附件名 != "")
                {
                    附件内容 = (byte[])ds.Tables[0].Rows[0]["附件"];
                }
            }
            附件按钮状态();
        }

        private void gc节点_Click(object sender, EventArgs e)
        {
            单击节点();
        }

        private void 单击节点()
        {
            if (gv节点.RowCount == 0) return;
            if (gv节点.GetFocusedDataRow()["类型"].ToString() == "条件") { tc1.SelectedTab = tp条件; }
            else if (gv节点.GetFocusedDataRow()["类型"].ToString() == "活动") {tc1.SelectedTab = tp活动; }

            if (tc1.SelectedTab == tp活动)
            {
                SQL.脚本 = "Select * from v流程定义活动 With (Nolock) Where 表头ID = " + SQL.引号(fID)
                           + " And 节点 = " + SQL.引号(gv节点.GetFocusedDataRow()["节点"].ToString());
                SQL.查询(SQL.DB.Process_DB, SQL.脚本, "查询流程定义活动", gv活动);
                gv条件.GridControl.DataSource = null;
            }
            else if (tc1.SelectedTab == tp条件)
            {
                SQL.脚本 = "Select * from v流程定义条件 With (Nolock) Where 表头ID = " + SQL.引号(fID)
                           + " And 节点 = " + SQL.引号(gv节点.GetFocusedDataRow()["节点"].ToString());
                SQL.查询(SQL.DB.Process_DB, SQL.脚本, "查询流程定义条件", gv条件);
                gv活动.GridControl.DataSource = null;

            }    
        }

        private void btn新增活动_Click(object sender, EventArgs e)
        {
            using (流程设计_活动新增 frm = new 流程设计_活动新增())
            {
                frm.表头ID = fID;
                frm.b数据库 = cbb数据库.Text;
                frm.节点 = gv节点.GetFocusedDataRow()["节点"].ToString();
                frm.ShowDialog();
                单击节点();
            }
        }

        private void btn编辑活动_Click(object sender, EventArgs e)
        {
            if (gv活动.RowCount == 0) return;
            using (流程设计_活动新增 frm = new 流程设计_活动新增())
            {
                frm.fID = gv活动.GetFocusedDataRow()["fID"].ToString();
                frm.表头ID = fID;
                frm.节点 = gv节点.GetFocusedDataRow()["节点"].ToString();
                frm.ShowDialog();
                单击节点();
            }    
        }

        private void btn删除活动_Click(object sender, EventArgs e)
        {
            SQL.脚本 = "";
            foreach (int i in gv活动.GetSelectedRows())
            {
                SQL.脚本 += "Exec p流程定义活动删除 " + SQL.引号(gv活动.GetDataRow(i)["fID"].ToString()) + ","
                                                + SQL.引号(SQL.操作员) + "\n";
            }
            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程定义活动删除");
                消息.提示("操作" + SQL.结果);
                if (SQL.结果 == "成功") { 单击节点(); }
            }
        }

        private void btn新增条件_Click(object sender, EventArgs e)
        {
            using (流程设计_条件新增 frm = new 流程设计_条件新增())
            {
                frm.表头ID = fID;
                frm.节点 = gv节点.GetFocusedDataRow()["节点"].ToString();
                frm.ShowDialog();
                单击节点();
            }
        }

        private void btn编辑条件_Click(object sender, EventArgs e)
        {
            if (gv条件.RowCount == 0) return;
            using (流程设计_条件新增 frm = new 流程设计_条件新增())
            {
                frm.fID = gv条件.GetFocusedDataRow()["fID"].ToString();
                frm.表头ID = fID;
                frm.节点 = gv节点.GetFocusedDataRow()["节点"].ToString();
                frm.ShowDialog();
                单击节点();
            }
        }

        private void btn删除条件_Click(object sender, EventArgs e)
        {
            SQL.脚本 = "";
            foreach (int i in gv条件.GetSelectedRows())
            {
                SQL.脚本 += "Exec p流程定义条件删除 " + SQL.引号(gv条件.GetDataRow(i)["fID"].ToString()) + ","
                                                + SQL.引号(SQL.操作员) + "\n";
            }
            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程定义条件删除");
                消息.提示("操作" + SQL.结果);
                if (SQL.结果 == "成功") { 单击节点(); }
            }
        }

        public void 视图配置()
        {
            if (fID == "0")
            {
                消息.提示("流程ID不能为0");
                return;
            }

            using (流程设计_视图配置 frm = new 流程设计_视图配置())
            {
                frm.表头ID = fID;
                frm.数据库 = cbb数据库.Text;
                frm.视图 = cbb视图.Text;
                frm.明细视图 = cbb明细视图.Text;
                frm.ShowDialog();
            }
        }

        private void 附件按钮状态()
        {
            if (附件名 == "")
            {
                btn查看.Enabled = false;
                btn上传.Text = "上传";
            }
            else
            {
                btn查看.Enabled = true;
                btn上传.Text = "删除";
            }
        }

        private void btn上传_Click(object sender, EventArgs e)
        {
            if (btn上传.Text == "上传")
            {
                OpenFileDialog 文件打开 = new OpenFileDialog();
                文件打开.Multiselect = false;
                文件打开.ReadOnlyChecked = true;
                文件打开.Title = "请选择文件";
                文件打开.ShowDialog();
                string 文件名 = 文件打开.FileName;
                if (文件名 != "")
                {
                    FileInfo 文件 = new FileInfo(文件名);
                    附件名 = 文件.Name;
                    string 大小 = Convert.ToString(文件.Length / 1000);
                    附件内容 = 文件操作.文件转换成文件流(文件.FullName);
                }
                附件按钮状态();
            }
            else
            {
                if (!消息.提示选择("是否要删除流程！", MessageBoxIcon.Warning)) return;
                附件名 = "";
                附件内容 = null;
                附件按钮状态();

            }
        }

        private void btn查看_Click(object sender, EventArgs e)
        {
            string 路径 = Application.StartupPath + @"\导出\";
            if (!Directory.Exists(路径)) Directory.CreateDirectory(路径);
            string 路径文件名 = 路径 + 附件名;
            文件操作.文件流转换成文件(路径, 附件名, 附件内容);
            System.Diagnostics.Process.Start(路径文件名);
        }

        private void gc节点_DoubleClick(object sender, EventArgs e)
        {
           编辑节点();
        }
    }
}
