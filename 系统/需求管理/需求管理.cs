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
    public partial class 需求管理 : 基本查询窗体
    {
        public 需求管理()
        {
            InitializeComponent();
            this.Load += new EventHandler(需求管理_Load);
            gv1.Tag = "v需求管理";
            cmb日期.Tag = "制单日期 between @值";
            txt标题.Tag = "标题 Like \'%@值%\'";
            txt开发人.Tag = "开发人 = @值";
            cmb状态.Tag = "状态=@值";
            设置记录数显示();
        }

        void 需求管理_Load(object sender, EventArgs e)
        {
            cmb日期.Text = "本周";
            查询();
        }

        public void 查询()
        {
            SQL.脚本 = SQL.获取查询脚本(panel1, intCount.ToString());
            SQL.脚本 += " Order By fID Desc";
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询需求管理信息", gv1);
        }

        public void 新增()
        {
            using (需求管理_编辑 frm编辑 = new 需求管理_编辑())
            {
                if (frm编辑.ShowDialog() == DialogResult.Yes) 查询();
            }
        }

        public void 编辑()
        {
            if (gv1.RowCount == 0) return;
            using (需求管理_编辑 frm编辑 = new 需求管理_编辑())
            {
                frm编辑.fID = gv1.GetFocusedDataRow()["fID"].ToString();
                if (frm编辑.ShowDialog() == DialogResult.Yes) 查询();
            }
        }

        public void 删除()
        {
            SQL.脚本 = "Exec p需求管理删除 " + SQL.引号(gv1.GetFocusedDataRow()["fID"].ToString()) + ","
                                             + SQL.引号(SQL.操作员);
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "需求管理删除");
            消息.提示("操作" + SQL.结果);
            if (SQL.结果 == "成功") 查询();
        }

        public void 任务下发()
        {
            if (gv1.GetSelectedRows().Length < 1) return;
            SQL.脚本 = "Exec p需求下发 " + SQL.引号(gv1.GetFocusedDataRow()["fID"].ToString()) + ","
                                         + SQL.引号(SQL.操作员);
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "需求下发");
            if (SQL.结果 == "成功")
            {
                bool blTrue = SQL.发起审批流程("1", gv1.GetFocusedDataRow()["描述"].ToString(), gv1.GetFocusedDataRow()["fID"].ToString());
                if (blTrue == true)
                {
                    消息.提示("需求下发" + SQL.结果);
                    this.查询();
                }
            }
        }

        private void cmb日期_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Report_DB, cmb日期, "Select 名称 from v日期周期 With (Nolock) Where ISNULL(备注,'') = '' Order By fID", false);
        }

        private void cmb状态_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Report_DB, cmb状态, "Select '新录入' 名称 union Select '处理中' 名称 union Select '已完成' 名称 ", false);
        }

        private void gv1_Click(object sender, EventArgs e)
        {
            if (gv1.GetSelectedRows().Length < 1) return;
            DataRow dr = gv1.GetFocusedDataRow();
            txt描述.Text = dr["描述"].ToString();
            string 流程实例ID = SQL.取值(SQL.DB.Process_DB, "Select dbo.f获取流程实例ID(1,"+SQL.引号(dr["fid"].ToString())+")", "获取需求下发流程实例ID");
            lbl流程进度.Text = "流程进度:" + SQL.取值(SQL.DB.Process_DB, "Select dbo.f获取流程进度(" + 流程实例ID + ",0) AS 进度", "文本日志");
        }
    }
}
