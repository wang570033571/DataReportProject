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
    public partial class 查看密码 : Form
    {
        public string 加密密码 = "";

        public 查看密码()
        {
            InitializeComponent();
            this.Load += new EventHandler(查看密码_Load);
        }

        void 查看密码_Load(object sender, EventArgs e)
        {
            try
            {
                txt密码.Text = 框架.加密解密.解密(加密密码, "sfiecpmc");
            }
            catch (Exception ex)
            {
                消息.显示(ex, ex.Message);
            }
        }
    }
}
