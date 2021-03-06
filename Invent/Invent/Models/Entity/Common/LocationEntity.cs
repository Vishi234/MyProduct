﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Common
{
    public class LocationEntity
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string StateId { get; set; }
        public string StateName { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
    }
}