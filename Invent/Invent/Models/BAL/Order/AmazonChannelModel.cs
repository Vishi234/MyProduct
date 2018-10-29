using AmazonAPI.Orders;
using AmazonAPI.Orders.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Invent.Models.BAL.Order
{
    public class AmazonChannelModel
    {
        string appName = "MyOrders";
        string appVersion = "1.0";
        string service = ConfigurationManager.AppSettings["AmazonAPI"];
        CultureInfo provider = CultureInfo.InvariantCulture;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        public string AmazonOrders(string accessKey, string secretKey, string sellerId, string authToken, string marketId)
        {
            OrderConfiguration config = new OrderConfiguration();
            config.ServiceURL = service;
            Orders objCl = new OrderClient(accessKey, secretKey, appName, appVersion, config);
            IMWSResponse response = null;
            ListOrdersRequest request = new ListOrdersRequest();
            request.SellerId = sellerId;
            request.MWSAuthToken = authToken;
            string dateString = "2018-10-01";
            DateTime createdAfter = new DateTime();
            request.CreatedAfter = createdAfter;
            //DateTime createdBefore = new DateTime();
            //request.CreatedBefore = createdBefore;
            List<string> orderStatus = new List<string>();
            request.OrderStatus = orderStatus;
            List<string> marketplaceId = new List<string>();
            marketplaceId.Add(marketId);
            request.MarketplaceId = marketplaceId;
            List<string> fulfillmentChannel = new List<string>();
            request.FulfillmentChannel = fulfillmentChannel;
            List<string> paymentMethod = new List<string>();
            request.PaymentMethod = paymentMethod;
            string buyerEmail = "";
            request.BuyerEmail = buyerEmail;
            string sellerOrderId = "";
            request.SellerOrderId = sellerOrderId;
            decimal maxResultsPerPage = 10;
            request.MaxResultsPerPage = maxResultsPerPage;
            List<string> tfmShipmentStatus = new List<string>();
            request.TFMShipmentStatus = tfmShipmentStatus;
            response = objCl.ListOrders(request);
            ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;
            return Common.CommonModel.XMLTOJSON(response.ToXML());
        }

        public string SingleOrderDetails(string accessKey, string secretKey, string sellerId, string authToken,string orderId)
        {
            OrderConfiguration config = new OrderConfiguration();
            config.ServiceURL = service;
            Orders objCl = new OrderClient(accessKey, secretKey, appName, appVersion, config);
            IMWSResponse response = null;
            ListOrderItemsRequest request = new ListOrderItemsRequest();
            request.SellerId = sellerId;
            request.MWSAuthToken = authToken;
            request.AmazonOrderId = orderId;
            response = objCl.ListOrderItems(request);
            ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;
            return Common.CommonModel.XMLTOJSON(response.ToXML());
        }
    }
}