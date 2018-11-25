using Invent.assets.lang;
using Invent.Models.BAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invent.Models.Entity.Configuration
{
    public class UserBillingEntity
    {
        private static UserBillingEntity _instance;
        public UserBillingEntity()
        {
            this.Country = new List<SelectListItem>();
            this.State = new List<SelectListItem>();
            this.City = new List<SelectListItem>();

            this.S_Country = new List<SelectListItem>();
            this.S_State = new List<SelectListItem>();
            this.S_City = new List<SelectListItem>();
        }
        public static UserBillingEntity GetInstance()
        {
            if (_instance == null) _instance = new UserBillingEntity();
            return _instance;
        }

        public string UserId { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "AddressReq")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public List<SelectListItem> Country { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "CountryReq")]
        public int CountryId { get; set; }


        public List<SelectListItem> State { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "StateReq")]
        public int StateId { get; set; }

        public List<SelectListItem> City { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "CityReq")]
        public int CityId { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "PhoneReq")]
        public string Phone { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "PinCode")]
        public string PinCode { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "AddressReq")]
        public string S_AddressLine1 { get; set; }
        public string S_AddressLine2 { get; set; }

        public List<SelectListItem> S_Country { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "CountryReq")]
        public int S_CountryId { get; set; }

        public List<SelectListItem> S_State { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "StateReq")]
        public int S_StateId { get; set; }

        public List<SelectListItem> S_City { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "CityReq")]
        public int S_CityId { get; set; }

        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "PhoneReq")]
        public string S_Phone { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "PinCode")]
        public string S_PinCode { get; set; }
        public string Flag { get; set; }
    }
}