using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.Entity
{
    public class UserEntity
    {
        private static UserEntity _instance;
        protected UserEntity()
        {

        }
        public static UserEntity GetInstance()
        {
            if (_instance == null) _instance = new UserEntity();
            return _instance;
        }
        public string USER_ID { get; set; }
        public string COMPANY_NAME { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string FULL_NAME { get; set; }
        public string MOBILE_NO { get; set; }
        public string ACCOUNT_LOCKED { get; set; }
        public string ACTIVE_USER { get; set; }
        public string IP_ADDRESS { get; set; }
        public string LAST_LOGIN { get; set; }
        public string CONFIG_STATUS { get; set; }
    }
}