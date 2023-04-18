﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 框架;
 
namespace ERP
{
    public partial class 工作中心 : 基本窗体
    {
        private string 日期范围;
        private string 展开节点 = "";
 
        public 主界面 frmMain = null;
 
        public 工作中心()
        {
            InitializeComponent();
        }
 
        private void 初始化菜单()
        {
            SQL.脚本 = "Exec p获取用户菜单 " + SQL.引号(SQL.操作员ID);
            DataTable dt = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "文本日志").Tables[0];
            SQL.创建树(SQL.DB.Report_DB, tv1, null, dt, "0", "名称");
            展开节点 = SQL.取值(SQL.DB.Report_DB, "Select 展开节点 from 用户菜单树 With (nolock) Where 用户ID=" + SQL.引号(SQL.操作员ID), "文本日志");
            if (展开节点 != "")
            {
                readNode(tv1.Nodes);
            }
            else
            {
                foreach (TreeNode tn in tv1.Nodes)
                {
                    if (tn.Text == "业务管理")
                    {
                        tn.Expand();
                        break;
                    }
                }
            }
            cbb日期.Text = "今天";
        }
 
        private void 初始化任务()
        {
            日期范围 = SQL.获取日期范围(cbb日期.Text);
            tv2.ExpandAll();
            gv任务汇总.IndicatorWidth = 0;
            刷新任务数();
            任务复位();
        }
 
        private void 初始化收藏()
        {
            foreach (TreeNode tn in tv2.Nodes)
            {
                if (tn.Name == "收藏")
                {
                    SQL.脚本 = "Select * from v用户收藏 With (Nolock) Where 用户ID=" + SQL.引号(SQL.操作员ID);
                    SQL.创建树(SQL.DB.Report_DB, tv2, tn, SQL.脚本, 1, true, "名称");
                    break;
                }
            }
        }

        private void 加载工作任务()
        {
            string 界面定位 = "系统.工作任务";
            System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(Application.StartupPath + "\\系统.dll");
            Type type = ass.GetType(界面定位);
            Object obj = Activator.CreateInstance(type);
            Form frmChild = (Form)obj;
            基本窗体 frm = (基本窗体)frmChild;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void 加载座位表()
        {
            string 界面定位 = "OA.座位表.座位表";
            System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(Application.StartupPath + "\\OA.dll");
            Type type = ass.GetType(界面定位);
            Object obj = Activator.CreateInstance(type);
            Form frmChild = (Form)obj;
            基本窗体 frm = (基本窗体)frmChild;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
 
        private void 任务复位()
        {
            sc任务汇总.Panel1Collapsed = true;      //任务汇总隐藏
            sc任务明细.Panel2Collapsed = true;      //任务表体隐藏
            sc任务.Panel2Collapsed = true;          //任务明细隐藏
            gc任务汇总.DataSource = null;
            gc任务.DataSource = null;
            gc任务表头.DataSource = null;
            gc任务表体.DataSource = null;
            gv任务表头.Columns.Clear();
            gv任务表体.Columns.Clear();
            lbl流程进度.Text = "";
        }
 
        private void tv1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            frmMain.打开界面(e.Node.Tag);
        }
 
        private void tv2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tv2单击(e.Node);
        }
 
