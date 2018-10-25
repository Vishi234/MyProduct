using Invent.assets.lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Invent.Models.Entity.User
{
    public class RegisterModel
    {
        public string UserID { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "CompanyNameReq")]
        public string CompanyName { get; set; }
        public string DisplayName { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "FirstNameReq")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "EmailReq")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid email address.")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "PasswordReq")]
        [MembershipPassword(
        MinRequiredNonAlphanumericCharacters = 1,
        MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
        ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
        MinRequiredPasswordLength = 6
        )]
        public string Password { get; set; }
        [Required(ErrorMessageResourceType = typeof(en_msg_lang), ErrorMessageResourceName = "ConfirmPassReq")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
        [Range(typeof(bool),"true", "true", ErrorMessage = "Please accept our Terms & Condition.")]
        public bool Accept { get; set; }
        public string VerCode { get; set; }
        public Char Flag { get; set; }
        public string Msg { get; set; }
        public string ErrorFlag { get; set; }
        public string POUserId { get; set; } 
    }
}