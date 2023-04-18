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
    public partial class 流程设计_活动新增 : 基本查询窗体
    {
        public string fID = "0";
        public string 表头ID = "";
        public string 节点 = "";
        public string b数据库 = "";

        public 流程设计_活动新增()
        {
            InitializeComponent();
            this.Load += new EventHandler(流程设计_活动新增_Load);
        }

        void 流程设计_活动新增_Load(object sender, EventArgs e)
        {
            初始化();
        }

        private void cbb数据库_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Report_DB, cbb数据库, "Select 名称 from v数据库 With (Nolock) Order By 1", false);
        }

        private void cbb存储过程_DropDown(object sender, EventArgs e)
        {
            if (cbb数据库.Text == "")
            {
                消息.提示("请选择数据库");
                return;
            }
            SQL.DB 数据库 = (SQL.DB)Enum.Parse(typeof(SQL.DB), cbb数据库.Text);
            SQL.脚本 = "Select 名称 from v数据库对象 With (Nolock) Where 类型 = '过程'";
            if (cbb存储过程.Text != "") SQL.脚本 += "And 名称 Like "+SQL.引号(cbb存储过程.Text,2);
            SQL.脚本 += "Order By 1";
            SQL.加载下拉框(数据库, cbb存储过程, SQL.脚本, true);
        }

        private void cbb存储过程_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQL.脚本 = "Select 名称 from v数据库对象明细 With (Nolock) Where 对象 = " + SQL.引号(cbb存储过程.Text);
            SQL.DB 数据库 = (SQL.DB)Enum.Parse(typeof(SQL.DB), cbb数据库.Text);
            DataTable dt = SQL.查询(数据库, SQL.脚本, "获取存储过程参数").Tables[0];
            txt形参.Text = SQL.数据集转字符串(dt);
        }

        private void 初始化()
        {
            SQL.脚本 = "Select * from v流程定义活动 With (Nolock) Where fID=" + SQL.引号(fID);
            SQL.设置控件值(SQL.DB.Process_DB, panel1, SQL.脚本);
            SQL.脚本 = "Select 名称 from v数据库对象明细 With (Nolock) Where 对象 = " + SQL.引号(cbb存储过程.Text);
            cbb数据库.Text = b数据库;
            if (cbb数据库.Text != "")
            {
                SQL.DB 数据库 = (SQL.DB)Enum.Parse(typeof(SQL.DB), cbb数据库.Text);
                DataTable dt = SQL.查询(数据库, SQL.脚本, "获取存储过程参数").Tables[0];
                txt形参.Text = SQL.数据集转字符串(dt);
            }
        }

        public void 保存()
        {
            if (表头ID == "")
            {
                消息.提示("表头ID不能为空");
                return;
            }

            if (节点 == "")
            {
                消息.提示("节点不能为空");
                return;          
            }

            SQL.脚本 = "Exec  p流程定义活动保存 " + SQL.引号(fID) + ","
                                         + SQL.引号(表头ID) + ","
                                         + SQL.引号(节点) + ","
                                         + SQL.引号(cbb数据库.Text) + ","
                                         + SQL.引号(cbb存储过程.Text) + ","
                                         + SQL.引号(txt实参.Text) + ","
                                         + SQL.引号(cbb方向.Text);
            SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程定义活动保存");
            消息.提示("操作" + SQL.结果);
            if (SQL.结果 == "成功") Close();
        }
    }
}
