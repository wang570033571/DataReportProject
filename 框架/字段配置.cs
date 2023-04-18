using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 框架
{
    public partial class 字段配置 : 基本查询窗体
    {
        public static string 窗体 = "";
        public static string 视图 = "";

        public 字段配置()
        {
            InitializeComponent();
            gv1.Tag = "v字段";
            this.Shown += new EventHandler(字段配置_Shown);
        }

        void 字段配置_Shown(object sender, EventArgs e)
        {
            SQL.脚本 = "Select 名称 from v数据库 With (Nolock) Order By 1";
            SQL.加载下拉框(SQL.DB.Report_DB, cbb数据库, SQL.脚本, false);
            cbb数据库.SelectedIndex = 0;
            查询();
            SQL.脚本 = "Select 值 from 枚举值 With (Nolock) Where 枚举ID=3 Order By 键";
            SQL.表格加载下拉框(SQL.DB.Report_DB, gv1, "查询类型", SQL.脚本);
        }

        public void 查询()
        {
            SQL.脚本 = "Select * from v字段 With (Nolock) Where 窗体="+SQL.引号(窗体)+" And 视图="+SQL.引号(视图);
            SQL.脚本 += " Order By 排序";
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询字段", gv1);
        }

        public void 导入()
        {
            SQL.DB 数据库 = (SQL.DB)Enum.Parse(typeof(SQL.DB), cbb数据库.Text);
            SQL.脚本 = "Exec p字段导入 " + SQL.引号(窗体) + "," + SQL.引号(视图);
            SQL.结果 = SQL.执行(数据库, SQL.脚本, "字段导入");
            消息.提示("操作"+SQL.结果);
            查询();
        }

        public void 保存()
        {
            SQL.脚本 = "";
            gv1.CloseEditor();
            gv1.UpdateCurrentRow();
            for (int i = 0; i < gv1.RowCount; i++)
            {
                DataRow dr = gv1.GetDataRow(i);
                if (dr.RowState == DataRowState.Modified)
                {
                    SQL.脚本 += "Exec p字段保存 " + SQL.引号(dr["fID"].ToString()) + ","
                              + SQL.引号(dr["排序"].ToString()) + ","
                              + SQL.引号(dr["是否显示"].ToString()) + ","
                              + SQL.引号(dr["是否可编辑"].ToString()) + ","
                              + SQL.引号(dr["是否查询"].ToString()) + ","
                              + SQL.引号(dr["查询类型"].ToString()) + ","
                              + SQL.引号(dr["查询脚本"].ToString()) + ","
                              + SQL.引号(dr["小数位数"].ToString()) + "\n";
                }
            }
            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "字段保存");
                消息.提示("操作"+SQL.结果);
                查询();
            }

        }
    }
}
