using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Configuration
{
    public class FlipkartEntity
    {
        private static FlipkartEntity _instance;
        public FlipkartEntity()
        {

        }
        public static FlipkartEntity GetInstance()
        {
            if (_instance == null) _instance = new FlipkartEntity();
            return _instance;
        }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ApplicationName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ApplicationId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ApplicationSecret { get; set; }
        public string LocationId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
        public char Status { get; set; }
        public char Flag { get; set; }
    }
}