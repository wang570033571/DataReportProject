using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 框架;

namespace ERP
{
    public partial class 更新界面 : Form
    {
        DataTable dt更新文件 = null;

        public 更新界面(DataTable dt)
        {
            InitializeComponent();
            dt更新文件 = dt.Copy();
            this.Shown += new EventHandler(更新界面_Shown);
        }

        void 更新界面_Shown(object sender, EventArgs e)
        {
            更新();
            Close();
        }

        private void 更新()
        {
            StringBuilder 更新失败文件名 = new StringBuilder();
            progressBar.Visible = true;
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = dt更新文件.Rows.Count;
            string 路径 = Application.StartupPath + @"\";
            string 文件名;
            string 路径文件名;

            using (DataTable dt = dt更新文件)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    文件名 =dr["名称"].ToString();
                    try
                    {
                        DataSet ds = SQL.查询(SQL.DB.Report_DB, "Select 内容 from 系统文件 With (Nolock) Where fID=" + SQL.引号(dr["fID"].ToString()), "获取系统文件内容");
                        byte[] 文件流 = (byte[])ds.Tables[0].Rows[0][0];
                        文件操作.文件流转换成文件(路径, 文件名, 文件流);
                        路径文件名 = 路径 + 文件名;

                        // 更新EXE自己
                        if (System.IO.File.Exists(路径文件名 + ".tmp"))
                        {
                            try
                            {
                                System.IO.File.Move(路径文件名, 路径文件名 + ".old");
                                System.IO.File.Move(路径文件名 + ".tmp", 路径文件名);
                            }
                            catch (Exception ex) { 文件操作.记日志("更新文件" + 文件名 + "失败，失败原因：" + ex.ToString()); }
                        }

                        progressBar.Value++;
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        文件操作.记日志("更新文件" + 文件名 + "失败，失败原因：" + ex.ToString());
                        更新失败文件名.Append(文件名 + "\r\n");
                    }
                }

                if (更新失败文件名.ToString().Length > 0)
                    消息.提示("系统更新完成，其中更新失败文件如下：\r\n" + 更新失败文件名.ToString());
            }
        }
    }
}
