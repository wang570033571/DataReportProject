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
    public partial class 流程设计_视图配置 : 基本查询窗体
    {
        public string 表头ID = "";
        public string 数据库 = "";
        public string 视图 = "";
        public string 明细视图 = "";

        public 流程设计_视图配置()
        {
            InitializeComponent();
        }

        private void 流程设计_视图配置_Shown(object sender, EventArgs e)
        {
            if (明细视图 == "")
            {
                gc表体.Visible = false;
            }
            查询();
        }

        public void 查询()
        {
            if (表头ID == "")
            {
                消息.提示("表头ID不能为空");
                return;
            }

            if (数据库 == "")
            {
                消息.提示("数据库不能为空");
                return;
            }


            SQL.脚本 = "Exec " + 数据库 + ".dbo.p流程定义视图字段重新装载 " + SQL.引号(表头ID);
            SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程定义视图字段重新装载");
            if (SQL.结果 != "成功")
            {
                消息.提示("操作" + SQL.结果);
                return;
            }

            //处理表头
            if (视图 != "")
            {
                SQL.脚本 = "Select * from v流程定义视图 With (Nolock) Where 表头ID= " + SQL.引号(表头ID)
                                                                                        + " And 视图 =" + SQL.引号(视图);
                SQL.脚本 += " Order By 排序";

                using (DataTable dt = SQL.查询(SQL.DB.Process_DB, SQL.脚本, "查询流程定义视图").Tables[0])
                {
                    if (dt == null) return;
                    gv表头.Columns.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn col = gv表头.Columns.Add();
                        col.Width = Convert.ToInt16(dr["长度"].ToString());
                        col.Name = dr["字段"].ToString();
                        col.FieldName = dr["字段"].ToString();
                        col.Caption = dr["字段"].ToString();
                        col.Visible = Convert.ToBoolean(dr["是否可见"]);
                    }
                }
                SQL.脚本 = "Select top 5 * from " + 数据库 + ".dbo." + 视图 + " With (Nolock)";
                SQL.查询((SQL.DB)Enum.Parse(typeof(SQL.DB), 数据库), SQL.脚本, "文本日志", gv表头);
            }

            //处理表体
            if (明细视图 != "")
            {
                SQL.脚本 = "Select * from v流程定义视图 With (Nolock) Where 表头ID= " + SQL.引号(表头ID)
                                                                                        + " And 视图 =" + SQL.引号(明细视图);
                SQL.脚本 += " Order By 排序";
                using (DataTable dt = SQL.查询(SQL.DB.Process_DB, SQL.脚本, "查询流程定义视图").Tables[0])
                {
                    if (dt == null) return;
                    gv表体.Columns.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn col = gv表体.Columns.Add();
                        col.Width = Convert.ToInt16(dr["长度"].ToString());
                        col.Name = dr["字段"].ToString();
                        col.FieldName = dr["字段"].ToString();
                        col.Caption = dr["字段"].ToString();
                        col.Visible = Convert.ToBoolean(dr["是否可见"]);
                    }
                }
                SQL.脚本 = "Select top 5 * from " + 数据库 + ".dbo." + 明细视图 + " With (Nolock)";
                SQL.查询((SQL.DB)Enum.Parse(typeof(SQL.DB), 数据库), SQL.脚本, "文本日志", gv表体);          
            }
        }

        public void 装载默认()
        {
            SQL.脚本 = "Delete 流程定义视图 Where 表头ID = " + SQL.引号(表头ID);
            SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "删除流程定义视图");
            if (SQL.结果 != "成功")
            {
                消息.提示("操作" + SQL.结果);
                return;
            }
            查询();
            消息.提示("操作成功");
        }

        public void 保存()
        {
            SQL.脚本 = "Exec p流程定义视图删除 " + SQL.引号(表头ID) + "," + SQL.引号(视图) +"\r\n";
            if (明细视图 != "")
            {
                SQL.脚本 += "Exec p流程定义视图删除 " + SQL.引号(表头ID) + "," + SQL.引号(明细视图) + "\r\n";
            }
            SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程定义视图删除");
            if (SQL.结果 != "成功")
            {
                消息.提示("操作" + SQL.结果);
                return;
            }

            SQL.脚本 = "";
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv表头.Columns)
            {
                int 是否可见 = col.Visible ? 1 : 0;
                SQL.脚本 += "Exec p流程定义视图保存 " + SQL.引号(表头ID) + ","
                                                     + SQL.引号(视图) + ","
                                                     + SQL.引号(col.Name) + ","
                                                     + SQL.引号(Convert.ToString(col.Width)) + ","
                                                     + SQL.引号(Convert.ToString(是否可见)) + ","
                                                     + SQL.引号(Convert.ToString(col.VisibleIndex)) + "\r\n";                                                  
            }

            if (明细视图 != "")
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv表体.Columns)
                {
                    int 是否可见 = col.Visible ? 1 : 0;
                    SQL.脚本 += "Exec p流程定义视图保存 " + SQL.引号(表头ID) + ","
                                                         + SQL.引号(明细视图) + ","
                                                         + SQL.引号(col.Name) + ","
                                                         + SQL.引号(Convert.ToString(col.Width)) + ","
                                                         + SQL.引号(Convert.ToString(是否可见)) + ","
                                                         + SQL.引号(Convert.ToString(col.VisibleIndex)) + "\r\n"; 
                }
            }
            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程定义视图保存");
                消息.提示("操作" + SQL.结果);
            }
        }
    }
}
