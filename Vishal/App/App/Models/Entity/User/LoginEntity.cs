using App.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Models.Entity.User
{
    public class LoginEntity
    {
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "UsernameReq")]
        public string userName { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "PasswordReq")]
        public string password { get; set; }
    }
}