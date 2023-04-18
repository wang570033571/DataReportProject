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
    public partial class 首次登陆 : Form
    {
        public string 登陆名 = "";

        public 首次登陆()
        {
            InitializeComponent();
        }

        private void btn确认_Click(object sender, EventArgs e)
        {
            if (txt新密码.Text == "")
            {
                消息.提示("新密码不能为空");
                return;
            }

            if (txt确认新密码.Text == "")
            {
                消息.提示("确认新密码不能为空");
                return;
            }

            SQL.结果 = SQL.取值(SQL.DB.Report_DB, "Select dbo.f校验密码合法性(" + SQL.引号(txt新密码.Text) + ")", "不记日志");
            if (SQL.结果 != "")
            {
                消息.提示(SQL.结果);
                return;
            }
            string 密钥 = "sfiecpmc";
            SQL.脚本 = "Exec p首次登陆设置 " + SQL.引号(登陆名) + ","
                                                + SQL.引号(加密解密.加密(txt新密码.Text, 密钥)) + ","
                                                + SQL.引号(加密解密.加密(txt确认新密码.Text, 密钥));
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "首次登陆设置");
            消息.提示("操作" + SQL.结果);
            if (SQL.结果 == "成功")
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                return;
            }
        }

        private void btn取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
