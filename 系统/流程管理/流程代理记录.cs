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
    public partial class 流程代理记录 : 基本查询窗体
    {
        public 流程代理记录()
        {
            InitializeComponent();
            this.Load += new EventHandler(流程代理记录_Load);
        }

        void 流程代理记录_Load(object sender, EventArgs e)
        {
            查询();
        }

        public void 查询()
        {
            SQL.脚本 = SQL.获取查询脚本(panel1);
            SQL.脚本 += " Order by 流程名称 ";
            SQL.查询(SQL.DB.Process_DB, SQL.脚本, "流程代理记录查询", gv1);
        }

        public void 撤销()
        {
            if (gv1.GetFocusedDataRow() == null)
            {
                消息.提示("请选择要撤销的数据！");
                return;
            }

            if (!消息.提示选择("是否撤销代理？", MessageBoxIcon.Question)) return;

            int[] rows = gv1.GetSelectedRows();
            SQL.脚本 = "";
            for (int i = 0; i < rows.Length; i++)
            {
                DataRow dr = gv1.GetDataRow((int)rows[i]);
                SQL.脚本 += "Exec p流程代理撤销 " + SQL.引号(dr["fID"].ToString()) + ","
                                                 + SQL.引号(dr["类型"].ToString()) + ","
                                                 + SQL.引号(SQL.操作员) + ";\n";
            }
            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程代理撤销");
                if (SQL.结果 == "成功")
                {
                    消息.提示("操作" + SQL.结果);
                    this.查询();
                }
                else
                {
                    消息.提示("操作" + SQL.结果);
                }
            }
        }
    }
}
