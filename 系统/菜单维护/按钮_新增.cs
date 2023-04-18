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
    public partial class 按钮_新增 : 基本查询窗体
    {
        public string fID = "0";
        public string 按钮菜单ID = "";

        public 按钮_新增()
        {
            InitializeComponent();
            this.Load += new EventHandler(按钮_新增_Load);
        }

        void 按钮_新增_Load(object sender, EventArgs e)
        {
            SQL.脚本 = "Select * from 按钮 With (Nolock) Where fID=" + SQL.引号(fID);
            SQL.设置控件值(SQL.DB.Report_DB, panel1, SQL.脚本);
            //新增,设置默认值
            if (fID == "0")
            {
                txt菜单ID.Text = 按钮菜单ID;
                cb状态.Checked = true;
                txtfID.Text = fID;
                txt排序.Text = SQL.取值(SQL.DB.Report_DB, "Select Max(排序)+1 from 按钮 With (Nolock) Where 菜单ID=" + SQL.引号(按钮菜单ID), "获取按钮排序号");
                if (txt排序.Text == "") txt排序.Text = "1";
            }
        }

        public void 保存()
        {
            string 状态 = "0"; if (cb状态.Checked) 状态 = "1";
            SQL.脚本 = "Exec p按钮保存 "
                        + SQL.引号(txtfID.Text) + ","
                        + SQL.引号(txt名称.Text) + ","
                        + SQL.引号(txt图标.Text) + ","
                        + SQL.引号(txt菜单ID.Text) + ","
                        + SQL.引号(txt排序.Text) + ","
                        + SQL.引号(状态) + ","
                        + SQL.引号(SQL.操作员) + ","
                        + SQL.引号(txt备注.Text.Trim());
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "按钮保存");
            if (SQL.结果 == "成功")
            {
                //新增数据,询问是否继续添加,编辑数据则直接关闭
                if (fID == "0")
                {
                    if (消息.提示选择("操作成功,是否继续添加！", MessageBoxIcon.Question))
                    {
                        txt名称.Text = "";
                        txt图标.Text = "";
                        txt排序.Text = SQL.取值(SQL.DB.Report_DB, "Select Max(排序)+1 from 按钮 With (Nolock) Where 菜单ID=" + SQL.引号(按钮菜单ID), "获取按钮排序号");
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

        private void txt名称_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { 保存(); }
        }
    }
}
