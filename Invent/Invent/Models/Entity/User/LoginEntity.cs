using Invent.assets.lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Invent.Models.Entity.User
{
    public class LoginEntity
    {
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "EmailReq")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid email address.")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "PasswordReq")]
        public string Password { get; set; }
    }
}