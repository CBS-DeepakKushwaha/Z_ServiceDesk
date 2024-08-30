using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Zdesk_Report_scheduler.BusinessLayar
{
   public class ReportSchedulerModel
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int schedulerTypeId { get; set; }
        public TimeSpan Time { get; set; }
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string Subject { get; set; }
    }
}
