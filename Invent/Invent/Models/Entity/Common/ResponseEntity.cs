using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Common
{

    public class ResponseEntity
    {
        private static ResponseEntity _instance;
        protected ResponseEntity()
        {

        }
        public static ResponseEntity GetInstance()
        {
            if (_instance == null) _instance = new ResponseEntity();
            return _instance;
        }
        public string ERROR_MSG { get; set; }
        public string ERROR_FLAG { get; set; }
        public string ADD_PARAM { get; set; }
    }
}