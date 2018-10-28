using Invent.assets.lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Configuration
{
    public class UserAccountingEntity
    {
        public string UserId { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "PANReq")]
        public string PAN { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "TINReq")]
        public string TIN { get; set; }
        public string GSTIN { get; set; }
        public string Flag { get; set; }
    }
}