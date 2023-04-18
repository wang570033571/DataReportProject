using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using 框架;

namespace 系统
{
    public partial class 权限分配 : 基本查询窗体
    {
        public string 用户ID = "";
        private DataTable dt原始;
        private ArrayList 新增List;
        private ArrayList 删除List;
        private bool frmInit = false;

        public 权限分配()
        {
            InitializeComponent();
            this.Load += new EventHandler(权限分配_Load);
        }

        void 权限分配_Load(object sender, EventArgs e)
        {
            初始化();
        }

        private void 初始化菜单权限(DevExpress.XtraTreeList.Nodes.TreeListNodes treeListNodes, DataTable dt)
        {
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in treeListNodes)
            {

                DataRow[] drSelect = dt.Select("菜单ID = " + SQL.引号(node.GetValue("fID").ToString()));
                if (drSelect.Length > 0)
                    node.Checked = true;
                else
                    node.Checked = false;

                if (node.HasChildren) 初始化菜单权限(node.Nodes, dt);
            }
        }

        public void 初始化()
        {
            string 系统管理员 = SQL.取值(SQL.DB.Report_DB, "select 岗位 from 用户 with (nolock) where 名称='" + SQL.操作员 + "'", "获取用户ID");

            if (系统管理员 == "系统管理员")
            {
                SQL.脚本 = "Select * from v菜单按钮树 With (Nolock) order by 上级ID,类型,排序,fID;\n" +
                           "Select 菜单ID from v用户权限 With (Nolock) Where 用户ID=" + SQL.引号(用户ID);
            }
            else
            {
                SQL.脚本 = "Select * from v菜单按钮树_非管理员 With (Nolock) order by 上级ID,类型,排序,fID;\n" +
                           "Select 菜单ID from v用户权限 With (Nolock) Where 用户ID=" + SQL.引号(用户ID);
            }
            DataSet dsData = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "获取菜单");


            tv1.OptionsView.ShowCheckBoxes = true;
            tv1.ClearNodes();
            tv1.DataSource = dsData.Tables[0].Copy();
            tv1.BestFitColumns();
            tv1.CollapseAll();


            初始化菜单权限(tv1.Nodes, dsData.Tables[1]);
            dt原始 = dsData.Tables[1].Copy();
            新增List = new ArrayList();
            删除List = new ArrayList();
            frmInit = false;
        }

        public void 保存()
        {
            新增List.Clear();
            删除List.Clear();
            SQL.脚本 = "";

            获取变更功能ID(tv1.Nodes);

            foreach (string fID in 新增List)
            {
                if (Convert.ToInt16(fID) > 0)
                {
                    SQL.脚本 += "Exec p用户菜单新增 " + SQL.引号(用户ID) + "," + SQL.引号(fID) + "," + SQL.引号(SQL.操作员) + "\n";
                }
                else
                {
                    SQL.脚本 += "Exec p用户按钮新增 " + SQL.引号(用户ID) + "," + SQL.引号(Convert.ToString(Convert.ToInt16(fID) * -1)) + "," + SQL.引号(SQL.操作员) + "\n";
                }
            }

            foreach (string fID in 删除List)
            {
                if (Convert.ToInt16(fID) > 0)
                {
                    SQL.脚本 += "Exec p用户菜单删除 " + SQL.引号(用户ID) + "," + SQL.引号(fID) + "," + SQL.引号(SQL.操作员) + "\n";
                }
                else
                {
                    SQL.脚本 += "Exec p用户按钮删除 " + SQL.引号(用户ID) + "," + SQL.引号(Convert.ToString(Convert.ToInt16(fID) * -1)) + "," + SQL.引号(SQL.操作员) + "\n";
                }
            }

            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "用户权限设置");
                消息.提示("操作" + SQL.结果);
                if (SQL.结果 == "成功") Close();
            }
            else
            {
                消息.提示("操作成功");
                Close();
            }
        }

        private void 获取变更功能ID(DevExpress.XtraTreeList.Nodes.TreeListNodes treeListNodes)
        {
            try
            {
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode tn in treeListNodes)
                {
                    if (tn != null)
                    {
                        if (tn.Checked)
                        {
                            DataRow[] drAdd = dt原始.Select("菜单ID = " + SQL.引号(tn.GetValue("fID").ToString()));

                            //tv选中,dt不存在,则新增
                            if (drAdd.Length == 0)
                            {
                                新增List.Add(tn.GetValue("fID").ToString());
                            }
                        }
                        else
                        {
                            DataRow[] drDel = dt原始.Select("菜单ID = " + SQL.引号(tn.GetValue("fID").ToString()));

                            //tv不选中,dt存在,则删除
                            if (drDel.Length > 0)
                            {
                                删除List.Add(tn.GetValue("fID").ToString());
                            }
                        }
                        if (tn.HasChildren) 获取变更功能ID(tn.Nodes);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 上级模块也选中
        /// </summary>
        /// <param name="treeListNode"></param>
        private void SetParentNodeChecked(DevExpress.XtraTreeList.Nodes.TreeListNode treeListNode)
        {
            if (treeListNode.ParentNode != null && treeListNode.CheckState == CheckState.Checked)
            {
                if (treeListNode.ParentNode.CheckState == CheckState.Unchecked)
                {
                    treeListNode.ParentNode.CheckState = CheckState.Checked;

                    SetParentNodeChecked(treeListNode.ParentNode);
                }
            }
        }

        /// <summary>
        /// 清除下级模块选中
        /// </summary>
        /// <param name="treeListNodes"></param>
        private void SetChildNodesChecked(DevExpress.XtraTreeList.Nodes.TreeListNode treeListNode)
        {
            if (treeListNode.HasChildren)
            {
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in treeListNode.Nodes)
                {
                    if (node.CheckState != treeListNode.CheckState)
                    {
                        node.CheckState = treeListNode.CheckState;
                        SetChildNodesChecked(node);
                    }
                }
            }

            int intCount = 0;
            if (treeListNode.ParentNode != null && !treeListNode.Checked)
            {
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in treeListNode.ParentNode.Nodes)
                {
                    if (node.Checked) intCount++;
                }

                if (intCount == 0)
                {
                    treeListNode.ParentNode.Checked = false;

                    if (treeListNode.ParentNode.ParentNode != null) SetChildNodesChecked(treeListNode.ParentNode);
                }
            }
        }

        private void tv1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null && frmInit == false)
            {
                SetParentNodeChecked(e.Node); //如果选中，则上级模块也被选中
                SetChildNodesChecked(e.Node); //下级模块选中
            }
        }
    }
}
