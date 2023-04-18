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
    public partial class 菜单_新增 : 基本查询窗体
    {
        public string fID = "0";
        public string 上级ID = "";

        public 菜单_新增()
        {
            InitializeComponent();
            this.Load += new EventHandler(菜单_新增_Load);
        }

        void 菜单_新增_Load(object sender, EventArgs e)
        {
            SQL.脚本 = "Select * from v菜单 With (Nolock) Where fID=" + SQL.引号(fID);
            SQL.设置控件值(SQL.DB.Report_DB, panel1, SQL.脚本);
            //新增,设置默认值
            if (fID == "0")
            {
                txt上级ID.Text = 上级ID;
                cb状态.Checked = true;
                txtfID.Text = fID;
                txt排序.Text = SQL.取值(SQL.DB.Report_DB, "Select Max(排序)+1 from 菜单 With (Nolock) Where 上级ID=" + SQL.引号(上级ID), "获取菜单排序号");
                if (txt排序.Text == "") txt排序.Text = "1";
            }
        }

        public void 保存()
        {
            string 状态 = "0"; if (cb状态.Checked) 状态 = "1";
            string 是否末级 = "0"; if (cb是否末级.Checked) 是否末级 = "1";
            SQL.脚本 = "Exec p菜单保存 "
                        + SQL.引号(txtfID.Text) + ","
                        + SQL.引号(txt名称.Text) + ","
                        + SQL.引号(txt上级ID.Text) + ","
                        + SQL.引号(txt排序.Text) + ","
                        + SQL.引号(txt界面定位.Text) + ","
                        + SQL.引号(状态) + ","
                        + SQL.引号(txt项目名称.Text) + ","
                        + SQL.引号(是否末级) + ","
                        + SQL.引号(cbb类型.Text) + ","
                        + SQL.引号(txt备注.Text) + ","
                        + SQL.引号(SQL.操作员);
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "菜单保存");
            if (SQL.结果 == "成功")
            {
                if (fID == "0")
                {
                    if (消息.提示选择("操作成功,是否继续添加！", MessageBoxIcon.Question))
                    {
                        txt名称.Text = "";
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    Close();
                }
            }
            else
            {
                消息.提示("操作" + SQL.结果);
            }
        }

        private void cbb类型_DropDown(object sender, EventArgs e)
        {
            SQL.脚本 = "Select 名称 from v菜单类型 With (Nolock) Order By fID";
            SQL.加载下拉框(SQL.DB.Report_DB, cbb类型, SQL.脚本, false);
        }
    }
}
