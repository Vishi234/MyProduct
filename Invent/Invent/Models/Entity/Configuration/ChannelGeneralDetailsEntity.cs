using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Configuration
{
    public class ChannelGeneralDetailsEntity
    {
        [Required(ErrorMessage ="Required")]
        public string ChannelName { get; set; }
        public string LeadgerName { get; set; }
        public bool OrderSync { get; set; }
        public bool InventorySync { get; set; }
        public string ApiDetails { get; set; }
        public string Ch_Prefix { get; set; }
    }
}