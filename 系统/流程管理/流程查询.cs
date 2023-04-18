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
    public partial class 流程查询 : 基本查询窗体
    {
        public 流程查询()
        {
            InitializeComponent();
            this.Load += new EventHandler(流程查询_Load);
        }

        void 流程查询_Load(object sender, EventArgs e)
        {
            cbb制单日期.Text = "本月";
            初始化树();
        }

        private void 初始化树()
        {
            SQL.脚本 = "Select * from v流程实例汇总 With (Nolock)";
            SQL.创建树(SQL.DB.Process_DB, tv1, null, SQL.脚本, 1, true, "名称");
        }

        private void cbb制单日期_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Report_DB, cbb制单日期, "Select 名称 from v日期周期 With (Nolock) Order By fID", false);
        }

        private void cbb状态_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Report_DB, cbb状态, "Select 名称 from v状态 With (Nolock) Order By fID", false);
        }

        public void 查询()
        {
            SQL.脚本 = SQL.获取查询脚本(panel1);
            SQL.查询(SQL.DB.Process_DB, SQL.脚本, "查询流程实例表头", gv1);
            初始化树();
            gv2.Columns.Clear();
        }

        private void gc1_Click(object sender, EventArgs e)
        {
            查询明细();
        }

        private void 查询明细()
        {
            if (gv1.RowCount == 0) return;
            if (tc1.SelectedTab == tp明细)
            {
                SQL.脚本 = "Select * from v流程实例表体 With (Nolock) Where 表头ID=" + SQL.引号(gv1.GetFocusedDataRow()["fID"].ToString()) + " Order By 1";
                SQL.查询(SQL.DB.Process_DB, SQL.脚本, "查询流程实例表体", gv2);
            }
            lbl流程进度.Text = SQL.取值(SQL.DB.Process_DB, "Select dbo.f获取流程进度(" + SQL.引号(gv1.GetFocusedDataRow()["fID"].ToString()) + ",0)", "获取流程进度");
        }

        private void tv1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                txt流程ID.Text = (e.Node.Tag as DataRow)["流程ID"].ToString();
                cbb状态.Text = "已提交";
                查询();
                gv2.Columns.Clear();
            }
        }

        public void 中止()
        {
            if (!消息.提示选择("是否确认中止?", MessageBoxIcon.Warning)) return;

            输入框 frm = new 输入框();
            frm.Text = "请输入批注";
            frm.ShowDialog();

            string 审批批注 = frm.返回值;

            SQL.脚本 = "";
            foreach (int i in gv1.GetSelectedRows())
            {
                SQL.脚本 += "Exec p流程实例关闭 " + SQL.引号(gv1.GetDataRow(i)["fID"].ToString()) + ","
                                                  + SQL.引号(SQL.操作员) + ","
                                                  + SQL.引号(审批批注) + ";\n";
            }

            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程实例关闭");
                消息.提示("操作" + SQL.结果);
                if (SQL.结果 == "成功") { 查询(); }
            }
        }

        public void 发起()
        {
            if (!消息.提示选择("是否确认重新发起?", MessageBoxIcon.Warning)) return;

            SQL.脚本 = "";
            foreach (int i in gv1.GetSelectedRows())
            {
                SQL.脚本 += "Exec p流程实例重复发起 " + SQL.引号(gv1.GetDataRow(i)["fID"].ToString()) + ","
                                                + SQL.引号(SQL.操作员) + "\n";
            }
            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程实例重复发起");
                消息.提示("操作" + SQL.结果);
                if (SQL.结果 == "成功") { 查询(); }
            }        
        }

        public void 单证()
        {
            if (gv1.RowCount == 0) return;
            try
            {
                string 模块 = gv1.GetFocusedDataRow()["模块"].ToString();
                string 项目 = SQL.获取符号前字符串(模块, ".") + ".dll"; ;
                string 窗体名称 = gv1.GetFocusedDataRow()["单证"].ToString();
                System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(Application.StartupPath + "\\" + 项目);
                Type type = ass.GetType(模块);
                Object obj = Activator.CreateInstance(type);
                Form frmChild = (Form)obj;
                基本窗体 frm = (基本窗体)frmChild;
                frm.Text = 窗体名称;
                frm.工作流 = gv1.GetFocusedDataRow();

                string 是否全屏 = SQL.取值(SQL.DB.Process_DB, "Select 全屏显示 from 流程定义表头 With (Nolock) Where fID=" + SQL.引号(gv1.GetFocusedDataRow()["流程ID"].ToString()), "文本日志");
                if (是否全屏 == "1")
                {
                    frm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    frm.WindowState = FormWindowState.Normal;
                }
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                消息.提示("显示单证失败,失败原因如下:" + ex.InnerException.Message.ToString());
                return;
            }
        }

        private void tc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            查询明细();
        }

        private void gv附件_DoubleClick(object sender, EventArgs e)
        {
            //if (gv附件.RowCount == 0) return;
            //string 路径 = Application.StartupPath + @"\导出\";
            //if (!Directory.Exists(路径)) Directory.CreateDirectory(路径);
            //string 路径文件名 = 路径 + gv附件.GetFocusedDataRow()["文件名"].ToString();
            //文件操作.文件流转换成文件(路径, gv附件.GetFocusedDataRow()["文件名"].ToString(), (byte[])(gv附件.GetFocusedDataRow()["内容"]));
            //FileInfo fi = new FileInfo(路径文件名);
            //File.SetAttributes(路径文件名, fi.Attributes | FileAttributes.ReadOnly);
            //System.Diagnostics.Process.Start(路径文件名);
        }
    }
}
