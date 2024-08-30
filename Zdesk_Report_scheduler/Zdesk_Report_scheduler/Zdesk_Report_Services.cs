using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Zdesk_Report_scheduler.BusinessLayar;
using System.Configuration;
using System.Reflection;

namespace Zdesk_Report_scheduler
{
   public class Zdesk_Report_Services
    {
        private readonly System.Timers.Timer _timer;
        static int Counter = 0;
        public Zdesk_Report_Services()
        {
            int TimerValue = 0;
            if (Counter == 0)
            {
                TimerValue = 18000;
            }
            else
            {
                TimerValue = 300000;
            }
            _timer = new System.Timers.Timer(TimerValue) { AutoReset = true };

            _timer.Elapsed += TimerElapsed;



        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            
            try
            {
                _timer.Interval = 300000;  // time for live
               
                string[] lines = new string[] { DateTime.Now.ToString() + "-Started" };
                File.AppendAllLines(@"C:\Service\ZdeskLogSGRLReport.txt", lines);
                string FromMail = ConfigurationManager.AppSettings["FromEmail"].ToString();
                string Password = @"SewaSRB@#$2005@&!@11177";
                int port = Convert.ToInt16(ConfigurationManager.AppSettings["Port"].ToString());
                string smpt = ConfigurationManager.AppSettings["Host"].ToString();
                string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
                string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
                BAL obj = new BAL(port, smpt, FromMail, Password, ConnectionString, FilePath);
                var Resutl = obj.ReportGenerate();
                if (Resutl == true)
                {
                    File.AppendAllLines(@"C:\Service\ZdeskLogSGRLReport.txt", lines);
                }
                else
                {
                    File.AppendAllLines(@"C:\Service\ZdeskLogSGRLReport.txt", lines);
                }

                //File.AppendAllLines(@"C:\Service\AssetMailLog.txt", new string[] { "Asset Mail Process Start" });
                //AssetMail asset = new AssetMail(port, smpt, FromMail, Password, ConnectionString, FilePath);
                //var assetResult = asset.AssetMailProcess();
                //if (assetResult == true)
                //{
                //    File.AppendAllLines(@"C:\Service\AssetMailLog.txt", new string[] { "Successfully End" });
                //}
                //else
                //{
                //    File.AppendAllLines(@"C:\Service\AssetMailLog.txt", new string[] { "End with Error" });
                //}

                //File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString()+ "\\HWMailLog.txt", new string[] { "Hardware Change Mail Process Start" });
                //HWChange hw = new HWChange(port, smpt, FromMail, Password, ConnectionString, FilePath);
                //var _hw = hw.HWMailProcess();
                //if (_hw == true)
                //{
                //    File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\HWMailLog.txt", new string[] { "Successfully End" });
                //}
                //else
                //{
                //    File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\HWMailLog.txt", new string[] { "End with Error" });
                //}
                _timer.Interval = 300000;
            }
            catch (Exception ex)
            {
                string[] error = new string[] { DateTime.Now.ToString() + "-Error" + ex.Message };
                File.AppendAllLines(@"C:\Service\ZdeskLogSGRLReport.txt", error);
            }
        }
        public void start()
        {
            _timer.Start();
        }
        public void stop()
        {
            _timer.Stop();
        }
    }
}
