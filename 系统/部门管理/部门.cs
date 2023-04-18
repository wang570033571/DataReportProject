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
    public partial class 部门 : 基本查询窗体
    {
        public 部门()
        {
            InitializeComponent();
            gv1.Tag = "v部门";
        }

        public void 查询()
        {
            SQL.脚本 = SQL.获取查询脚本(panel1);
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询部门信息", gv1);
        }

        public void 新增()
        {
            using (部门_新增 Frm新增 = new 部门_新增())
            {
                Frm新增.ShowDialog();
                this.查询();
            }
        }

        public void 编辑()
        {
            using (部门_新增 Frm新增 = new 部门_新增())
            {
                Frm新增.fID = gv1.GetFocusedDataRow()["fid"].ToString();
                Frm新增.ShowDialog();
                this.查询();
            }
        }
    }
}
