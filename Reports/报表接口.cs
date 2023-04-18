using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Reports
{
    public class 报表接口
    {
        public void 打印报表(object 报表对象, DataSet 数据集, bool 是否预览, int 打印页数)
        {
            Reports.基本报表 Report = (Reports.基本报表)报表对象;
            Report.加载数据(数据集);

            if (是否预览)
            {
                Report.CreateDocument();
                Report.PrintingSystem.ShowMarginsWarning = false;
                Report.ShowPreview();
            }
            else
            {
                for (int i = 0; i < 打印页数; i++)
                    Report.Print();
            }        
        }

        public void 导出报表(object 报表对象, DataSet 数据集, string 导出类型, string 保存路径和文件名)
        {
            Reports.基本报表 Report = (Reports.基本报表)报表对象;
            Report.加载数据(数据集);

            Report.CreateDocument();
            Report.PrintingSystem.ShowMarginsWarning = false;

            switch (导出类型.ToUpper())
            {
                case "CSV":
                    Report.ExportToCsv(保存路径和文件名);
                    break ;
                case "HTML":
                    Report.ExportToHtml(保存路径和文件名);
                    break ;
                case "IMAGE":
                    Report.ExportToImage(保存路径和文件名+".bak");
                    bool 压缩成功 = GetPicThumbnail(保存路径和文件名+".bak", 保存路径和文件名, 100);
                    if (压缩成功)
                    {
                        //删除历史记录
                        if (File.Exists(保存路径和文件名 + ".bak"))
                        {
                            try
                            {
                                File.Delete(保存路径和文件名 + ".bak");
                            } //删除原有文件
                            catch
                            {

                            }
                        }
                    }
                    break ;
                case "MHT":
                    Report.ExportToMht(保存路径和文件名);
                    break ;
                case "PDF":
                    Report.ExportToPdf(保存路径和文件名);
                    break ;
                case "RTF":
                    Report.ExportToRtf(保存路径和文件名);
                    break ;
                case "TEXT":
                    Report.ExportToText(保存路径和文件名);
                    break ;
                case "XLS":
                    Report.ExportToXls(保存路径和文件名);
                    break ;
                case "XLSX":
                    Report.ExportToXlsx(保存路径和文件名);
                    break ;
            }
        }

        #region GetPicThumbnail
        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片</param>
        /// <param name="dFile">压缩后保存位置</param>
        /// <param name="dHeight">高度</param>
        /// <param name="dWidth"></param>
        /// <param name="flag">压缩质量 1-100</param>
        /// <returns></returns>

        public bool GetPicThumbnail(string sFile, string dFile, int flag)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int sW = 0, sH = 0;
            int dHeight = 0, dWidth = 0;

            //按比例缩放
            Size tem_size = new Size(iSource.Width, iSource.Height);
            sW = tem_size.Width;
            sH = tem_size.Height;
            dWidth = tem_size.Width;
            dHeight = tem_size.Height;

            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);
            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }

                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }

            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }
        #endregion
    }
}
