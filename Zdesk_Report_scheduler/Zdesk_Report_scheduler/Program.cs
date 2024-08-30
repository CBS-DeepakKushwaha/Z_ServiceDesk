using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Zdesk_Report_scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Zdesk_Report_Services>(s =>
                {
                    s.ConstructUsing(zdesk => new Zdesk_Report_Services());
                    s.WhenStarted(zdesk => zdesk.start());
                    s.WhenStopped(zdesk => zdesk.stop());
                });
                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.SetDisplayName("Zdesk_Report_Service_SGRL");
                x.SetServiceName("Zdesk_Report_Service_SGRL");
                x.SetDescription("For Run the report Scheduler SGRL");
            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
