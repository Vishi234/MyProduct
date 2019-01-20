using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.Entity
{
    public class Response
    {
        private static Response _instance;
        protected Response()
        {

        }
        public static Response GetInstance()
        {
            if (_instance == null) _instance = new Response();
            return _instance;
        }
        public string ERROR_MSG { get; set; }
        public string ERROR_FLAG { get; set; }
        public string ADD_PARAM { get; set; }
    }
}