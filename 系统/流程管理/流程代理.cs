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
    public partial class 流程代理 : 基本查询窗体
    {
        public 流程代理()
        {
            InitializeComponent();

            this.Load += new EventHandler(流程代理_Load);
        }

        void 流程代理_Load(object sender, EventArgs e)
        {
            this.chk全选数据.CheckedChanged += new EventHandler(chk全选数据_CheckedChanged);
            this.chk全选流程.CheckedChanged += new EventHandler(chk全选流程_CheckedChanged);

            this.chkTable.DoubleClick += new EventHandler(chkTable_DoubleClick);
        }

        void chk全选数据_CheckedChanged(object sender, EventArgs e)
        {
            for (int index = 0; index < chkTable.Items.Count; index++)
            {
                chkTable.SetItemChecked(index, chk全选数据.Checked);
            }
        }

        void chk全选流程_CheckedChanged(object sender, EventArgs e)
        {
            for (int index = 0; index < chblist.Items.Count; index++)
            {
                chblist.SetItemChecked(index, chk全选流程.Checked);
            }
        }
        
        void chkTable_DoubleClick(object sender, EventArgs e)
        {
            if (chkTable.SelectedItem == null) return;
            if (txt被代理人.Text.Trim() == "") return ;

            new 流程代理明细(chkTable.SelectedItem.ToString().Substring(0,chkTable.SelectedItem.ToString().IndexOf("(")),txt被代理人.Text.Trim()).ShowDialog();
        }

        private void btn被代理人_Click(object sender, EventArgs e)
        {
            using (流程代理人_选择 frm = new 流程代理人_选择())
            {
                frm.ShowDialog();
                if (frm.返回值 != "")
                {
                    txt被代理人.Text = frm.返回值;
                }
            }
        }

        private void btn代理人_Click(object sender, EventArgs e)
        {
            using (流程代理人_选择 frm = new 流程代理人_选择())
            {
                frm.ShowDialog();
                if (frm.返回值 != "")
                {
                    txt代理人.Text = frm.返回值;
                }
            }
        }

        public void 保存()
        {
            if (!消息.提示选择("是否确认保存？", MessageBoxIcon.Question)) return;

            if (txt被代理人.Text == "")
            {
                消息.提示("被代理人不能为空,请选择!");
                return;
            }

            if (txt代理人.Text == "")
            {
                消息.提示("代理人不能为空,请选择!");
                return;
            }

            if (chblist.CheckedItems.Count == 0 && chkTable.CheckedItems.Count == 0)
            {
                消息.提示("请选择需要代理的流程或业务数据!");
                return;
            }

            SQL.脚本 = "";
            for (int i = 0; i < chblist.CheckedItems.Count; i++)
            {
                int endIndex = chblist.CheckedItems[i].ToString().IndexOf("-");

                SQL.脚本 += "Exec p流程代理" + SQL.引号(txt被代理人.Text) + ","
                                             + SQL.引号(txt代理人.Text) + ","
                                             + SQL.引号(chblist.CheckedItems[i].ToString().Substring(0, endIndex)) + ","
                                             + SQL.引号(SQL.操作员) + ",'';\n";
            }

            for (int i = 0; i < chkTable.CheckedItems.Count; i++)
            {
                int endIndex = chkTable.CheckedItems[i].ToString().IndexOf("(");
                SQL.脚本 += "Exec p流程代理" + SQL.引号(txt被代理人.Text) + ","
                                             + SQL.引号(txt代理人.Text) + ",'0',"
                                             + SQL.引号(SQL.操作员) + ","
                                             + SQL.引号(chkTable.CheckedItems[i].ToString().Substring(0, endIndex)) + ";\n";
            }
            
            if (SQL.脚本 != "")
            {
                SQL.结果 = SQL.执行(SQL.DB.Process_DB, SQL.脚本, "流程代理保存");
                消息.提示("操作" + SQL.结果);

                if (SQL.结果 == "成功") 加载数据();
            }
        }

        private void txt被代理人_TextChanged(object sender, EventArgs e)
        {
            if (txt被代理人.Text != "") 加载数据();
        }
        
        public void 加载数据()
        {
            SQL.脚本 = "EXEC p获取流程代理表 " + SQL.引号(txt被代理人.Text.Trim());
            DataSet dsData = SQL.查询(SQL.DB.Process_DB, SQL.脚本, "获取代理信息");

            chblist.Items.Clear();
            foreach (DataRow dr in dsData.Tables[0].Rows)
            {
                chblist.Items.Add(dr["fid"].ToString() + "-" + dr["名称"].ToString() + "(" + dr["数量"].ToString() + ")");
            }

            chkTable.Items.Clear();
            foreach (DataRow dr in dsData.Tables[1].Rows)
            {
                chkTable.Items.Add(dr["名称"].ToString() + "(" + dr["记录数"].ToString() + ")");
            }
        }

        public void 记录()
        {
            using (流程代理记录 frm = new 流程代理记录())
            {
                frm.ShowDialog();
            }
        }
    }
}
