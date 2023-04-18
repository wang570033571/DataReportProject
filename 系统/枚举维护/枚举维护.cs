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
    public partial class 枚举维护 : 基本查询窗体
    {
        public 枚举维护()
        {
            InitializeComponent();
            gv枚举.Tag = "v枚举"; 
            gv值.Tag = "v枚举值";
            this.Load += new EventHandler(枚举维护_Load);
        }

        void 枚举维护_Load(object sender, EventArgs e)
        {
            创建树();
        }

        public void 创建树()
        {
            TreeNode tn = null;
            if (tv1.SelectedNode != null)
            {
                tn = tv1.SelectedNode;
                tv1.Nodes.Clear();
            }

            SQL.脚本 = "Select * from 枚举 With (Nolock)";
            DataTable dt = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "创建枚举树").Tables[0];
            SQL.创建树(SQL.DB.Report_DB, tv1, null, dt, "0", "名称");
        }

        public void 新增()
        {
            if (tc1.SelectedTab.Name == "tp枚举")
            {
                if (tv1.SelectedNode == null) return;
                using (枚举维护_枚举新增 frm = new 枚举维护_枚举新增())
                {
                    frm.上级ID = (tv1.SelectedNode.Tag as DataRow)["fID"].ToString();
                    frm.ShowDialog();
                    创建树();
                    tv1.Focus();
                }   
            }
            else
            {
                if (tv1.SelectedNode == null) return;
                if ((tv1.SelectedNode.Tag as DataRow)["是否末级"].ToString() == "0") return;
                using (枚举维护_枚举值新增 frm = new 枚举维护_枚举值新增())
                {
                    frm.枚举ID = (tv1.SelectedNode.Tag as DataRow)["fID"].ToString();
                    frm.ShowDialog();
                    查询(tv1.SelectedNode);
                }   
            }
        }

        public void 编辑()
        {
            if (tc1.SelectedTab.Name == "tp枚举")
            {
                using (枚举维护_枚举新增 frm = new 枚举维护_枚举新增())
                {
                    frm.fID = gv枚举.GetFocusedDataRow()["fID"].ToString();
                    frm.ShowDialog();
                    创建树();
                    tv1.Focus();
                }
            }
            else
            {
                using (枚举维护_枚举值新增 frm = new 枚举维护_枚举值新增())
                {
                    frm.fID = gv值.GetFocusedDataRow()["fID"].ToString();
                    frm.ShowDialog();
                    查询(tv1.SelectedNode);
                }
            }
        }

        public void 查询(TreeNode tn)
        {
            if (tc1.SelectedTab.Name == "tp枚举")
            {
                string fID = (tn.Tag as DataRow)["fID"].ToString();
                SQL.脚本 = "Select * from v枚举 With (Nolock) Where fID=" + SQL.引号(fID);
                SQL.脚本 += " Or 上级ID=" + SQL.引号(fID);
                SQL.脚本 += " Order By 排序";
                SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询枚举", gv枚举);  
            }
            else
            {
                SQL.脚本 = "Select * from v枚举值 With (Nolock) Where 枚举ID=" + SQL.引号((tn.Tag as DataRow)["fID"].ToString());
                SQL.脚本 += " Order By 键";
                SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询枚举值", gv值);           
            }
        }

        private void tv1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            查询(e.Node);
        }

        public void 批量保存()
        {
            if (gv值.RowCount == 0) return;
            if (tc1.SelectedTab.Name == "tp值")
            {
                SQL.脚本 = "";
                gv值.CloseEditor();
                gv值.UpdateCurrentRow();
                for (int i = 0; i < gv值.RowCount; i++)
                {
                    DataRow dr = gv值.GetDataRow(i);
                    if (dr.RowState == DataRowState.Modified)
                    {
                        SQL.脚本 += "Exec  p枚举值保存 " + SQL.引号(dr["fID"].ToString()) + ","
                                                     + SQL.引号(dr["枚举ID"].ToString()) + ","
                                                     + SQL.引号(dr["键"].ToString()) + ","
                                                     + SQL.引号(dr["值"].ToString()) + ","
                                                     + SQL.引号(SQL.操作员) + ","
                                                     + SQL.引号(dr["状态"].ToString()) + ","
                                                     + SQL.引号(dr["自定义1"].ToString()) + ","
                                                     + SQL.引号(dr["自定义2"].ToString()) + ","
                                                     + SQL.引号(dr["自定义3"].ToString()) + ","
                                                     + SQL.引号(dr["自定义4"].ToString()) + ","
                                                     + SQL.引号(dr["自定义5"].ToString()) + "\n";
                    }
                }
                if (SQL.脚本 != "")
                {
                    SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "枚举值保存");
                    消息.提示("操作" + SQL.结果);
                    查询(tv1.SelectedNode);
                }
            }
        }

        private void tc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            查询(tv1.SelectedNode);
        }

        public void 删除()
        {
            if (tc1.SelectedTab.Name == "tp枚举")
            {
                SQL.脚本 = "";
                foreach (int i in gv枚举.GetSelectedRows())
                {
                    SQL.脚本 += "Exec p枚举删除 " + SQL.引号(gv枚举.GetDataRow(i)["fID"].ToString()) + ","
                                                    + SQL.引号(SQL.操作员) + "\n";
                }
                if (SQL.脚本 != "")
                {
                    SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "枚举删除");
                    消息.提示("操作" + SQL.结果);
                    if (SQL.结果 == "成功") { 查询(tv1.SelectedNode); }
                }
            }
            else
            {
                SQL.脚本 = "";
                foreach (int i in gv值.GetSelectedRows())
                {
                    SQL.脚本 += "Exec p枚举值删除 " + SQL.引号(gv值.GetDataRow(i)["fID"].ToString()) + ","
                                                    + SQL.引号(SQL.操作员) + "\n";
                }
                if (SQL.脚本 != "")
                {
                    SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "枚举值删除");
                    消息.提示("操作" + SQL.结果);
                    if (SQL.结果 == "成功") { 查询(tv1.SelectedNode); }
                }
            }
        }
    }
}
