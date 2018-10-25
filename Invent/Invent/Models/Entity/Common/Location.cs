using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Common
{
    public class Location
    {
        public string COUNTRY_ID { get; set; }
        public string COUNTRY_NAME { get; set; }
        public string STATE_ID { get; set; }
        public string STATE_NAME { get; set; }
        public string CITY_ID { get; set; }
        public string CITY_NAME { get; set; }
    }
}