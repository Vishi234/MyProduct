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

namespace Invent.Models.BAL.Order
{
    public class ChannelOrdersModel
    {
        string response = string.Empty;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        public string GetOrders(UserEntity objUserEntity, string fromDate, string toDate, List<string> status)
        {
            List<ChannelGeneralDetailsEntity> lstCh = new List<ChannelGeneralDetailsEntity>();
            lstCh = objUserEntity.ChannelDetails;

            List<OrderEntity> objOrderEntityLst = new List<OrderEntity>();
            OrderEntity order;

            for (int i = 0; i < lstCh.Count; i++)
            {
                response = string.Empty;
                if (lstCh[i].Ch_Prefix == "AZ")
                {
                    AmazonEntity objAzEntity = serializer.Deserialize<AmazonEntity>(lstCh[i].ApiDetails);
                    AmazonChannelModel objAzModel = new AmazonChannelModel();
                    response = objAzModel.GetAmazonOrders(objAzEntity.AccessKey, objAzEntity.SecretKey, objAzEntity.SellerId, objAzEntity.AuthToken, objAzEntity.MarketplaceId, fromDate, toDate, "", "", 20, status);
                    var jsonOrder = (JObject)JsonConvert.DeserializeObject(response);
                    var orderList = jsonOrder["ListOrdersResponse"]["ListOrdersResult"]["Orders"]["Order"];
                    for (int j = 0; j < orderList.Count(); j++)
                    {
                        order = new OrderEntity();
                        response = objAzModel.OrderItem(objAzEntity.AccessKey, objAzEntity.SecretKey, objAzEntity.SellerId, objAzEntity.AuthToken, orderList[j]["AmazonOrderId"].ToString());
                        jsonOrder = (JObject)JsonConvert.DeserializeObject(response);
                        var item = jsonOrder["ListOrderItemsResponse"]["ListOrderItemsResult"]["OrderItems"]["OrderItem"];
                        order.OrderId = orderList[j]["AmazonOrderId"].ToString();
                        order.ItemId = item["OrderItemId"].ToString();
                        order.Title = item["Title"].ToString();
                        order.HSN = item["ASIN"].ToString();
                        order.OrderDate = orderList[j]["PurchaseDate"].ToString();
                        order.ShipDate = orderList[j]["LatestShipDate"].ToString();
                        order.Quantity = item["QuantityOrdered"].ToString();
                        order.SKU = item["SellerSKU"].ToString();
                        if (orderList[j]["PaymentMethod"] != null)
                        {
                            order.PaymentType = orderList[j]["PaymentMethod"].ToString();
                        }
                        if (orderList[j]["ItemPrice"] != null)
                        {
                            var sellPrice = item["ItemPrice"];
                            order.SellingPrice = sellPrice["Amount"].ToString();
                        }
                        if (orderList[j]["ShippingPrice"] != null)
                        {
                            var shipChrg = item["ShippingPrice"];
                            order.ShippingCharges = shipChrg["Amount"].ToString();
                        }

                        if (orderList[j]["OrderTotal"] != null)
                        {
                            var amt = orderList[j]["OrderTotal"];
                            order.TotalPrice = amt["Amount"].ToString();
                        }
                        else
                        {
                            order.TotalPrice = "-";
                        }

                        order.Status = orderList[j]["OrderStatus"].ToString();
                        order.Channel = "Amazon";
                        objOrderEntityLst.Add(order);
                    }
                }
                if (lstCh[i].Ch_Prefix == "FP")
                {
                    TokenEntity token = serializer.Deserialize<TokenEntity>(lstCh[i].ApiDetails);
                    FlipkartChannelModel objFpModel = new FlipkartChannelModel();
                    response = objFpModel.FlipkartOrders(token.access_token);
                    if (response != "")
                    {
                        var jsonOrder = (JObject)JsonConvert.DeserializeObject(response);
                        var orderList = jsonOrder["orderItems"];
                        for (int j = 0; j < orderList.Count(); j++)
                        {
                            order = new OrderEntity();
                            order.OrderId = orderList[j]["orderId"].ToString();
                            order.ItemId = orderList[j]["orderItemId"].ToString();
                            order.Title = orderList[j]["title"].ToString();
                            order.HSN = orderList[j]["hsn"].ToString();
                            order.OrderDate = orderList[j]["orderDate"].ToString();
                            order.ShipDate = orderList[j]["deliverByDate"].ToString();
                            order.Quantity = orderList[j]["quantity"].ToString();
                            order.ListingId = orderList[j]["listingId"].ToString();
                            order.SLA = orderList[j]["sla"].ToString();
                            order.Hold = orderList[j]["hold"].ToString();
                            order.SKU = orderList[j]["sku"].ToString();
                            order.PaymentType = orderList[j]["paymentType"].ToString();
                            order.SellingPrice = orderList[j]["priceComponents"]["sellingPrice"].ToString();
                            order.ShippingCharges = orderList[j]["priceComponents"]["shippingCharge"].ToString();
                            order.TotalPrice = orderList[j]["priceComponents"]["totalPrice"].ToString();
                            order.Status = orderList[j]["status"].ToString();
                            order.Channel = "Flipkart";
                            objOrderEntityLst.Add(order);
                        }
                    }
                }
            }
            response = serializer.Serialize(objOrderEntityLst);
            return response;
        }
    }
}