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
    public partial class 密码设置 : 基本窗体
    {
        public string 登陆名 = "";

        public 密码设置()
        {
            InitializeComponent();
            this.Load += new EventHandler(密码设置_Load);
        }

        void 密码设置_Load(object sender, EventArgs e)
        {
            if (登陆名 == "") 登陆名 = SQL.取值(SQL.DB.Report_DB, "select 登陆名 from 用户 where fid=" + SQL.操作员ID + "", "获取登陆名");
            SQL.脚本 = "Select 密码 from 用户 With (Nolock) Where 登陆名=" + SQL.引号(登陆名);
            string 旧密码 = SQL.取值(SQL.DB.Report_DB,SQL.脚本,"不记日志");

            txt旧密码.Text = 框架.加密解密.解密(旧密码, "sfiecpmc");
        }

        private void btn确认_Click(object sender, EventArgs e)
        {
            SQL.结果 = SQL.取值(SQL.DB.Report_DB,"Select dbo.f校验密码合法性("+SQL.引号(txt新密码.Text)+")","不记日志");
            if (SQL.结果 != "")
            {
                消息.提示(SQL.结果);
                return;            
            }
            string 密钥 = "sfiecpmc";
            SQL.脚本 = "Exec p密码设置 " + SQL.引号(登陆名) + ","
                                         + SQL.引号(框架.加密解密.加密(txt旧密码.Text, 密钥)) + ","
                                         + SQL.引号(框架.加密解密.加密(txt新密码.Text, 密钥)) + ","
                                         + SQL.引号(框架.加密解密.加密(txt确认新密码.Text, 密钥));
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "不记日志");
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
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txt旧密码_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txt新密码.Focus();
            }
        }

        private void txt新密码_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SQL.结果 = SQL.取值(SQL.DB.Report_DB, "Select dbo.f校验密码合法性(" + SQL.引号(txt新密码.Text) + ")", "不记日志");
                if (SQL.结果 != "")
                {
                    消息.提示(SQL.结果);
                    return;
                }
                txt确认新密码.Focus();
            }
        }

        private void txt确认新密码_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SQL.结果 = SQL.取值(SQL.DB.Report_DB, "Select dbo.f校验密码合法性(" + SQL.引号(txt确认新密码.Text) + ")", "不记日志");
                if (SQL.结果 != "")
                {
                    消息.提示(SQL.结果);
                    return;
                }
                btn确认.PerformClick();
            }
        }
    }
}
