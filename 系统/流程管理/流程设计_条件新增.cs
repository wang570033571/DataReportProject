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
    public partial class 流程设计_条件新增 : 基本查询窗体
    {
        public string fID = "0";
        public string 表头ID = "";
        public string 节点 = "";

        public 流程设计_条件新增()
        {
            InitializeComponent();
            this.Load += new EventHandler(流程设计_条件新增_Load);
        }

        void 流程设计_条件新增_Load(object sender, EventArgs e)
        {
            初始化();
        }

        private void 初始化()
        {
            SQL.脚本 = "Select * from v流程定义条件 With (Nolock) Where fID=" + SQL.引号(fID);
            SQL.设置控件值(SQL.DB.Process_DB, panel1, SQL.脚本);
        }

        private void cbb字段_DropDown(object sender, EventArgs e)
        {
            DataTable dt = SQL.查询(SQL.DB.Process_DB, "Select * from v流程定义表头 With (Nolock) Where fID=" + SQL.引号(表头ID), "查询流程定义表头").Tables[0];
            if (dt.Rows.Count == 0) return;
            string 视图 = dt.Rows[0]["视图"].ToString();
            SQL.脚本 = "Select 名称 from v数据库对象明细 With (Nolock) Where 对象=" + SQL.引号(视图);
            SQL.DB 数据库 = (SQL.DB)Enum.Parse(typeof(SQL.DB), dt.Rows[0]["数据库"].ToString());
            SQL.加载下拉框(数据库, cbb字段, SQL.脚本, true);
        }

        private void cbb运算符_DropDown(object sender, EventArgs e)
        {
            SQL.脚本 = "Select 名称 from v流程运算符 With (Nolock) Order By fID";
            SQL.加载下拉框(SQL.DB.Process_DB,cbb运算符,SQL.脚本,false);
        }

        private void cbb下一节点_DropDown(object sender, EventArgs e)
        {
            SQL.脚本 = "Select 节点 from v流程定义表体 With (Nolock) Where 表头ID="+SQL.引号(表头ID)
                        + "And 节点 <> " + SQL.引号(节点)
                        + "Order By 1";
            SQL.加载下拉框(SQL.DB.Process_DB,cbb下一节点,SQL.脚本,true);
        }

        public void 保存()
        {
            SQL.脚本 = "Exec  p流程定义条件保存 " + SQL.引号(fID) + ","
                                         + SQL.引号(表头ID) + ","
                                         + SQL.引号(节点) + ","
                                         + SQL.引号(cbb字段.Text) + ","
                                         + SQL.引号(cbb运算符.Text) + ","
                                         + SQL.引号(txt内容.Text) + ","
                                         + SQL.引号(cbb下一节点.Text);
            SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程定义条件保存");
            消息.提示("操作" + SQL.结果);
            if (SQL.结果 == "成功")
            {
                if (fID == "0")
                {
                    if (消息.提示选择("操作成功,是否继续添加！", MessageBoxIcon.Question))
                    {
                        cbb字段.Text = "";
                        cbb运算符.Text = "";
                        txt内容.Text = "";
                        cbb下一节点.Text = "";
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
