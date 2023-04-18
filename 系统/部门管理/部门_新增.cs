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
    public partial class 部门_新增 : 基本查询窗体
    {
        public string fID = "0";

        public 部门_新增()
        {
            InitializeComponent();
            this.Load += new EventHandler(部门_新增_Load);
        }

        void 部门_新增_Load(object sender, EventArgs e)
        {
            SQL.脚本 = "Select * from v部门 With (Nolock) Where fID=" + SQL.引号(fID);
            SQL.设置控件值(SQL.DB.Report_DB, panel1, SQL.脚本);
        }

        public void 保存()
        {
            string 状态 = "0"; if (chb是否可用.Checked) 状态 = "1";
            SQL.脚本 = "Exec p部门保存 "
                        + SQL.引号(fID) + ","
                        + SQL.引号(txt名称.Text) + ","
                        + SQL.引号(txt负责人.Text) + ","
                        + SQL.引号(txt主管.Text) + ","
                        + SQL.引号(状态) + ","
                        + SQL.引号(SQL.操作员);
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "部门保存");
            if (SQL.结果 == "成功")
            {
                if (fID == "0")
                {
                    if (消息.提示选择("操作成功,是否继续添加！", MessageBoxIcon.Question))
                    {
                        txt名称.Text = "";
                        txt负责人.Text = "";
                        txt主管.Text = "";
                        chb是否可用.Checked = true;
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
