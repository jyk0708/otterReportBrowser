using System;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using OtterReportBrowser.handler;
using System.ComponentModel;

namespace OtterReportBrowser
{
    public partial class OtterReportBrowser : UserControl
    {
        public OtterReportBrowser()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                InitializeComponent();
            InitBrowser();
        }


        public void InitBrowser()
        {
            //            string url = "http://192.168.0.241:8888/ureport/preview?_u=db:沌口水厂中心调度室运行日报&_t=6";
            string url = "http://www.baidu.com";

            CefSettings cefSettings = new CefSettings
            {
                Locale = "zh-CN",
                AcceptLanguageList = "zh-CN",
                MultiThreadedMessageLoop = true
            };

            Cef.Initialize(cefSettings);

            ChromiumWebBrowser Browser = new ChromiumWebBrowser(Uri.EscapeUriString(url))
            {
                Dock = DockStyle.Fill,
                DownloadHandler = new DownLoaderHandler(),
                LifeSpanHandler = new LifeSpanHandler()
            };
            this.Controls.Add(Browser);

        }
    }
}