        private void tv2单击(TreeNode tn)
        {
            //第一层节点处理
            if (tn.Level == 0)
            {
                if (tn.Name == "审批")
                {
                    tc1.SelectedTab = tp任务;
                    任务复位();
                }
                else if (tn.Name == "日志")
                {
                    tc1.SelectedTab = tp日志;
                }
                else if (tn.Name == "收藏")
                {
                    SQL.脚本 = "Select * from v用户收藏 With (Nolock) Where 用户ID=" + SQL.引号(SQL.操作员ID);
                    SQL.创建树(SQL.DB.Report_DB,tv2,tn,SQL.脚本,1,true,"名称");
                }
            }
 
            //第二层节点处理
            if (tn.Level == 1)
            {
                if (tn.Parent.Name == "审批")
                {
                    tc1.SelectedTab = tp任务;
                    任务复位();
 
                    if (tn.Name == "待处理")
                    {
                        #region 待处理
                        string 记录数 = "0";
                        string 流程数 = "0";
 
                        //获取待处理记录数和流程数
                        SQL.脚本 = "Select Count(fID) AS 记录数 ,Count(Distinct 流程ID) AS 流程数 from v任务 With (Nolock) "
                                    + " Where 参与者 = " + SQL.引号(SQL.操作员) + "And 待处理节点=节点 And 审批日期 IS NULL And 状态=1";
                        DataTable dt = SQL.查询(SQL.DB.Process_DB, SQL.脚本, "文本日志").Tables[0];
                        if (dt.Rows.Count == 1)
                        {
                            记录数 = dt.Rows[0]["记录数"].ToString();
                            流程数 = dt.Rows[0]["流程数"].ToString();
                        }
                        tn.Text = "待处理(" + 记录数 + ")";
 
                        if (Convert.ToInt32(流程数) <= 2)
                        {
                            sc任务汇总.Panel1Collapsed = true;
                            SQL.脚本 = "Select * from v任务 With (Nolock) Where 参与者=" + SQL.引号(SQL.操作员)
                                        + " And 待处理节点=节点"
                                        + " And 审批日期 IS NULL"
                                        + " And 状态=1"
                                        + " Order By fID Asc";
                            SQL.查询(SQL.DB.Process_DB, SQL.脚本, "文本日志", gv任务);
                            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv任务.Columns)
                            {
                                if (col.Name == "流程名称") col.Visible = true;
                                if (col.Name == "参与者") col.Visible = false;
                                if (col.Name == "发起人") col.Visible = true;
                                if (col.Name == "审批意见") col.Visible = false;
                                if (col.Name == "审批批注   ") col.Visible = false;
                                if (col.Name == "审批日期") col.Visible = false;
                            }
                        }
                        else
                        {
                            sc任务汇总.Panel1Collapsed = false;
                            SQL.脚本 = "Select 流程ID,流程名称 AS 流程,Count(fID) AS 数量 from v任务 With (Nolock) Where 参与者=" + SQL.引号(SQL.操作员)
                                        + " And 待处理节点=节点"
                                        + " And 审批日期 IS NULL"
                                        + " And 状态=1"
                                        + " Group By 流程ID,流程名称"
                                        + " Order By 流程";
                            SQL.查询(SQL.DB.Process_DB, SQL.脚本, "文本日志", gv任务汇总);
                            显示任务();
                        }
 
                        if (gv任务.RowCount > 0)
                        {
                            显示任务明细();
                        }
                        #endregion 待处理
                    }
                    else if (tn.Name == "待完成")
                    {
                        #region 待完成
                        SQL.脚本 = "Select * from v任务 With (Nolock) Where 发起人=" + SQL.引号(SQL.操作员)
                                    + " And 待处理节点=节点"
                                    + " And 审批日期 IS NULL"
                                    + " And 状态=1"
                                    + " Order By 表头ID Desc,节点 ASC";
                        SQL.查询(SQL.DB.Process_DB, SQL.脚本, "文本日志", gv任务);
                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv任务.Columns)
                        {
                            if (col.Name == "流程名称") col.Visible = true;
                            if (col.Name == "参与者") col.Visible = true;
                            if (col.Name == "发起人") col.Visible = false;
                            if (col.Name == "审批意见") col.Visible = false;
                            if (col.Name == "审批批注   ") col.Visible = false;
                            if (col.Name == "审批日期") col.Visible = false;
                        }
                        tn.Text = "待完成(" + gv任务.RowCount.ToString() + ")";
                        #endregion 待完成
                    }
                    else if (tn.Name == "已处理")
                    {
                        #region 已处理
                        SQL.脚本 = "Select * from v任务 With (Nolock) Where 参与者=" + SQL.引号(SQL.操作员)
                                    // + " And 待处理节点=节点"
                                    + " And 审批日期 between " + 日期范围
                                    + " Order By 审批日期 Desc";
 
                        SQL.查询(SQL.DB.Process_DB, SQL.脚本, "文本日志", gv任务);
                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv任务.Columns)
                        {
                            if (col.Name == "流程名称") col.Visible = true;
                            if (col.Name == "参与者") col.Visible = false;
                            if (col.Name == "发起人") col.Visible = true;
                            if (col.Name == "审批意见") col.Visible = true;
                            if (col.Name == "审批批注") col.Visible = true;
                            if (col.Name == "审批日期") col.Visible = true;
                        }
                        #endregion 已处理
                    }
                    else if (tn.Name == "已完成")
            {
                #region 已完成
                SQL.脚本 = "Select * from v任务 With (Nolock) Where 发起人=" + SQL.引号(SQL.操作员)
                            + " And 状态=2"
                            + " And 待处理节点 = 节点"
                            + " And 完成日期 between " + 日期范围
                            + " Order By 表头ID Desc,节点 ASC";
 
                SQL.查询(SQL.DB.Process_DB, SQL.脚本, "文本日志", gv任务);
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv任务.Columns)
                {
                    if (col.Name == "流程名称") col.Visible = true;
                    if (col.Name == "参与者") col.Visible = true;
                    if (col.Name == "发起人") col.Visible = false;
                    if (col.Name == "审批意见") col.Visible = true;
                    if (col.Name == "审批批注") col.Visible = true;
                    if (col.Name == "审批日期") col.Visible = true;
                }
                #endregion 已完成
            }
            else if (tn.Name == "已中止")
            {
                #region 已中止
                SQL.脚本 = "Select * from v任务 With (Nolock) Where 发起人=" + SQL.引号(SQL.操作员)
                            + " And 状态=-1"
                            + " And 待处理节点 = 节点"
                            + " And 完成日期 between " + 日期范围
                            + " Order By 表头ID Desc,节点 ASC";
 
                SQL.查询(SQL.DB.Process_DB, SQL.脚本, "文本日志", gv任务);
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv任务.Columns)
                {
                    if (col.Name == "流程名称") col.Visible = true;
                    if (col.Name == "参与者") col.Visible = true;
                    if (col.Name == "发起人") col.Visible = false;
                    if (col.Name == "审批意见") col.Visible = true;
                    if (col.Name == "审批批注") col.Visible = true;
                    if (col.Name == "审批日期") col.Visible = true;
                }
                #endregion 已中止
            }
        }
        else if (tn.Parent.Name == "日志")
        {
            tc1.SelectedTab = tp日志;
 
            if (tn.Name == "成功")
            {
                SQL.脚本 = "Select * from v日志 With (Nolock) Where 结果 = '成功'"
                            + " And 用户 = " + SQL.引号(SQL.操作员)
                            + " And 日期 Between " + SQL.获取日期范围(cbb日期.Text)
                            + " Order By fID Desc";
            }
            else if (tn.Name == "失败")
            {
                SQL.脚本 = "Select * from v日志 With (Nolock) Where 结果 <> '成功'"
                        + " And 用户 = " + SQL.引号(SQL.操作员)
                        + " And 日期 Between " + SQL.获取日期范围(cbb日期.Text)
                        + " Order By fID Desc";
            }
            else if (tn.Name == "超时")
            {
                SQL.脚本 = "Select * from v日志 With (Nolock) Where 执行时间 > 30"
                       + " And 用户 = " + SQL.引号(SQL.操作员)
                       + " And 日期 Between " + SQL.获取日期范围(cbb日期.Text)
                       + " Order By fID Desc";
            }
 
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "文本日志", gv日志);
        }
        else if (tn.Parent.Name == "收藏")
        {
            frmMain.打开界面(tn.Tag);
        }
    }        
}
 
        private void gc日志_Click(object sender, EventArgs e)
        {
            if (gv日志.RowCount == 0) return;
            string 描述 = gv日志.GetFocusedDataRow()["描述"].ToString();
            string 脚本 = gv日志.GetFocusedDataRow()["脚本"].ToString();
            string 结果 = gv日志.GetFocusedDataRow()["结果"].ToString();
         
            if (描述 != "") 描述 += "\r\n";
            if (脚本 != "") 脚本 += "\r\n";
         
            txt日志.Text = 描述 + 脚本 + 结果;
        }
         
        private void cbb日期_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Report_DB, cbb日期, "Select 名称 from v日期周期 With (Nolock)", false); 
        }
         
        private void 工作中心_Shown(object sender, EventArgs e)
        {
            初始化菜单();
            初始化任务();
            初始化收藏(); 
            //string 用户默认标签;
            //用户默认标签 = SQL.取值(SQL.DB.Report_DB, "Select 标签 from 用户默认任务标签 With (Nolock) Where 用户ID = " + SQL.引号(SQL.操作员ID) + " And 窗体=" + SQL.引号(this.Name), "文本日志");
            //if (用户默认标签 == "") 用户默认标签 = "5";
            //tc1.SelectedIndex = Convert.ToInt16(用户默认标签);
        }
         
        private void 显示任务()
        { 
            if (gv任务汇总.RowCount == 0) return;
         
            SQL.脚本 = "Select * from v任务 With (Nolock) Where 参与者="+SQL.引号(SQL.操作员)
              +" And 待处理节点 = 节点"
              +" And 审批日期 IS NULL"
              +" And 流程ID = "+SQL.引号(gv任务汇总.GetFocusedDataRow()["流程ID"].ToString())
              +" And 状态=1"
              +" Order By fID";
            SQL.查询(SQL.DB.Process_DB,SQL.脚本,"文本日志",gv任务);
         
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv任务.Columns)
            {
                if (col.Name == "流程名称") col.Visible = true;
                if (col.Name == "参与者") col.Visible = false;
                if (col.Name == "发起人") col.Visible = true;
                if (col.Name == "审批意见") col.Visible = false;
                if (col.Name == "审批批注") col.Visible = false;
                if (col.Name == "审批日期") col.Visible = false;
            }
        }
         
        private void gc任务汇总_Click(object sender, EventArgs e)
        {
            显示任务();
        }
         
        private void 显示任务明细()
        {
            if (gv任务.RowCount == 0) return;
         
            sc任务.Panel2Collapsed = false;
            string 表头ID = gv任务.GetFocusedDataRow()["表头ID"].ToString();
            string 单号 = gv任务.GetFocusedDataRow()["单号"].ToString();
         
            DataTable dt流程实例 = SQL.查询(SQL.DB.Process_DB, "Select * from v流程实例表头 With (Nolock) Where fID=" + SQL.引号(表头ID),"文本日志").Tables[0];
            if (dt流程实例.Rows.Count == 0)
            {
                消息.提示("流程实例已处理,请刷新界面");
                任务复位();
                刷新任务数();
                return;
            }
            string 数据库 = dt流程实例.Rows[0]["数据库"].ToString();
            string 视图 = dt流程实例.Rows[0]["视图"].ToString();
            string 明细视图 = dt流程实例.Rows[0]["明细视图"].ToString();
            string 流程ID = dt流程实例.Rows[0]["流程ID"].ToString();
         
            #region 装载字段
            if (视图 != "")
            {
                gv任务表头.Columns.Clear();
                SQL.脚本 = "Select * from v流程定义视图 With (Nolock) Where 表头ID=" + SQL.引号(流程ID)+" And 视图="+SQL.引号(视图)+" Order By 排序";
                using (DataTable dt表头字段 = SQL.查询(SQL.DB.Process_DB, SQL.脚本, "文本日志").Tables[0])
                {
                    if (dt表头字段 == null) return;
                    foreach (DataRow dr in dt表头字段.Rows)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn col = gv任务表头.Columns.Add();
                        col.Width = Convert.ToInt16(dr["长度"].ToString());
                        col.Name = dr["字段"].ToString();
                        col.FieldName = dr["字段"].ToString();
                        col.Caption = dr["字段"].ToString();
                        col.Visible = Convert.ToBoolean(dr["是否可见"]);
                    }
         
                    SQL.脚本 = "Select * from "+ 视图 + " With (Nolock) Where 单号=" + SQL.引号(单号) + " Order by 1";
                    SQL.查询((SQL.DB)Enum.Parse(typeof(SQL.DB), 数据库), SQL.脚本, "查询" + 视图,gv任务表头);
                }
            }
         
            if (明细视图 != "")
            {
                gv任务表体.Columns.Clear();
                SQL.脚本 = "Select * from v流程定义视图 With (Nolock) Where 表头ID=" + SQL.引号(流程ID) + " And 视图=" + SQL.引号(明细视图) + " Order By 排序";
                using (DataTable dt表体字段 = SQL.查询(SQL.DB.Process_DB, SQL.脚本, "文本日志").Tables[0])
                {
                    if (dt表体字段 == null) return;
                    foreach (DataRow dr in dt表体字段.Rows)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn col = gv任务表体.Columns.Add();
                        col.Width = Convert.ToInt16(dr["长度"].ToString());
                        col.Name = dr["字段"].ToString();
                        col.FieldName = dr["字段"].ToString();
                        col.Caption = dr["字段"].ToString();
                        col.Visible = Convert.ToBoolean(dr["是否可见"]);
                    }
 
                    SQL.脚本 = "Select * from " + 明细视图 + " With (Nolock) Where 单号=" + SQL.引号(单号) + " Order by 1";
                    SQL.查询((SQL.DB)Enum.Parse(typeof(SQL.DB), 数据库), SQL.脚本, "查询" + 明细视图, gv任务表体);
                    sc任务明细.Panel2Collapsed = false;
                }
            }
            else
            {
                sc任务明细.Panel2Collapsed = true;
            }
            #endregion 装载字段
         
            lbl流程进度.Text = "流程进度:" + SQL.取值(SQL.DB.Process_DB,"Select dbo.f获取流程进度(" + SQL.引号(表头ID) + ",0) AS 进度","文本日志");
            string 流程进度 = SQL.取值(SQL.DB.Process_DB, "Select dbo.f获取流程进度(" + SQL.引号(表头ID) + ",1) AS 进度", "文本日志");
            string 流程内容 = gv任务.GetFocusedDataRow()["内容"].ToString();
            tip.SetToolTip(lbl流程进度, 流程进度);
            tip.SetToolTip(gc任务, 流程内容);
        }
 
        private void gc任务_Click(object sender, EventArgs e)
        {
            显示任务明细();
        }
 
        private void btn单证_Click(object sender, EventArgs e)
        {
            int intRow = gv任务.FocusedRowHandle;
            显示单证();
            if (tv2.SelectedNode != null) tv2单击(tv2.SelectedNode);
            //tv2单击(tv2.Nodes[0].Nodes[0]);
            刷新任务数();

            if (intRow > 60) gv任务.FocusedRowHandle = gv任务.RowCount - 1;
            if (intRow > (gv任务.RowCount - 1)) intRow = gv任务.RowCount - 1;

            gv任务.SelectRow(intRow);
            gv任务.FocusedRowHandle = intRow;
        }
 
        private void btn确认_Click(object sender, EventArgs e)
        {
            if (gv任务.GetSelectedRows().Length == 0)
            {
                消息.提示("请选择要审批的流程");
                return;                
            }

            string 审批意见="";
            if (rb同意.Checked) 审批意见 = "确认";
            if (rb驳回.Checked) 审批意见 = "驳回";

            if (审批意见 == "确认")
            {
                if (!消息.提示选择("是否确认审批通过", MessageBoxIcon.Warning)) return;
            }
 
            if (审批意见 != "确认" & txt批注.Text == "")
            {
                消息.提示("请输入批注");
                return;
            }

            int intRow = gv任务.FocusedRowHandle;
            foreach (int i in gv任务.GetSelectedRows())
            {
                SQL.脚本 = "Exec p流程审批 " + SQL.引号(gv任务.GetDataRow(i)["fID"].ToString()) + ","
                                                + SQL.引号(SQL.操作员) + ","
                                                + SQL.引号(审批意见) + ","
                                                + SQL.引号(txt批注.Text) + ","
                                                + "1";
 
                SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程审批");
                if (SQL.结果 != "成功")
                {
                    消息.提示("操作" + SQL.结果);
                    刷新任务数();
                    return;
                }
            }
            消息.提示("操作" + SQL.结果);
            gv任务.DeleteSelectedRows();
            txt批注.Text = "";
            //if (tv2.SelectedNode != null) tv2单击(tv2.SelectedNode);
            刷新任务数();
            gc任务表头.DataSource = null;
            gc任务表体.DataSource = null;

            //if (intRow > 60) gv任务.FocusedRowHandle = gv任务.RowCount - 1;
            //if (intRow > (gv任务.RowCount - 1)) intRow = gv任务.RowCount - 1;

            //gv任务.SelectRow(intRow);
            //gv任务.FocusedRowHandle = intRow;
        }
 
        private void tm任务_Tick(object sender, EventArgs e)
        {
            刷新任务数();
        }
 
        private void 刷新任务数()
        {
            try
            {
                if (SQL.连接状态 == true & SQL.当前窗体 == "工作中心")
                {
                    string 待处理数 = SQL.取值(SQL.DB.Process_DB, "Select Count(fID) from v任务 With (Nolock) Where 参与者=" + SQL.引号(SQL.操作员) + " And 待处理节点=节点 And 审批日期 IS NULL And 状态=1", "文本日志");
                    string 待完成数 = SQL.取值(SQL.DB.Process_DB, "Select Count(fID) from v任务 With (Nolock) Where 发起人=" + SQL.引号(SQL.操作员) + " And 待处理节点=节点 And 审批日期 IS NULL And 状态=1", "文本日志");
                    tv2.Nodes[0].Nodes[0].Text = "待处理(" + 待处理数 + ")"; //待处理
                    tv2.Nodes[0].Nodes[1].Text = "待完成(" + 待完成数 + ")"; //待完成
                    if (tv2.Nodes[0].Nodes[0].Text == "待处理(0)")
                    {
                        tm任务.Interval = 60000;
                    }
                    else
                    {
                        tm任务.Interval = 120000;
                    }
                }
            }
            catch{ }
        }
 
        private void cbb日期_SelectedIndexChanged(object sender, EventArgs e)
        {
            日期范围 = SQL.获取日期范围(cbb日期.Text);
        }
 
        private void 显示单证()
        {
            if (gv任务.RowCount == 0) return;
            try
            {
                string 模块 = gv任务.GetFocusedDataRow()["模块"].ToString();
                if (模块 == "") return;
                string 项目 = SQL.获取符号前字符串(模块, ".") + ".dll"; ;
                string 窗体名称 = gv任务.GetFocusedDataRow()["单证"].ToString();
                System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(Application.StartupPath + "\\" + 项目);
                Type type = ass.GetType(模块);
                Object obj = Activator.CreateInstance(type);
                Form frmChild = (Form)obj;
                基本窗体 frm = (基本窗体)frmChild;
                frm.Text = 窗体名称;
                frm.工作流 = gv任务.GetFocusedDataRow();

                string 是否全屏 = SQL.取值(SQL.DB.Process_DB, "Select 全屏显示 from 流程定义表头 With (Nolock) Where fID=" + SQL.引号(gv任务.GetFocusedDataRow()["流程ID"].ToString()), "文本日志");
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
 
        private void gc任务_DoubleClick(object sender, EventArgs e)
        {
            btn单证.PerformClick();
        }
 
        #region 收藏夹拖放
        private void tv1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move);
        }
 
        private void tv2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
 
        private void tv2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                //获得进行"Drag"操作中拖动的字符串  
                TreeNode tn = (TreeNode)e.Data.GetData(typeof(TreeNode));
                 
                if ((tn.Tag as DataRow)["是否末级"].ToString() == "1")
                {
                    string 菜单ID = (tn.Tag as DataRow)["fID"].ToString();
                    SQL.脚本 = "Exec p用户收藏新增 " + SQL.引号(SQL.操作员ID) + "," + SQL.引号(菜单ID);
                    SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "用户收藏新增");
                    if (SQL.结果 != "成功")
                    {
                        消息.提示("操作" + SQL.结果);
                        return;
                    }
                    初始化收藏();
                }
            }
        }
 
        private void tv2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move);
        }
 
        private void tv1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
 
        private void tv1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode tn = (TreeNode)e.Data.GetData(typeof(TreeNode));
 
                if (tn.Level == 1 & tn.Parent.Name == "收藏")
                {
                    string 菜单ID = (tn.Tag as DataRow)["fID"].ToString();
                    SQL.脚本 = "Exec p用户收藏删除 " + SQL.引号(SQL.操作员ID) + "," + SQL.引号(菜单ID);
                    SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "用户收藏删除");
                    if (SQL.结果 != "成功")
                    {
                        消息.提示("操作" + SQL.结果);
                        return;
                    }
                    初始化收藏();
                }
            }
        }
 
        private void tv2_MouseClick(object sender, MouseEventArgs e)
        {
 
        }
        #endregion 
 
        //private void lv功能_DoubleClick(object sender, EventArgs e)
        //{
        //    frmMain.打开界面(lv功能.SelectedItems[0].Tag);
        //}
 
        #region 用户菜单树
        private void 工作中心_FormClosed(object sender, FormClosedEventArgs e)
        {
            展开节点 = "";
            saveNode(tv1.Nodes);
            SQL.脚本 = "Exec p用户菜单树保存 " + SQL.引号(SQL.操作员ID) + "," + SQL.引号(展开节点);
            SQL.执行(SQL.DB.Report_DB, SQL.脚本, "文本日志");   
        }
 
        private void saveNode(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
            {
                if (node.Nodes.Count > 0)
                {
                    if (node.IsExpanded) 展开节点 += "<" + (node.Tag as DataRow)["fID"].ToString() + ">";
                    saveNode(node.Nodes);
                }
            }
        }
 
        private void readNode(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
            {
                if (node.Nodes.Count > 0)
                {
                    if (展开节点.IndexOf("<" + (node.Tag as DataRow)["fID"].ToString() + ">") > -1)
                    {
                        node.Expand();
                    }
                    readNode(node.Nodes);
                }
            }
        }
 
        #endregion

        private void tc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tc1.SelectedTab == tp工作)
            //{
                //if (tp工作.Controls.Count == 0) 加载工作任务();
            //}
            //else if (tc1.SelectedTab == tp座位表)
            //{
                //加载座位表();
            //}
            //SQL.脚本 = "Exec p用户默认任务标签保存 " + SQL.引号(SQL.操作员ID) + "," + SQL.引号(this.Name) + "," + SQL.引号(tc1.SelectedIndex.ToString());
            //SQL.执行(SQL.DB.Report_DB, SQL.脚本, "文本日志");
        }

        private void btn转发_Click(object sender, EventArgs e)
        {
            if (tv2.SelectedNode.Level == 1)
            {
                if (tv2.SelectedNode.Name == "待处理")
                {
                    if (gv任务.RowCount == 0) return;

                    if (this.gv任务.GetSelectedRows().Length <= 0) return;
                    DataRow dr = gv任务.GetFocusedDataRow();
                    //流程转发 转发 = new 流程转发(dr["fid"].ToString(), dr["表头ID"].ToString());
                    //转发.ShowDialog();
                }
            }
        }
    }
}