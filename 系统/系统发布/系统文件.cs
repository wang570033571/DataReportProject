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
    public partial class 系统文件 : 基本查询窗体
    {
        public 系统文件()
        {
            InitializeComponent();
            gv1.Tag = "v系统文件";
            gv2.Tag = "v系统文件日志";
            this.Load += new EventHandler(系统文件_Load);
        }

        void 系统文件_Load(object sender, EventArgs e)
        {
            查询();
        }

        public void 查询()
        {
            SQL.脚本 = "Select * from v系统文件 With (Nolock) Where 1=1 Order By 更新日期 Desc";
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询系统文件", gv1);       
        }

        public void 上传()
        {
            using (系统文件_发布 frm = new 系统文件_发布())
            {
                frm.ShowDialog();
            }
            查询();
        }

        public void 下载()
        {
            string 下载路径;
            try
            {
                using (FolderBrowserDialog 路径选择 = new FolderBrowserDialog())
                {
                    路径选择.Description = "请选择目录";
                    路径选择.ShowDialog();
                    下载路径 = 路径选择.SelectedPath;
                }

                if (下载路径 != "")
                {
                    下载路径 += "\\";
                }
                else
                {
                    return;
                }

                if (gc1.IsFocused)
                {
                    foreach (int index in gv1.GetSelectedRows())
                    {
                        string fID = Convert.ToString(gv1.GetDataRow(index)["fID"]);
                        string 文件名 = Convert.ToString(gv1.GetDataRow(index)["名称"]);
                        DataSet ds = SQL.查询(SQL.DB.Report_DB, "Select 内容 from 系统文件 With (Nolock) Where fID=" + SQL.引号(fID), "下载当前系统文件");
                        byte[] 文件流 = (byte[])ds.Tables[0].Rows[0][0];
                        文件操作.文件流转换成文件(下载路径, 文件名, 文件流);
                    }
                }
                else if (gc2.IsFocused)
                {
                    foreach (int index in gv2.GetSelectedRows())
                    {
                        string fID = Convert.ToString(gv2.GetDataRow(index)["fID"]);
                        string 文件名 = Convert.ToString(gv2.GetDataRow(index)["名称"]);
                        DataSet ds = SQL.查询(SQL.DB.Report_DB, "Select 内容 from 系统文件日志 With (Nolock) Where fID=" + SQL.引号(fID), "下载历史系统文件");
                        byte[] 文件流 = (byte[])ds.Tables[0].Rows[0][0];
                        文件操作.文件流转换成文件(下载路径, 文件名, 文件流);
                    }
                }

                消息.提示("操作成功");
                return;
            }
            catch (Exception ex)
            {
                消息.提示("操作失败,失败原因如下[" + ex.ToString() + "]");
                return;
            }
        }

        public void 删除()
        {
            try
            {
                foreach (int index in gv1.GetSelectedRows())
                {
                    string fID = Convert.ToString(gv1.GetDataRow(index)["fID"]);
                    SQL.脚本 = "Exec p系统文件删除 " + SQL.引号(fID);
                    SQL.结果 = SQL.执行(SQL.DB.Report_DB,SQL.脚本, "系统文件删除");
                    if (SQL.结果 != "成功")
                    {
                        MessageBox.Show("操作" + SQL.结果);
                        return;
                    }
                }
                消息.提示("操作" + SQL.结果);
            }
            finally
            {
                查询();
            }      
        }

        private void gv1_DoubleClick(object sender, EventArgs e)
        {
            string 名称 = gv1.GetFocusedDataRow()["名称"].ToString();
            SQL.脚本 = "Select top 20 * from v系统文件日志 With (Nolock) Where 名称 = " + SQL.引号(名称);
            SQL.脚本 += " order By fID Desc";
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询系统文件日志",gv2);
        }
    }
}
