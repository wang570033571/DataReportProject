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
    public partial class 菜单维护 : 基本查询窗体
    {
        public 菜单维护()
        {
            InitializeComponent();
            this.Load += new EventHandler(菜单维护_Load);
            tv1.NodeMouseClick += new TreeNodeMouseClickEventHandler(tv1_NodeMouseClick);
            tc1.SelectedIndexChanged += new EventHandler(tc1_SelectedIndexChanged);
        }

        void tc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            查询(tv1.SelectedNode);
        }

        void tv1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            查询(e.Node);
        }

        void 菜单维护_Load(object sender, EventArgs e)
        {
            创建树();
        }

        private void 创建树()
        {
            TreeNode tn = null;
            if (tv1.SelectedNode != null)
            {
                tn = tv1.SelectedNode;
                tv1.Nodes.Clear();
            }

            SQL.脚本 = "Select * from 菜单 With (Nolock)";
            DataTable dt = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "获取菜单").Tables[0];
            SQL.创建树(SQL.DB.Report_DB, tv1, null, dt, "0", "名称");
            //tv1.ExpandAll();

            if (tn != null)
            {
                tv1.Nodes.Find(tn.Name, true);
            }
        }

        private void 查询(TreeNode tn)
        {
            if (tv1.SelectedNode == null) return;
            string fID = (tn.Tag as DataRow)["fID"].ToString();
            string 窗体 = (tn.Tag as DataRow)["界面定位"].ToString();
            if (tc1.SelectedTab.Name == "tp菜单")
            {
                SQL.脚本 = "Select * from v菜单 With (nolock) Where fID=" + SQL.引号(fID);
                SQL.脚本 += " Or 上级ID=" + SQL.引号(fID);
                SQL.脚本 += " Order By 上级ID,排序";
                SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询菜单", gv菜单);
            }
            else if (tc1.SelectedTab.Name == "tp按钮")
            {
                SQL.脚本 = "Select * from v按钮 With (nolock) Where 菜单ID=" + SQL.引号(fID) + " Order By 排序";
                SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询按钮", gv按钮);
            }
            else if (tc1.SelectedTab.Name == "tp字段")
            {
                SQL.脚本 = "Select * from v字段 With (nolock) Where 窗体=" + SQL.引号(窗体) + " Order By 视图,排序";
                SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询字段", gv字段);
            }
        }

        public void 新增()
        {
            if (tv1.SelectedNode == null) return;
            if (tc1.SelectedTab.Name == "tp菜单")
            {
                using (菜单_新增 frm = new 菜单_新增())
                {
                    frm.上级ID = (tv1.SelectedNode.Tag as DataRow)["fID"].ToString();
                    frm.ShowDialog();
                }
                创建树();
            }
            else if (tc1.SelectedTab.Name == "tp按钮")
            {
                using (按钮_新增 frm = new 按钮_新增())
                {
                    frm.按钮菜单ID = (tv1.SelectedNode.Tag as DataRow)["fID"].ToString();
                    frm.ShowDialog();
                }
                查询(tv1.SelectedNode);
            }
            else if (tc1.SelectedTab.Name == "tp字段")
            {
                //using (菜单维护_字段新增 frm = new 菜单维护_字段新增())
                //{
                //    frm.窗体 = (tv1.SelectedNode.Tag as DataRow)["界面定位"].ToString();
                //    frm.ShowDialog();
                //}
                查询(tv1.SelectedNode);
            }
        }

        public void 编辑()
        {
            if (tv1.SelectedNode == null) return;
            if (tc1.SelectedTab.Name == "tp菜单")
            {
                using (菜单_新增 frm = new 菜单_新增())
                {
                    frm.fID = (tv1.SelectedNode.Tag as DataRow)["fID"].ToString();
                    frm.ShowDialog();
                }
                创建树();
            }
            else if (tc1.SelectedTab.Name == "tp按钮")
            {
                using (按钮_新增 frm = new 按钮_新增())
                {
                    frm.fID = (gv按钮.GetFocusedDataRow()["fID"].ToString());
                    frm.ShowDialog();
                }
                查询(tv1.SelectedNode);
            }
            else if (tc1.SelectedTab.Name == "tp字段")
            {
                消息.提示("字段不支持编辑");
            }
        }

        public void 批量保存()
        {
            if (gv菜单.RowCount == 0) return;
            if (tc1.SelectedTab.Name == "tp菜单")
            {
                SQL.脚本 = "";
                gv菜单.CloseEditor();
                gv菜单.UpdateCurrentRow();
                for (int i = 0; i < gv菜单.RowCount; i++)
                {
                    DataRow dr = gv菜单.GetDataRow(i);
                    if (dr.RowState == DataRowState.Modified)
                    {
                        SQL.脚本 += "Exec p菜单保存 " + SQL.引号(dr["fID"].ToString()) + ","
                                                      + SQL.引号(dr["名称"].ToString()) + ","
                                                      + SQL.引号(dr["上级ID"].ToString()) + ","
                                                      + SQL.引号(dr["排序"].ToString()) + ","
                                                      + SQL.引号(dr["界面定位"].ToString()) + ","
                                                      + SQL.引号(dr["状态"].ToString()) + ","
                                                      + SQL.引号(dr["项目名称"].ToString()) + ","
                                                      + SQL.引号(dr["是否末级"].ToString()) + ","
                                                      + SQL.引号(dr["类型"].ToString()) + ","
                                                      + SQL.引号(dr["备注"].ToString()) + ","
                                                      + SQL.引号(SQL.操作员) + "\n";
                    }
                }
                if (SQL.脚本 != "")
                {
                    SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "菜单保存");
                    消息.提示("操作" + SQL.结果);
                    创建树();
                }
            }
            else if (tc1.SelectedTab.Name == "tp按钮")
            {
                SQL.脚本 = "";
                gv按钮.CloseEditor();
                gv按钮.UpdateCurrentRow();
                for (int i = 0; i < gv按钮.RowCount; i++)
                {
                    DataRow dr = gv按钮.GetDataRow(i);
                    if (dr.RowState == DataRowState.Modified)
                    {
                        SQL.脚本 += "Exec p按钮保存 "
                                    + SQL.引号(dr["fID"].ToString()) + ","
                                    + SQL.引号(dr["名称"].ToString()) + ","
                                    + SQL.引号(dr["菜单ID"].ToString()) + ","
                                    + SQL.引号(dr["排序"].ToString()) + ","
                                    + SQL.引号(dr["状态"].ToString()) + ","
                                    + SQL.引号(SQL.操作员) + ","
                                    + SQL.引号(dr["备注"].ToString()) + "\n";
                    }
                }
                if (SQL.脚本 != "")
                {
                    SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "按钮保存");
                    消息.提示("操作" + SQL.结果);
                    查询(tv1.SelectedNode);
                }
            }
            else if (tc1.SelectedTab.Name == "tp字段")
            {
                SQL.脚本 = "";
                gv字段.CloseEditor();
                gv字段.UpdateCurrentRow();
                for (int i = 0; i < gv字段.RowCount; i++)
                {
                    DataRow dr = gv字段.GetDataRow(i);
                    if (dr.RowState == DataRowState.Modified)
                    {
                        SQL.脚本 += "Exec p字段保存 " + SQL.引号(dr["fID"].ToString()) + ","
                                                      + SQL.引号(dr["排序"].ToString()) + ","
                                                      + SQL.引号(dr["是否显示"].ToString()) + ","
                                                      + SQL.引号(dr["是否可编辑"].ToString()) + ","
                                                      + SQL.引号(dr["是否查询"].ToString()) + ","
                                                      + SQL.引号(dr["查询类型"].ToString()) + ","
                                                      + SQL.引号(dr["查询脚本"].ToString()) + ","
                                                      + SQL.引号(dr["小数位数"].ToString()) + "\n";
                    }
                }
                if (SQL.脚本 != "")
                {
                    SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "字段保存");
                    消息.提示("操作" + SQL.结果);
                    查询(tv1.SelectedNode);
                }
            }
        }

        public void 删除()
        {
            if (tv1.SelectedNode == null) return;
            if (tc1.SelectedTab.Name == "tp菜单")
            {
                string fID = gv菜单.GetFocusedDataRow()["fID"].ToString();
                SQL.脚本 = "Exec p菜单删除 " + SQL.引号(fID) + ',' + SQL.引号(SQL.操作员);
                SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "菜单删除");
                消息.提示("操作" + SQL.结果);
                if (SQL.结果 == "成功") 创建树();
            }
            else if (tc1.SelectedTab.Name == "tp按钮")
            {
                string fID = gv按钮.GetFocusedDataRow()["fID"].ToString();
                SQL.脚本 = "Exec p按钮删除 " + SQL.引号(fID) + ',' + SQL.引号(SQL.操作员);
                SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "按钮删除");
                消息.提示("操作" + SQL.结果);
                if (SQL.结果 == "成功") 查询(tv1.SelectedNode);
            }
            else if (tc1.SelectedTab.Name == "tp字段")
            {
                string fID = "";
                SQL.脚本 = "";
                foreach (int i in gv字段.GetSelectedRows())
                {
                    fID = gv字段.GetDataRow(i)["fID"].ToString();
                    SQL.脚本 += "Exec p字段删除 " + SQL.引号(fID) + "," + SQL.引号(SQL.操作员) + "\n";
                }
                if (SQL.脚本 != "")
                {
                    SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "字段删除");
                    消息.提示("操作" + SQL.结果);
                    if (SQL.结果 == "成功") 查询(tv1.SelectedNode);
                }
            }
        }
    }
}
