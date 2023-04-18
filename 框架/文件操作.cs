using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.Data;

namespace 框架
{
    public class 文件操作
    {
        public static void 记日志(string 文本)
        {
            try
            {
                string 路径 = Application.StartupPath + @"\日志\";

                if (!Directory.Exists(路径))
                {
                    Directory.CreateDirectory(路径);
                }

                路径 += DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + ".txt";

                StreamWriter sw;
                if (!File.Exists(路径))
                {
                    sw = File.CreateText(路径);
                }
                else
                {
                    sw = File.AppendText(路径);
                }
                sw.WriteLine(DateTime.Now.ToString() + " [" + 文本 + "]");
                sw.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static ArrayList 日志列表()
        {
            ArrayList list = new ArrayList();
            DirectoryInfo Dir = new DirectoryInfo(Application.StartupPath + @"\日志\");
            foreach (FileInfo f in Dir.GetFiles("*.txt"))
            {
                list.Add(f.ToString());
            }

            IComparer myComparer = new myCompare();
            list.Sort(myComparer);

            return list;
        }

        private class myCompare : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(y, x));
            }
        }

        public static string 日志查看(string 文件名)
        {
            string 返回值;
            StreamReader sr = new StreamReader(Application.StartupPath + @"\日志\" + 文件名, Encoding.UTF8);
            返回值 = sr.ReadToEnd();
            sr.Close();
            return 返回值;
        }

        public static Byte[] 文件转换成文件流(string 文件)
        {
            try
            {
                FileInfo fi = new FileInfo(文件);
                FileStream fss = fi.OpenRead();
                byte[] bytes = new byte[fss.Length];
                fss.Read(bytes, 0, Convert.ToInt32(fss.Length));
                fss.Close();
                return bytes;
            }
            catch { return null; }
        }

        public static void 文件流转换成文件(string 路径, string 文件名, byte[] 文件流)
        {
            if (!Directory.Exists(路径)) Directory.CreateDirectory(路径);
            string 路径文件名 = 路径 + 文件名;

            try
            {
                FileInfo fi = new FileInfo(路径文件名);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1) fi.Attributes = FileAttributes.Normal;
                File.Delete(路径文件名);
                文件操作.记日志("删除文件[" + 文件名 + "]成功");
            } //删除原有文件
            catch (Exception ex)
            {
                路径文件名 = 路径文件名 + ".tmp";
                文件操作.记日志("删除文件[" + 文件名 + "]失败,更名为[" + 文件名 + "].tmp,失败原因:[" + ex.Message + "]");
            } // 文件被占用就创建.tmp文件
            MemoryStream ms = new MemoryStream(文件流);
            FileStream stream = new FileStream(路径文件名, FileMode.OpenOrCreate);
            ms.WriteTo(stream);
            ms.Close();
            stream.Close();
        }

        public static string 获取文件MD5值(string 文件名)
        {
            if (!System.IO.File.Exists(文件名)) return "";
            using (FileStream fileStream = new FileStream(文件名, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (System.Security.Cryptography.MD5CryptoServiceProvider getmd5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
                {
                    return System.BitConverter.ToString(getmd5.ComputeHash(fileStream));
                }
            }
        }

        public static string 获取文件版本号(string 文件名)
        {
            try
            {
                FileVersionInfo fi = FileVersionInfo.GetVersionInfo(文件名);
                return fi.FileVersion;
            }
            catch
            {
                return "";
            }
        }

        public static byte[] 图片转文件流(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                else
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        public static Image 文件流转图片(byte[] buffer)
        {
            try
            {
                MemoryStream ms = new MemoryStream(buffer);
                Image image = System.Drawing.Image.FromStream(ms);
                return image;
            }
            catch { return null; }
        }

        public static void 打开临时文件(string 路径文件全名)
        {
            try
            {
                if (路径文件全名.Trim().Length <= 0)
                {
                    消息.提示("没有查询到对应的文件！");
                    return;
                }

                if (!File.Exists(路径文件全名))
                {
                    消息.提示("没有查询到对应的文件！");
                    return;
                }

                FileInfo fi = new FileInfo(路径文件全名);
                File.SetAttributes(路径文件全名, fi.Attributes | FileAttributes.ReadOnly);
                System.Diagnostics.Process.Start(路径文件全名);
            }
            catch (Exception ex)
            {
                消息.提示(ex.Message);
            }
        }

        public static void 打开临时文件(SQL.DB 数据库, string SQL脚本, string 描述)
        {
            try
            {
                DataSet ds = SQL.查询(数据库, SQL脚本, 描述);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    消息.提示("没有查询到对应的附件！");
                    return;
                }

                if (ds.Tables[0].Rows[0]["内容"] == DBNull.Value) return;

                string 附件名 = ds.Tables[0].Rows[0]["名称"].ToString();
                byte[] 附件内容 = (byte[])ds.Tables[0].Rows[0]["内容"];

                if (附件名.Trim().Length <= 0) return;

                string 路径 = Application.StartupPath + @"\导出\";
                if (!Directory.Exists(路径)) Directory.CreateDirectory(路径);

                文件操作.文件流转换成文件(路径, 附件名, 附件内容);

                string 路径文件名 = 路径 + 附件名;
                打开临时文件(路径文件名);
            }
            catch (Exception ex)
            {
                消息.提示(ex.Message);
            }
        }

        //public static void 打开临时文件服务器(string 文件名, string 路径名)
        //{
        //    try
        //    {
        //        string 下载路径 = Application.StartupPath + @"\导出\";
        //        if (!Directory.Exists(下载路径)) Directory.CreateDirectory(下载路径);

        //        bool blTrue = SQL.LoadFileByBlock(下载路径, 文件名, 1, true, 路径名, null);

        //        if (blTrue)
        //        {
        //            string 路径文件全名 = 下载路径 + 文件名;

        //            打开临时文件(路径文件全名);
        //        }
        //        else
        //        {
        //            消息.提示("打开文件失败！");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        消息.提示(ex.Message);
        //    }
        //}

    }
}
