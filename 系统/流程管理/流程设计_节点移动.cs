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
    public partial class 流程设计_节点移动 : 基本查询窗体
    {
        public string 表头ID = "";
        public string 改前节点 = "";
        public 流程设计_节点移动()
        {
            InitializeComponent();
            this.Load += new EventHandler(流程设计_节点移动_Load);
        }

        void 流程设计_节点移动_Load(object sender, EventArgs e)
        {
            txt改前节点.Text = 改前节点;
        }

        private void cbb改后节点_DropDown(object sender, EventArgs e)
        {
            SQL.脚本 = "Select 节点 from v流程定义表体 With (Nolock) Where 表头ID=" + SQL.引号(表头ID)
                        + " And 节点<>" + SQL.引号(改前节点)
                        + " Order By 1";
            SQL.加载下拉框(SQL.DB.Process_DB, cbb改后节点, SQL.脚本, false);
        }

        public void 保存()
        { 
            SQL.脚本 = "Exec p流程定义节点修改 "
                        + SQL.引号(表头ID) + ","
                        + SQL.引号(改前节点) + ","
                        + SQL.引号(cbb改后节点.Text);
            SQL.结果 = SQL.执行(SQL.DB.Process_DB,SQL.脚本,"流程定义节点修改");
            消息.提示("操作" + SQL.结果);
            if (SQL.结果 == "成功") Close();
        }
    }
}
