using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Configuration
{
    public class AmazonApi
    {
        [Required(ErrorMessage = "Required")]
        public string SellerId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string MarketplaceId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string AccessKey { get; set; }
        [Required(ErrorMessage = "Required")]
        public string SecretKey { get; set; }
        [Required(ErrorMessage = "Required")]
        public string AuthToken { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        public string UserId { get; set; }
        public char Status { get; set; }
        public char Flag { get; set; }
    }
}