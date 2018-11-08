using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Channel
{
    public class OrderEntity
    {
        public string UserId { get; set; }
        public string EmailId { get; set; }
        public string OrderId { get; set; }
        public string ItemId { get; set; }
        public string HSN { get; set; }
        public string Hold { get; set; }
        public string OrderDate { get; set; }
        public string ShipDate { get; set; }
        public string SLA { get; set; }
        public string Quantity { get; set; }
        public string Title { get; set; }
        public string ListingId { get; set; }
        public string SKU { get; set; }
        public string PaymentType { get; set; }
        public string CurrencyCode { get; set; }
        public string SellingPrice { get; set; }
        public string ShippingCharges { get; set; }
        public string TotalPrice { get; set; }
        public string Channel { get; set; }
        public string LastSync { get; set; }
        public string Status { get; set; }
        public string Flag { get; set; }
    }
}