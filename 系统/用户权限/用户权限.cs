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
    public partial class 用户权限 : 基本查询窗体
    {
        public 用户权限()
        {
            InitializeComponent();
            this.Load += new EventHandler(用户权限_Load);
        }

        void 用户权限_Load(object sender, EventArgs e)
        {
            查询();
        }

        public void 查询()
        {
            SQL.脚本 = SQL.获取查询脚本(panel1);
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询用户信息", gv1);
        }

        public void 新增()
        {
            using (用户_新增 Frm新增 = new 用户_新增())
            {
                Frm新增.ShowDialog();
                this.查询();
            }
        }

        public void 编辑()
        {
            using (用户_新增 Frm新增 = new 用户_新增())
            {
                Frm新增.fID = gv1.GetFocusedDataRow()["fid"].ToString();
                Frm新增.ShowDialog();
                this.查询();
            }
        }

        public void 权限()
        {
            if (gv1.GetFocusedDataRow()["名称"].ToString() != SQL.操作员 && gv1.GetFocusedDataRow()["岗位"].ToString() == "系统管理员")
            {
                消息.提示("您不能为系统管理员分配权限!");
                return;
            }
            using (权限分配 frm = new 权限分配())
            {
                frm.用户ID = gv1.GetFocusedDataRow()["fID"].ToString();

                frm.ShowDialog();
            }
        }


        public void 查看密码()
        {
            if (gv1.GetFocusedDataRow()["名称"].ToString() != SQL.操作员 && gv1.GetFocusedDataRow()["岗位"].ToString() == "系统管理员")
            {
                消息.提示("您不能查看系统管理员的密码!");
                return;
            }

            查看密码 Frm密码 = new 查看密码();
            Frm密码.加密密码 = gv1.GetFocusedDataRow()["密码"].ToString();
            Frm密码.ShowDialog();
        }


        public void 重置密码()
        {
            if (gv1.GetFocusedDataRow()["名称"].ToString() != SQL.操作员 && gv1.GetFocusedDataRow()["岗位"].ToString() == "系统管理员")
            {
                消息.提示("您不能重置系统管理员的密码!");
                return;
            }
            string 密钥 = "sfiecpmc";
            SQL.脚本 = "Exec p密码重置 " + SQL.引号(gv1.GetFocusedDataRow()["fid"].ToString()) + ","
                                         + SQL.引号(框架.加密解密.加密("123456", 密钥));
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "不记日志");
            消息.提示("操作" + SQL.结果 + ",用户【" + gv1.GetFocusedDataRow()["名称"].ToString() + "】的密码已经重置为：123456");
            if (SQL.结果 == "成功")
            {
                this.DialogResult = DialogResult.OK;
                this.查询();
            }
            else
            {
                return;
            }
        }
    }
}
