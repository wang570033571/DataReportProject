using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Net;

namespace 框架
{
    public class 上传下载
    {
        /// <summary>

        /// WebClient上传文件至服务器（不带进度条）
        /// </summary>

        /// <param name="fileNameFullPath">要上传的文件（全路径格式）</param>

        /// <param name="strUrlDirPath">Web服务器文件夹路径</param>

        /// <returns>True/False是否上传成功</returns>
        public bool 上传文件(string fileNameFullPath, string strUrlDirPath)
        {

            //得到要上传的文件文件名
            string fileName = fileNameFullPath.Substring(fileNameFullPath.LastIndexOf("\\") + 1);

            //新文件名由年月日时分秒及毫秒组成
            string NewFileName = DateTime.Now.ToString("yyyyMMddhhmmss")

                                        + DateTime.Now.Millisecond.ToString()

                                        + fileNameFullPath.Substring(fileNameFullPath.LastIndexOf("."));

            //得到文件扩展名
            string fileNameExt = fileName.Substring(fileName.LastIndexOf(".") + 1);

            if (strUrlDirPath.EndsWith("/") == false) strUrlDirPath = strUrlDirPath + "/";

            //保存在服务器上时，将文件改名（示业务需要）
            strUrlDirPath = strUrlDirPath + NewFileName;

            // 创建WebClient实例
            WebClient myWebClient = new WebClient();

            myWebClient.Credentials = CredentialCache.DefaultCredentials;

            // 将要上传的文件打开读进文件流
            FileStream myFileStream = new FileStream(fileNameFullPath, FileMode.Open, FileAccess.Read);

            BinaryReader myBinaryReader = new BinaryReader(myFileStream);

            try
            {

                byte[] postArray = myBinaryReader.ReadBytes((int)myFileStream.Length);

                //打开远程Web地址，将文件流写入
                Stream postStream = myWebClient.OpenWrite(strUrlDirPath, "PUT");

                if (postStream.CanWrite)
                {

                    postStream.Write(postArray, 0, postArray.Length);

                }

                else
                {

                    //MessageBox.Show("Web服务器文件目前不可写入，请检查Web服务器目录权限设置！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }

                postStream.Close();//关闭流
                return true;

            }

            catch (Exception exp)
            {

                MessageBox.Show("文件上传失败：" + exp.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;

            }

        }

        /// <summary>

        /// 下载服务器文件至客户端（不带进度条）
        /// </summary>

        /// <param name="strUrlFilePath">要下载的Web服务器上的文件地址（全路径　如：http://www.dzbsoft.com/test.rar）</param>

        /// <param name="Dir">下载到的目录（存放位置，机地机器文件夹）</param>

        /// <returns>True/False是否上传成功</returns>
        public bool 下载文件(string strUrlFilePath, string strLocalDirPath)
        {

            // 创建WebClient实例
            WebClient client = new WebClient();

            //被下载的文件名
            string fileName = strUrlFilePath.Substring(strUrlFilePath.LastIndexOf("/"));

            //另存为的绝对路径＋文件名
            string Path = strLocalDirPath + fileName;

            try
            {

                WebRequest myWebRequest = WebRequest.Create(strUrlFilePath);

            }

            catch (Exception exp)
            {

                MessageBox.Show("文件下载失败：" + exp.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            try
            {

                client.DownloadFile(strUrlFilePath, Path);

                return true;

            }

            catch (Exception exp)
            {

                MessageBox.Show("文件下载失败：" + exp.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;

            }

        }

        /// <summary>
        /// 下载带进度条代码（普通进度条）
        /// </summary>
        /// <param name="URL">网址</param>
        /// <param name="Filename">文件名</param>
        /// <param name="Prog">普通进度条ProgressBar</param>
        /// <returns>True/False是否下载成功</returns>
        public bool DownLoadFile(string URL, string Filename, ProgressBar Prog)
        {
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL); //从URL地址得到一个WEB请求    
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse(); //从WEB请求得到WEB响应    
                long totalBytes = myrp.ContentLength; //从WEB响应得到总字节数    
                Prog.Maximum = (int)totalBytes; //从总字节数得到进度条的最大值    
                System.IO.Stream st = myrp.GetResponseStream(); //从WEB请求创建流（读）    
                System.IO.Stream so = new System.IO.FileStream(Filename, System.IO.FileMode.Create); //创建文件流（写）    
                long totalDownloadedByte = 0; //下载文件大小    
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length); //读流    

                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte; //更新文件大小    
                    Application.DoEvents();
                    so.Write(by, 0, osize); //写流    
                    Prog.Value = (int)totalDownloadedByte; //更新进度条    
                    osize = st.Read(by, 0, (int)by.Length); //读流
                }
                so.Close(); //关闭流
                st.Close(); //关闭流
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>

        /// 下载带进度条代码(状态栏式进度条）
        /// </summary>

        /// <param name="URL">网址</param>

        /// <param name="Filename">文件名</param>

        /// <param name="Prog">状态栏式进度条ToolStripProgressBar</param>

        /// <returns>True/False是否下载成功</returns>
        public bool DownLoadFile(string URL, string Filename, ToolStripProgressBar Prog)
        {

            try
            {

                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL); //从URL地址得到一个WEB请求    

                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse(); //从WEB请求得到WEB响应    

                long totalBytes = myrp.ContentLength; //从WEB响应得到总字节数    

                Prog.Maximum = (int)totalBytes; //从总字节数得到进度条的最大值    

                System.IO.Stream st = myrp.GetResponseStream(); //从WEB请求创建流（读）    

                System.IO.Stream so = new System.IO.FileStream(Filename, System.IO.FileMode.Create); //创建文件流（写）    

                long totalDownloadedByte = 0; //下载文件大小    

                byte[] by = new byte[1024];

                int osize = st.Read(by, 0, (int)by.Length); //读流    

                while (osize > 0)
                {

                    totalDownloadedByte = osize + totalDownloadedByte; //更新文件大小    

                    Application.DoEvents();

                    so.Write(by, 0, osize); //写流    

                    Prog.Value = (int)totalDownloadedByte; //更新进度条    

                    osize = st.Read(by, 0, (int)by.Length); //读流    

                }

                so.Close(); //关闭流    

                st.Close(); //关闭流    

                return true;

            }

            catch
            {

                return false;

            }



        }
    }
}
