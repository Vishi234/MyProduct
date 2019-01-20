using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.Entity.AuthEntity
{
    public class RegisterEntity
    {
        public string company { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
        public string verification { get; set; }
        public string flag { get; set; }
        public string msg { get; set; }
    }
}