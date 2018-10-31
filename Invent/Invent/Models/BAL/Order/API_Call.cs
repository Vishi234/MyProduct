using Invent.Models.BAL.Common;
using Invent.Models.BAL.OrdersDetails;
using Invent.Models.Entity.Channel;
using Invent.Models.Entity.Common;
using Invent.Models.Entity.Configuration;
using Invent.Models.Entity.User;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

namespace Invent.Models.BAL.Order
{
    public static class API_Call
    {
        public static string OrderFetch(UserEntity objUserEntity)
        {
            string response = string.Empty;
            List<ChannelGeneralDetailsEntity> lstCh = new List<ChannelGeneralDetailsEntity>();
            lstCh = objUserEntity.ChannelDetails;
            List<OrderEntity> orderList = new List<OrderEntity>();
            OrderEntity order;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            #region Creating Order List
            for (int i = 0; i < lstCh.Count; i++)
            {
                response = string.Empty;

                if (lstCh[i].Ch_Prefix == "AZ")
                {
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
                        order.Title = item["Title"].ToString();
                        order.HSN = item["ASIN"].ToString();
                        order.OrderDate = orderData[j]["PurchaseDate"].ToString();
                        order.ShipDate = orderData[j]["LatestShipDate"].ToString();
                        order.Quantity = item["QuantityOrdered"].ToString();
                        order.SKU = item["SellerSKU"].ToString();
                        if (orderData[j]["PaymentMethod"] != null)
                        {
                            order.PaymentType = orderData[j]["PaymentMethod"].ToString();
                        }
                        if (orderData[j]["ItemPrice"] != null)
                        {
                            var sellPrice = item["ItemPrice"];
                            order.SellingPrice = sellPrice["Amount"].ToString();
                        }
                        if (orderData[j]["ShippingPrice"] != null)
                        {
                            var shipChrg = item["ShippingPrice"];
                            order.ShippingCharges = shipChrg["Amount"].ToString();
                        }

                        if (orderData[j]["OrderTotal"] != null)
                        {
                            var amt = orderData[j]["OrderTotal"];
                            order.TotalPrice = amt["Amount"].ToString();
                        }
                        else
                        {
                            order.TotalPrice = "-";
                        }

                        order.Status = orderData[j]["OrderStatus"].ToString();
                        order.Channel = "Amazon";
                        orderList.Add(order);
                    }
                }
                if (lstCh[i].Ch_Prefix == "FP")
                {

                    TokenEntity token = serializer.Deserialize<TokenEntity>(lstCh[i].ApiDetails);
                    FlipkartChannelModel fpCh = new FlipkartChannelModel();
                    response = fpCh.FlipkartOrders(token.access_token);
                    if (response != "")
                    {
                        var jsonObject = (JObject)JsonConvert.DeserializeObject(response);
                        var orderData = jsonObject["orderItems"];
                        for (int j = 0; j < orderData.Count(); j++)
                        {
                            order = new OrderEntity();

                            order.OrderId = orderData[j]["orderId"].ToString();
                            order.ItemId = orderData[j]["orderItemId"].ToString();
                            order.Title = orderData[j]["title"].ToString();
                            order.HSN = orderData[j]["hsn"].ToString();
                            order.OrderDate = orderData[j]["orderDate"].ToString();
                            order.ShipDate = orderData[j]["deliverByDate"].ToString();
                            order.Quantity = orderData[j]["quantity"].ToString();
                            order.ListingId = orderData[j]["listingId"].ToString();
                            order.SLA = orderData[j]["sla"].ToString();
                            order.Hold = orderData[j]["hold"].ToString();
                            order.SKU = orderData[j]["sku"].ToString();
                            order.PaymentType = orderData[j]["paymentType"].ToString();
                            order.SellingPrice = orderData[j]["priceComponents"]["sellingPrice"].ToString();
                            order.ShippingCharges = orderData[j]["priceComponents"]["shippingCharge"].ToString();
                            order.TotalPrice = orderData[j]["priceComponents"]["totalPrice"].ToString();
                            order.Status = orderData[j]["status"].ToString();
                            order.Channel = "Flipkart";
                            orderList.Add(order);
                        }
                    }

                }
            }
            #endregion
            string jsonString = serializer.Serialize(orderList);
            string result = new OrderModel().SaveOrderDetails(jsonString, objUserEntity.UserID, objUserEntity.EmailId);
            return "";
        }
    }
}