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

namespace Invent.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        JavaScriptSerializer serializer;
        UserEntity objUserEntity;
        public ActionResult All_Orders()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetOrders(string orderType)
        {
            string response = string.Empty;
            objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            List<ChannelGeneralDetailsEntity> lstCh = new List<ChannelGeneralDetailsEntity>();
            lstCh = objUserEntity.ChannelDetails;
            List<OrderEntity> orderList = new List<OrderEntity>();
            OrderEntity order;
            for (int i = 0; i < lstCh.Count; i++)
            {
                response = string.Empty;

                if (lstCh[i].Ch_Prefix == "AZ")
                {
                    serializer = new JavaScriptSerializer();
                    AmazonEntity amazon = serializer.Deserialize<AmazonEntity>(lstCh[i].ApiDetails);
                    AmazonChannelModel aCh = new AmazonChannelModel();
                    response = aCh.AmazonOrders(amazon.AccessKey, amazon.SecretKey, amazon.SellerId, amazon.AuthToken, amazon.MarketplaceId);
                    var jsonObject = (JObject)JsonConvert.DeserializeObject(response);
                    var orderData = jsonObject["ListOrdersResponse"]["ListOrdersResult"]["Orders"]["Order"];
                    for (int j = 0; j < orderData.Count(); j++)
                    {
                        order = new OrderEntity();
                        response = aCh.SingleOrderDetails(amazon.AccessKey, amazon.SecretKey, amazon.SellerId, amazon.AuthToken, orderData[j]["AmazonOrderId"].ToString());
                        jsonObject = (JObject)JsonConvert.DeserializeObject(response);
                        var item = jsonObject["ListOrderItemsResponse"]["ListOrderItemsResult"]["OrderItems"]["OrderItem"];
                        order.OrderId = orderData[j]["AmazonOrderId"].ToString();
                        order.ItemId = item["OrderItemId"].ToString();
                        order.ProductInfo = item["Title"].ToString();
                        order.OrderDate = orderData[j]["PurchaseDate"].ToString();
                        order.ShipDate = orderData[j]["LatestShipDate"].ToString();
                        order.Status = orderData[j]["OrderStatus"].ToString();
                        if (orderData[j]["OrderTotal"] != null)
                        {
                            var amt = orderData[j]["OrderTotal"];
                            order.Amount = amt["Amount"].ToString();
                        }
                        else
                        {
                            order.Amount = "-";
                        }
                        order.Channel = "Amazon";
                        orderList.Add(order);
                    }
                }
                //if (lstCh[i].Ch_Prefix == "FP")
                //{

                //    TokenEntity token = serializer.Deserialize<TokenEntity>(lstCh[i].ApiDetails);
                //    FlipkartChannelModel fpCh = new FlipkartChannelModel();
                //    response = fpCh.FlipkartOrders(token.access_token);
                //    var jsonObject = (JObject)JsonConvert.DeserializeObject(response);
                //    var orderData = jsonObject["orderItems"];
                //    for (int j = 0; j < orderData.Count(); j++)
                //    {
                //        order = new OrderEntity();
                //        order.OrderId = orderData[j]["orderId"].ToString();
                //        order.ItemId = orderData[j]["orderItemId"].ToString();
                //        order.ProductInfo = orderData[j]["title"].ToString();
                //        order.OrderDate = orderData[j]["orderDate"].ToString();
                //        order.ShipDate = orderData[j]["deliverByDate"].ToString();
                //        order.Status = orderData[j]["status"].ToString();
                //        order.Channel = "Flipkart";
                //        order.Amount = orderData[j]["priceComponents"]["totalPrice"].ToString();
                //        orderList.Add(order);
                //    }
                //}
            }
            AmazonEntity amApi = new AmazonEntity();

            return Json(orderList);
        }

    }
}