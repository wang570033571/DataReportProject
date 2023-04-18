using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 框架
{
    public static class 配置文件
    {
        private static string 文件 = Application.StartupPath + "/" + "Config.xml";

        public static string 读取(string 键, string 默认值)
        {
            try
            {
                string 返回值;
                返回值 = XML操作.读取(文件, "连接字符串/" + 键, "");
                if (返回值 == "") 返回值=默认值;
                return 返回值;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void 写入(string 键, string 值)
        {
            try
            {
                XML操作.更新(文件, "连接字符串/" + 键, "", 值);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
