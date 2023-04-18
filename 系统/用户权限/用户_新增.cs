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
    public partial class 用户_新增 : 基本查询窗体
    {
        public string fID = "0";

        public 用户_新增()
        {
            InitializeComponent();
            this.Load += new EventHandler(用户_新增_Load);
            cmb部门.DropDown += new EventHandler(cmb部门_DropDown);
        }

        void cmb部门_DropDown(object sender, EventArgs e)
        {
            SQL.脚本 = "SELECT 名称 from 部门 WITH (NOLOCK) where 状态=1 order by 名称";
            SQL.加载下拉框(SQL.DB.Report_DB, cmb部门, SQL.脚本, false);
        }

        void 用户_新增_Load(object sender, EventArgs e)
        {
            初始化();
        }

        public void 初始化()
        {
            if (fID != "0")
            {
                SQL.设置控件值(SQL.DB.Report_DB,panel1,"select * from v用户 with (nolock) where fid="+fID+"");
            }
        }

        public void 保存()
        {
            if (txt名称.Text == "")
            {
                消息.提示("请输入名称!");
                return;
            }

            if (txt登陆名.Text == "")
            {
                消息.提示("请输入登陆名!");
                return;
            }

            if (cmb部门.Text == "")
            {
                消息.提示("请选择部门!");
                return;
            }


            string 是否可用 = "";
            if (chb是否可用.Checked)
            {
                是否可用 = "1";
            }
            else
            {
                是否可用 = "0";
            }
            SQL.脚本 = "";
            SQL.脚本 = "Exec p用户保存 " + SQL.引号(fID.ToString()) + ","
                                         + SQL.引号(txt名称.Text.ToString()) + ","
                                         + SQL.引号(txt登陆名.Text.ToString()) + ","
                                         + SQL.引号(txt手机.Text.ToString()) + ","
                                         + SQL.引号(txt邮箱.Text.ToString()) + ","
                                         + SQL.引号(SQL.根据名称获取ID(SQL.DB.Report_DB, cmb部门.Text, "部门")) + ","
                                         + SQL.引号(txt岗位.Text) + ","
                                         + SQL.引号(是否可用) + ","
                                         + SQL.引号(SQL.操作员);
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "用户新增_保存");
            if (SQL.结果 != "")
            {
                消息.提示("操作" + SQL.结果);
                this.DialogResult = DialogResult.Yes;
            }
        }
    }
}
