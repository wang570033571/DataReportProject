using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 框架;

namespace 系统
{
    public partial class 流程代理人_选择 : 基本查询窗体
    {
        public string 返回值 = "";

        public 流程代理人_选择()
        {
            InitializeComponent();
            this.Load += new EventHandler(流程代理人_选择_Load);
        }

        void 流程代理人_选择_Load(object sender, EventArgs e)
        {
            初始化树();
        }

        private void 初始化树()
        {
            SQL.脚本 = "Select * from v部门 With (Nolock) Where 状态=1 And 上级ID=0 And 类型 <> '其他' Order By 排序";
            SQL.创建树(SQL.DB.Report_DB, tv1, null, SQL.脚本, 0, true, "名称");
        }

        public void 树单击(TreeNode tn)
        {
            if (tn.Level == 0)
            {
                SQL.脚本 = "Select * from v流程代理人 With (Nolock) Where 1=1";
                SQL.脚本 += " And 部门ID = " + SQL.引号((tn.Tag as DataRow)["fID"].ToString());
                SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询通讯录", gv1);
            }
            else
            {
                SQL.脚本 = "Select * from v流程代理人 With (Nolock) Where 1=1";
                SQL.脚本 += " And 岗位ID = " + SQL.引号((tn.Tag as DataRow)["fID"].ToString());
                SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询通讯录", gv1);
            }
        }

        private void tv1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                string 部门ID = (e.Node.Tag as DataRow)["fID"].ToString();
                SQL.脚本 = "Select * from v岗位树 With (Nolock) Where 状态=1 And 部门ID=" + SQL.引号(部门ID);
                DataSet ds = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "文本日志");
                SQL.创建树(SQL.DB.Report_DB, tv1, e.Node, ds.Tables[0], "0", "名称");
            }
        }

        private void tv1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            树单击(e.Node);
        }

        public void 查询()
        {
            SQL.脚本 = "Select * from v流程代理人 With (Nolock) Where 1=1";
            if (txt姓名.Text != "") SQL.脚本 += " And 姓名 Like " + SQL.引号(txt姓名.Text, 2);
            SQL.脚本 += " Order By 姓名";
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询通讯录", gv1);
        }

        private void txt姓名_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 查询();
        }

        public void 选择()
        {
            if (gv1.RowCount != 0)
            {
                DataRow dr=gv1.GetFocusedDataRow();
                返回值 = dr["用户"].ToString();
                Close();
            }
        }

        private void gc1_DoubleClick(object sender, EventArgs e)
        {
            选择();
        }
    }
}
