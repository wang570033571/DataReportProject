using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using 框架;
using System.IO;


namespace ERP
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 初始化应用程序
            InitApplication();
            // 打开程序
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 主界面());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            消息.显示(e.Exception);
        }

        /// <summary>
        /// 初始化应用程序
        /// </summary>
        private static void InitApplication()
        {
            System.Threading.Thread currentThread = System.Threading.Thread.CurrentThread;
            System.Globalization.CultureInfo cultureInfoNew = (System.Globalization.CultureInfo)currentThread.CurrentCulture.Clone();

            // 检查关键文件
            if (!File.Exists(Application.StartupPath + "\\" + "框架.dll"))
            {
                MessageBox.Show("无法找到文件[框架],启动失败", "致命错误");
                Application.Exit();
            }

            if (!File.Exists(Application.StartupPath + "\\" + "DevExpress.Localization.v9.3.dll"))
            {
                MessageBox.Show("无法找到文件[DevExpress.Localization.v9.3.dll],启动失败");
                Application.Exit();
            }

            // 日期设置
            cultureInfoNew.DateTimeFormat.FullDateTimePattern = "yyyy-MM-dd HH:mm:ss";
            cultureInfoNew.DateTimeFormat.LongDatePattern = "yyyy-MM-dd";
            cultureInfoNew.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            cultureInfoNew.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            cultureInfoNew.DateTimeFormat.ShortTimePattern = "HH:mm:ss";
            currentThread.CurrentCulture = cultureInfoNew;
            // Dev控件汉化
            DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS();
            DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPivotGridLocalizationCHS();
        }
    }
}
