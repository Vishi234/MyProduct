using Invent.Models.BAL.Common;
using Invent.Models.BAL.Order;
using Invent.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Invent
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //GlobalFilters.Filters.Add(new SessionExpireAttribute());
            JobScheduler.Start();
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            //JobScheduler.Start();
        }
    }
}
