using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 框架
{
    public partial class 输入框 : Form
    {
        public string 返回值 = "";

        public 输入框()
        {
            InitializeComponent();
        }

        private void btn确认_Click(object sender, EventArgs e)
        {
            if (txt1.Text.Trim().Length <= 0)
            {
                消息.提示("请输入内容！");
                return;
            }

            返回值 = txt1.Text;
            Close();
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn确认.PerformClick();
            }
        }
    }
}
