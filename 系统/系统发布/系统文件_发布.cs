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
using System.Collections;

namespace 系统
{
    public partial class 系统文件_发布 : 基本查询窗体
    {
        public 系统文件_发布()
        {
            InitializeComponent();
        }

        public void 选择()
        {
            OpenFileDialog 文件打开 = new OpenFileDialog();
            文件打开.Multiselect = true;
            文件打开.ReadOnlyChecked = true;
            文件打开.Title = "请选择文件";
            文件打开.InitialDirectory = Application.StartupPath + @"\输出\"; ;
            文件打开.ShowDialog();

            foreach (string 文件名 in 文件打开.FileNames)
            {
                FileInfo 文件 = new FileInfo(文件名);
                lst1.Items.Add(文件.FullName);
            }
        }

        public void 保存()
        {
            SQL.结果 = "";

            foreach (string 文件名 in lst1.Items)
            {
                FileInfo 文件 = new FileInfo(文件名);
                string 名称 = 文件.Name;
                string 大小 = Convert.ToString(文件.Length / 1000);
                byte[] 内容 = 文件操作.文件转换成文件流(文件.FullName);
                string 版本号 = 文件操作.获取文件版本号(文件.FullName);
                string 强制更新 = "0";
                if (cb强制更新.Checked) 强制更新 = "1";
                SQL.脚本 = "Exec p系统文件上传 " + SQL.引号(名称) + ","
                                                + SQL.引号(大小) + ","
                                                + "@附件" + ","
                                                + SQL.引号(版本号) + ","
                                                + SQL.引号(txt更新说明.Text) + ","
                                                + SQL.引号(强制更新);
                SQL.结果 = SQL.上传(SQL.DB.Report_DB, SQL.脚本, "系统文件上传", 内容);
                if (SQL.结果 != "成功") 消息.提示("操作" + SQL.结果);
            }
            if (SQL.结果 != "") 消息.提示("操作" + SQL.结果);
            Close();
        }

        public void 删除()
        {
            object[] selected_objs = new object[lst1.SelectedItems.Count];
            lst1.SelectedItems.CopyTo(selected_objs,0);
            foreach (object item in selected_objs)
            {
                lst1.Items.Remove(item);
            }
        }
    }
}
