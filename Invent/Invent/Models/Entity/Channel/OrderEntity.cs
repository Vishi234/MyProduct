using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Channel
{
    public class OrderEntity
    {
        public string OrderId { get; set; }
        public string ItemId { get; set; }
        public string Channel { get; set; }
        public string ProductInfo { get; set; }
        public string BuyerInfo { get; set; }
        public string OrderDate { get; set; }
        public string ShipDate { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
    }
}