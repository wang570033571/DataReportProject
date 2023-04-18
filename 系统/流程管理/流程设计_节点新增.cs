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
    public partial class 流程设计_节点新增 : 基本查询窗体
    {
        public string fID = "0";
        public string 表头ID = ""; 

        public 流程设计_节点新增()
        {
            InitializeComponent();
            this.Load += new EventHandler(流程设计_节点新增_Load);
        }

        void 流程设计_节点新增_Load(object sender, EventArgs e)
        {
            初始化();
        }

        private void 初始化()
        {
            SQL.脚本 = "Select * from v流程定义表体 With (Nolock) Where fID=" + SQL.引号(fID);
            SQL.设置控件值(SQL.DB.Process_DB, panel1, SQL.脚本);
            //新增,设置默认值
            if (fID == "0")
            {
                txtfID.Text = fID;
                txt节点.Text = SQL.取值(SQL.DB.Process_DB, "Select Max(节点)+1 from v流程定义表体 With (Nolock) Where 表头ID=" + SQL.引号(表头ID), "获取节点");
                if (txt节点.Text == "") txt节点.Text = "1";
            }
            else
            {
                if (cbb类型.Text == "活动")
                {
                    txt周期.Enabled = true;
                    cbb周期单位.Enabled = true;
                    cbb参与者.Enabled = true;
                    cbb参与者类型.Enabled = true;                   
                }
                else
                {
                    txt周期.Enabled = false;
                    cbb周期单位.Enabled = false;
                    cbb参与者.Enabled = false;
                    cbb参与者类型.Enabled = false;                    
                }
            }
        }

        public void 保存()
        {
            string 重复过滤 = "0"; if (cb重复过滤.Checked) 重复过滤 = "1";
            SQL.脚本 = "Exec p流程定义表体保存 "
                                         + SQL.引号(txtfID.Text) + ","
                                         + SQL.引号(cbb类型.Text) + ","
                                         + SQL.引号(txt节点.Text) + ","
                                         + SQL.引号(txt名称.Text) + ","
                                         + SQL.引号(cbb参与者类型.Text) + ","
                                         + SQL.引号(cbb参与者.Text) + ","
                                         + SQL.引号(表头ID) + ","
                                         + SQL.引号(txt周期.Text) + ","
                                         + SQL.引号(cbb周期单位.Text) + ","
                                         + SQL.引号(重复过滤);
            SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程定义表体保存");
            if (SQL.结果 == "成功")
            {
                if (fID == "0")
                {
                    if (消息.提示选择("操作成功,是否继续添加！", MessageBoxIcon.Question))
                    {
                        txt名称.Text = "";
                        txt节点.Text = SQL.取值(SQL.DB.Process_DB, "Select Max(节点)+1 from 流程定义表体 With (Nolock) Where 表头ID=" + SQL.引号(表头ID), "获取节点");
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
           SQL.加载下拉框(SQL.DB.Process_DB,cbb类型,"Select 名称 from v流程节点类型 With (Nolock) Order By 1",false);
        }

        private void cbb参与者类型_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Process_DB, cbb参与者类型, "Select 名称 from v流程参与者类型 With (Nolock)  Order By 1", false);
        }

        private void cbb参与者_DropDown(object sender, EventArgs e)
        {
            if (cbb参与者类型.Text=="")
            {
              消息.提示("请选择参与者类型");
              return;
            }

            SQL.DB 数据库 = SQL.DB.Report_DB;

            if (cbb参与者类型.Text == "员工")
            {
                SQL.脚本 = "Select 名称 from 用户 With (Nolock) Where 状态=1 Order By 1";
            }
            else if (cbb参与者类型.Text == "岗位")
            {
                SQL.脚本 = "Select 岗位 from v流程岗位 With (Nolock) Order By 1";
                数据库 = SQL.DB.Process_DB;
            }
            else if (cbb参与者类型.Text == "相对角色")
            {
                SQL.脚本 = "Select 名称 from v流程相对角色 With (Nolock) Where 状态=1 Order By 排序";
                数据库 = SQL.DB.Process_DB;
            }
            else if (cbb参与者类型.Text == "指定字段")
            {
                DataTable dt = SQL.查询(SQL.DB.Process_DB, "Select * from v流程定义表头 With (Nolock) Where fID=" + SQL.引号(表头ID),"查询流程定义表头").Tables[0];
                if (dt.Rows.Count == 0) return;
                string 视图 = dt.Rows[0]["视图"].ToString();
                SQL.脚本 = "Select 名称 from v数据库对象明细 With (Nolock) Where 对象="+SQL.引号(视图);
                数据库 = (SQL.DB)Enum.Parse(typeof(SQL.DB), dt.Rows[0]["数据库"].ToString());
            }
            else 
            {
                消息.提示("参与者类型无效");
                return;              
            }
            SQL.加载下拉框(数据库, cbb参与者, SQL.脚本, true);
        }

        private void cbb周期单位_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Process_DB, cbb周期单位, "Select 名称 from v流程周期单位 With (Nolock) Order By 1", false);
        }

        private void cbb类型_SelectedIndexChanged(object sender, EventArgs e)
        {
              if (cbb类型.Text=="活动") 
              {
                txt周期.Text = "1";
                cbb周期单位.Text = "天";
                txt周期.Enabled = true;
                cbb周期单位.Enabled =true;
                cbb参与者.Enabled =true;
                cbb参与者类型.Enabled =true;
              }
              else
              {
                txt周期.Text = "";
                cbb周期单位.Text = "";
                cbb参与者.Text = "";
                cbb参与者类型.Text = "";
                txt周期.Enabled = false;
                cbb周期单位.Enabled = false;
                cbb参与者.Enabled = false;
                cbb参与者类型.Enabled = false;
              }
        }
    }
}
