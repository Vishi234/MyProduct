using Invent.assets.lang;
using Invent.Models.Entity.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invent.Models.Entity.User
{
    public class  UserEntity
    {
        public string UserID { get; set; }
        public string EmailId { get; set; }
        public string CompanyName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePic { get; set; }
        public string Lock { get; set; }
        public string Pan { get; set; }
        public string Tin { get; set; }
        public string GSTIN { get; set; }
        public string B_AddressLine1 { get; set; }
        public string B_Country { get; set; }
        public string B_AddressLine2 { get; set; }
        public string B_State { get; set; }
        public string B_City { get; set; }
        public string B_PinCode { get; set; }
        public string B_Phone { get; set; }
        public string S_AddressLine1 { get; set; }
        public string S_Country { get; set; }
        public string S_AddressLine2 { get; set; }
        public string S_State { get; set; }
        public string S_City { get; set; }
        public string S_PinCode { get; set; }
        public string S_Phone { get; set; }
        public string Status { get; set; }
        public string Verified { get; set; }
        public List<ChannelGeneralDetailsEntity> ChannelDetails { get; set; }
        
    }
}