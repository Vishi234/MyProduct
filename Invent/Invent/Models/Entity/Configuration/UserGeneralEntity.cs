﻿using Invent.assets.lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Configuration
{
    public class UserGeneralEntity
    {
        private static UserGeneralEntity _instance;
        public UserGeneralEntity()
        {

        }
        public static UserGeneralEntity GetInstance()
        {
            if (_instance == null) _instance = new UserGeneralEntity();
            return _instance;
        }
        public string UserId { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "EmailReq")]
        public string EmailId { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "CompanyNameReq")]
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "DisplayNameReq")]
        public string DisplayName { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "FirstNameReq")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string ProfilePic { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string Flag { get; set; }
    }
}