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
    public partial class 枚举维护_枚举新增 : 基本查询窗体
    {
        public string fID = "0";
        public string 上级ID = "0";

        public 枚举维护_枚举新增()
        {
            InitializeComponent();
            this.Load += new EventHandler(枚举维护_枚举新增_Load);
        }

        void 枚举维护_枚举新增_Load(object sender, EventArgs e)
        {
            初始化();
        }

        private void 初始化()
        {
            SQL.脚本 = "Select * from v枚举 With (Nolock) Where fID=" + SQL.引号(fID);
            SQL.设置控件值(SQL.DB.Report_DB,panel1, SQL.脚本);
            //新增,设置默认值
            if (fID == "0")
            {
                cb状态.Checked = true;
                txtfID.Text = fID;
                txt上级ID.Text = 上级ID;
                txt排序.Text = SQL.取值(SQL.DB.Report_DB, "Select Max(排序)+1 from 枚举 With (Nolock) Where 上级ID=" + SQL.引号(上级ID), "获取枚举排序号");
                if (txt排序.Text == "") txt排序.Text = "1";
            }
        }

        public void 保存()
        {
            string 状态 = "0"; if (cb状态.Checked) 状态 = "1";
            string 是否末级 = "0"; if (cb是否末级.Checked) 是否末级 = "1";
            SQL.脚本 = "Exec  p枚举保存 " + SQL.引号(txtfID.Text) + ","
                                         + SQL.引号(txt名称.Text) + ","
                                         + SQL.引号(txt描述.Text) + ","
                                         + SQL.引号(txt上级ID.Text) + ","
                                         + SQL.引号(是否末级) + ","
                                         + SQL.引号(txt排序.Text) + ","
                                         + SQL.引号(SQL.操作员) + ","
                                         + SQL.引号(状态);
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "枚举保存");
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
    }
}
