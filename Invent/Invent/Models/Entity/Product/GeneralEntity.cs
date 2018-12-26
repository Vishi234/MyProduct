using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Product
{
    public class GeneralEntity
    {
        public string productName { get; set; }
        public string productSku { get; set; }
        public string category { get; set; }
        public string warehouse { get; set; }
        public string hsnCode { get; set; }
        public string color { get; set; }
        public string brand { get; set; }
        public string size { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public string weight { get; set; }
        public string tax { get; set; }
        public string tags { get; set; }
        public string description { get; set; }

    }
}