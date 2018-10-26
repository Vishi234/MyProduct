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

namespace Invent.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        JavaScriptSerializer serializer;
        UserEntity objUserEntity;
        public ActionResult All_Orders()
        {
            var client = new RestClient("https://api.flipkart.net/sellers/orders/search");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "55bb30eb-61f8-0046-c6a5-3454c2af633d");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer 153298a3-c82f-4171-9c12-bf0d15eb0ffd");
            request.AddParameter("application/json", "{\"filter\" :{}}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return View();
        }
        [HttpPost]
        public JsonResult GetOrders()
        {
            objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];

            return Json("");
        }

    }
}