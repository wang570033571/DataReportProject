using System;
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
    public partial class 退出系统 : 基本窗体
    {
        public 退出系统()
        {
            InitializeComponent();
        }

        private void btn确认_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btn取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn注销_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            Close();
        }
    }
}
