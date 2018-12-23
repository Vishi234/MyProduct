using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Common
{
    public class TokenEntity
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string scope { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationSecret { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}