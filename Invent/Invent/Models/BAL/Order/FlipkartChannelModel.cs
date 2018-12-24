using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Invent.Models.BAL.OrdersDetails
{
    public class FlipkartChannelModel
    {
        public string FlipkartOrders(string token, string fromDate, string toDate, string searchKey)
        {
            var odFrom = Convert.ToDateTime(fromDate);
            var odTo = Convert.ToDateTime(toDate);
            var client = new RestClient(ConfigurationManager.AppSettings["FlipkartApi"] + "v2/orders/search");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "55bb30eb-61f8-0046-c6a5-3454c2af633d");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + token);
            request.AddParameter("application/json", "{\"filter\" :{\"orderDate\":{\"fromDate\":\"" + odFrom.ToString("yyyy-MM-dd HH:mm:ss").Replace(" ", "T") + "\",\"toDate\": \"" + odTo.ToString("yyyy-MM-dd HH:mm:ss").Replace(" ", "T") + "Z\"}}}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}