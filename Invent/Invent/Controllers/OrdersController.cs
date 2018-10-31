using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Configuration;
using RestSharp;
using Invent.Models.Entity.User;
using System.Web.Script.Serialization;
using Invent.Models.Entity.Configuration;
using Invent.Models.BAL.Order;
using Invent.Models.Entity.Common;
using Invent.Models.BAL.OrdersDetails;
using Invent.Models.Entity.Channel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Invent.Models.BAL.Common;
using Hangfire;
using Hangfire.SqlServer;

namespace Invent.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        JavaScriptSerializer serializer;
        UserEntity objUserEntity;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetOrders(string orderType)
        {
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            BackgroundJob.Schedule(() => API_Call.OrderFetch(objUserEntity), TimeSpan.FromMilliseconds(3000));
            return Json("");
        }
    }

}
