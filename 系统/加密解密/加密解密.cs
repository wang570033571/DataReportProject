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
    public partial class 加密解密 : 基本窗体
    {
        public 加密解密()
        {
            InitializeComponent();
            this.Activated += new EventHandler(加密解密_Activated);
        }

        void 加密解密_Activated(object sender, EventArgs e)
        {
            txt转换前.Focus();
        }

        private void btn加密_Click(object sender, EventArgs e)
        {
            try
            {
                txt转换后.Text = 框架.加密解密.加密(txt转换前.Text, txt密钥.Text);
            }
            catch (Exception ex)
            {
                消息.显示(ex, ex.Message);
            }
        }

        private void btn解密_Click(object sender, EventArgs e)
        {
            try
            {
                txt转换后.Text = 框架.加密解密.解密(txt转换前.Text, txt密钥.Text);
            }
            catch (Exception ex)
            {
                消息.显示(ex, ex.Message);
            }
        }
    }
}
