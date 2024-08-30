using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using PetaPoco;
using Api_ZserviceDesk.Models;
using System.IO;
using System.Web;

namespace Api_ZserviceDesk.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VendorDashboardController : ApiController
    {
        [HttpPost]
        public IEnumerable<Charts> GetChartData(Charts_Params c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<Charts>("exec zdesk_get_vendor_dashboard_sp @Section,@Param1", new { c.Section,c.Param1 });
        }
    }
}
