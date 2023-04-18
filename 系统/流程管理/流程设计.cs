using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 框架;
using System.IO;

namespace 系统
{
    public partial class 流程设计 : 基本查询窗体
    {
        public 流程设计()
        {
            InitializeComponent();
            this.Load += new EventHandler(流程设计_Load);
        }

        void 流程设计_Load(object sender, EventArgs e)
        {
            查询();
        }

        public void 查询()
        {
            SQL.脚本 = SQL.获取查询脚本(panel1);
            SQL.查询(SQL.DB.Process_DB, SQL.脚本, "查询流程定义", gv1);
        }

        public void 新增()
        {
            using (流程设计_流程新增 frm = new 流程设计_流程新增())
            {
                frm.ShowDialog();
                查询();
            }
        }

        public void 编辑()
        {
            using (流程设计_流程新增 frm = new 流程设计_流程新增())
            {
                frm.fID = gv1.GetFocusedDataRow()["fID"].ToString();
                frm.ShowDialog();
                查询();
            }
        }

        public void 删除()
        {
            SQL.脚本 = "";
            foreach (int i in gv1.GetSelectedRows())
            {
                SQL.脚本 += "Exec p流程定义表头删除 " + SQL.引号(gv1.GetDataRow(i)["fID"].ToString()) + ","
                                                + SQL.引号(SQL.操作员) + "\n";
            }
            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程定义表头删除");
                消息.提示("操作" + SQL.结果);
                if (SQL.结果 == "成功") { 查询(); }
            }
        }

        public void 流程图()
        {
            if (gv1.GetFocusedDataRow() == null) return;

            string 路径 = Application.StartupPath + @"\导出\";
            if (!Directory.Exists(路径)) Directory.CreateDirectory(路径);
            string fID = gv1.GetFocusedDataRow()["fID"].ToString();
            byte[] 附件内容 = null;

            DataSet ds = SQL.查询(SQL.DB.Process_DB, "Select 附件名,附件 from 流程定义表头 With (Nolock) Where fID=" + SQL.引号(fID), "获取流程定义附件");
            string 附件名 = ds.Tables[0].Rows[0]["附件名"].ToString();
            if (附件名 != "")
            {
                附件内容 = (byte[])ds.Tables[0].Rows[0]["附件"];
            }
            else
            {
                消息.提示("未设置流程图");
                return;
            }

            string 路径文件名 = 路径 + 附件名;
            文件操作.文件流转换成文件(路径, 附件名, 附件内容);
            System.Diagnostics.Process.Start(路径文件名);
        }

        public void 复制()
        {
            if (gv1.RowCount == 0) return;
            if (!消息.提示选择("确认要复制该流程吗？", MessageBoxIcon.Question)) return;
            SQL.脚本 = "Exec p流程定义复制 "+SQL.引号(gv1.GetFocusedDataRow()["fID"].ToString())+","+SQL.引号(SQL.操作员);
            SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "复制流程");
            消息.提示("操作" + SQL.结果);
            if (SQL.结果 == "成功") 查询();
        }

        private void gc1_DoubleClick(object sender, EventArgs e)
        {
            编辑();
        }
    }
}
