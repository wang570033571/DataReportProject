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
    public partial class 日志查询 : 基本查询窗体
    {
        public 日志查询()
        {
            InitializeComponent();
            this.Load += new EventHandler(日志查询_Load);
        }

        void 日志查询_Load(object sender, EventArgs e)
        {
            txt用户.Text = SQL.操作员;
            txt开始日期.Text = SQL.当前时间().ToShortDateString();
        }

        public void 查询()
        {
            SQL.脚本 = SQL.获取查询脚本(panel1) + "Order By fID Desc";
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询日志", gv1);
        }

        private void gc1_Click(object sender, EventArgs e)
        {
            if (gv1.RowCount == 0) return;
            string 描述 = gv1.GetFocusedDataRow()["描述"].ToString();
            string 脚本 = gv1.GetFocusedDataRow()["脚本"].ToString();
            string 结果 = gv1.GetFocusedDataRow()["结果"].ToString();

            if (描述!="") 描述+="\r\n";
            if (脚本 != "") 脚本 += "\r\n";
            if (结果 != "") 结果 += "\r\n";

            txt1.Text = 描述 + 脚本 +  结果;
        }
    }
}
