using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using 框架;

namespace ERP
{
    /// <summary>
    /// 登陆界面
    /// </summary>
    public partial class 登陆界面 : Form
    {
        public 登陆界面()
        {
            InitializeComponent();
            this.Load += new EventHandler(登陆界面_Load);
            //this.Activated += new EventHandler(登陆界面_Activated);
        }

        //void 登陆界面_Activated(object sender, EventArgs e)
        //{
            //txt用户.Text = 框架.配置文件.读取("登陆名", "");

            //if (txt用户.Text != "")
            //{
            //    txt密码.Focus();
            //}
            //else
            //{
            //    txt用户.Focus();
            //}
        //}

        void 登陆界面_Load(object sender, EventArgs e)
        {
            try
            {
                string 服务器类型 = 框架.配置文件.读取("服务器", "");
                txt用户.Text = 框架.配置文件.读取("登陆名", "");
                if (服务器类型 == "10.10.1.250")
                {
                    rdb内网.Checked = true;
                }

                if (服务器类型 == "124.74.105.182")
                {
                    rdb外网.Checked = true;
                }
            }
            catch { };
        }

        private void btn登陆_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb内网.Checked)
                {
                    SQL.服务器 = "DESKTOP-B2EKLIB";
                    SQL.用户名 = "sa";
                    SQL.密码 = "sa";
                }
                else if (rdb外网.Checked)
                {
                    SQL.服务器 = "DESKTOP-B2EKLIB";
                    SQL.用户名 = "sa";
                    SQL.密码 = "sa";
                }

                Cursor.Current = Cursors.WaitCursor;
                if (txt用户.Text == "")
                {
                    消息.提示("用户名不能为空!");
                    return;
                }

                string 登陆状态 = "";
                string 密钥 = "sfiecpmc";
                string 密码 = 加密解密.加密(txt密码.Text, 密钥);


                if (rdb内网.Checked)
                {
                    if (SQL.服务器连接() == false)
                    {
                        消息.提示("【内网】连接失败,请切换至【外网】登陆!");
                        return;
                    }
                }
                else if (rdb外网.Checked)
                {
                    if (SQL.服务器连接() == false)
                    {
                        消息.提示("【外网】连接失败,请切换至【内网】登陆!");
                        return;
                    }
                }

                //校验
                SQL.脚本 = "Select dbo.f登陆校验(" + SQL.引号(txt用户.Text) + ","
                                                   + SQL.引号(密码) +","
                                                   + SQL.引号(SQL.获取机器名()) + ")";
                登陆状态 = SQL.取值(SQL.DB.Report_DB, SQL.脚本, "不记日志");

                SQL.脚本 = "Exec p登陆日志新增 "
                            + SQL.引号(txt用户.Text) + ","
                            + SQL.引号(登陆状态);
                SQL.执行(SQL.DB.Report_DB, SQL.脚本, "文本日志");

                if (登陆状态 == "成功")
                {
                    登陆成功();
                }
                else
                {
                    //校验失败
                    消息.提示(登陆状态);
                    txt密码.Focus();
                    if (登陆状态 == "请设置初始密码")
                    {
                        using (首次登陆 frm = new 首次登陆())
                        {
                            frm.登陆名 = txt用户.Text;
                            SQL.操作员 = SQL.取值(SQL.DB.Report_DB, "select 名称 from 用户 with (nolock) where 登陆名='" + txt用户.Text + "'", "根据登陆名获取操作员名称");
                            frm.ShowDialog();
                            if (frm.DialogResult == DialogResult.OK)
                            {
                                登陆成功();
                            }
                        }
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void 登陆成功()
        {

            //设置全局变量
            SQL.登陆名 = txt用户.Text;
            SQL.脚本 = "Select * from v用户 With (Nolock) Where 登陆名=" + SQL.引号(SQL.登陆名);
            DataSet ds用户 = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "文本日志");
            if (ds用户.Tables[0].Rows.Count == 0) return;
            using (DataTable dt = ds用户.Tables[0])
            {
                SQL.操作员ID = dt.Rows[0]["fID"].ToString();
                SQL.操作员 = dt.Rows[0]["名称"].ToString();
                SQL.部门 = dt.Rows[0]["部门"].ToString();
                SQL.部门ID = dt.Rows[0]["部门ID"].ToString();
                SQL.岗位.Add(SQL.操作员ID, dt.Rows[0]["岗位"].ToString());
            }

            //校验成功
            try
            {
                框架.配置文件.写入("登陆名", txt用户.Text);
                框架.配置文件.写入("服务器", SQL.服务器);
            }
            catch { };
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void txt用户_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) txt密码.Focus();
        }

        private void txt密码_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) btn登陆.PerformClick();
        }

        private void btn取消_Click(object sender, EventArgs e)
        {
            Application.Exit();            
        }

    }
}
