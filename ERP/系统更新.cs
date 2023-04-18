using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 框架;
using System.Windows.Forms;
using System.Data;

namespace ERP
{
    public static class 系统更新
    {
        public static void 更新()
        {
            文件操作.记日志("检查更新");
            if (System.IO.File.Exists(Application.StartupPath + "\\SHS-ERP.exe.old"))
            {
                try
                {
                    System.IO.File.Delete(Application.StartupPath + "\\SHS-ERP.exe.old");
                    文件操作.记日志("删除文件[SHS-ERP.exe.old]成功");
                }
                catch (Exception ex)
                {
                    文件操作.记日志("删除文件[SHS-ERP.exe.old]失败," + ex.Message);
                }
            }

            if (System.IO.File.Exists(Application.StartupPath + "\\框架.dll.old"))
            {
                try
                {
                    System.IO.File.Delete(Application.StartupPath + "\\框架.dll.old");
                    文件操作.记日志("删除文件[框架.dll.old]成功");
                }
                catch (Exception ex)
                {
                    文件操作.记日志("删除文件[框架.dll.old]失败," + ex.Message);
                }
            }

            //获取所有更新文件
            DataSet ds = SQL.查询(SQL.DB.Report_DB, "Select fID,名称,大小,版本号,更新日期,更新说明 from 系统文件 With (Nolock) Where 状态=1", "文本日志");
            if (ds == null)
            {
                文件操作.记日志("没有需要更新的文件");
                return;
            }

            //获取要更新的文件
            DataTable dt = 获取更新列表(ds);
            if (dt == null)
            {
                文件操作.记日志("没有需要更新的文件");
                return;
            }

            if (dt.Rows.Count <= 0)
            {
                文件操作.记日志("没有需要更新的文件");
                return;
            }

            文件操作.记日志("系统检测到有" + dt.Rows.Count.ToString() + "个文件需要更新");

            using (更新界面 frm = new 更新界面(dt))
            {
                frm.ShowDialog();
                if (System.IO.File.Exists(Application.StartupPath + "\\SHS-ERP.exe.old")
                    || System.IO.File.Exists(Application.StartupPath + "\\框架.dll.old"))
                {
                    Application.Restart();
                    return;
                }
            }
            return;
        }


        private static DataTable 获取更新列表(DataSet ds更新文件)
        {
            try
            {
                using (new DevExpress.Utils.WaitDialogForm("正在检查系统更新，请稍候……"))
                {
                    using (DataSet ds = ds更新文件)
                    {
                        文件操作.记日志("系统检测到有" + ds.Tables[0].Rows.Count.ToString() + "个文件需要检查更新");
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string 文件全名 = Application.StartupPath + "\\" + ds.Tables[0].Rows[i]["名称"].ToString();
                            string db版本号 = ds.Tables[0].Rows[i]["版本号"].ToString();
                            string fi版本号 = 文件操作.获取文件版本号(文件全名);

                            //数据库版本与文件版本一致,不用更新
                            if (db版本号 == fi版本号)
                            {
                                文件操作.记日志("文件" + ds.Tables[0].Rows[i]["名称"].ToString() + "与服务器上的版本一致,不需要更新");
                                ds.Tables[0].Rows.RemoveAt(i);
                                i--;
                            }
                            else if (fi版本号 != "")
                            {
                                //开发环境,不用更新
                                if (System.IO.File.Exists(Application.StartupPath + "\\开发环境.txt"))
                                {
                                    文件操作.记日志("文件" + ds.Tables[0].Rows[i]["名称"].ToString() + "在开发环境,不需要更新");
                                    ds.Tables[0].Rows.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                        return ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                消息.显示("系统更新", "检测更新文件失败！", ex);
                return null;
            }
        }

        public static bool 判断强制更新()
        {
            bool 返回值 = false;
            DataSet ds = SQL.查询(SQL.DB.Report_DB, "Select 名称,版本号 from 系统文件 With (Nolock) Where 状态=1 And 强制更新=1", "文本日志");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string 文件全名 = Application.StartupPath + "\\" + ds.Tables[0].Rows[i]["名称"].ToString();
                string db版本号 = ds.Tables[0].Rows[i]["版本号"].ToString();
                string fi版本号 = 文件操作.获取文件版本号(文件全名);

                //数据库版本与文件版本一致,不用更新
                if (db版本号 == fi版本号)
                {
                    文件操作.记日志("文件" + ds.Tables[0].Rows[i]["名称"].ToString() + "与服务器上的版本一致,不需要更新");
                    ds.Tables[0].Rows.RemoveAt(i);
                    i--;
                }
                else
                {
                    //文件版本未发布,不用更新
                    SQL.脚本 = "Select top 1 1 from 系统文件日志 With (Nolock) Where 版本号=" + SQL.引号(fi版本号)
                                + " And 名称 = " + SQL.引号(ds.Tables[0].Rows[i]["名称"].ToString());
                    if (SQL.取值(SQL.DB.Report_DB, SQL.脚本, "不记日志") == "")
                    {
                        文件操作.记日志("文件" + ds.Tables[0].Rows[i]["名称"].ToString() + "尚未发布,不需要更新");
                        ds.Tables[0].Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                文件操作.记日志("需要强制更新" + ds.Tables[0].Rows.Count.ToString() + "个文件");
                返回值 = true;
            }
            else
            {
                文件操作.记日志("没有需要强制更新的文件");
                返回值 = false;
            }
            return 返回值;
        }
    }
}
