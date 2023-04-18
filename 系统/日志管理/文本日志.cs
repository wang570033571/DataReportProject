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
    public partial class 文本日志 : 基本查询窗体
    {
        public 文本日志()
        {
            InitializeComponent();
            this.Load += new EventHandler(文本日志_Load);
        }

        void 文本日志_Load(object sender, EventArgs e)
        {
            dtp1.Value = SQL.当前时间();
            查询();
        }

        public void 查询()
        {
            try
            {
                DateTime 选中日期 = dtp1.Value;
                string 文件名 = 选中日期.Year.ToString() + "-" + 选中日期.Month.ToString() + "-" + 选中日期.Day.ToString() + ".txt";
                txt1.Text = 文件操作.日志查看(文件名);
            }
            catch
            {
                txt1.Text = "没有日志";
            }
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            查询();
        }
    }
}
