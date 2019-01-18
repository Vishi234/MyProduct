using App.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App.Models.BAL.Authorization
{
    public class Auth
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        public Response UserAuthorization(string email ,string password)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            sqlParameter[0] = new SqlParameter("@EMAIL", email);
            sqlParameter[1] = new SqlParameter("@PASSWORD", password);
            sqlParameter[2] = new SqlParameter("@MSG", SqlDbType.NVarChar);
            sqlParameter[2].Direction = ParameterDirection.Output;
            sqlParameter[2].Size = 2000;
            sqlParameter[3] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[3].Direction = ParameterDirection.Output;
            sqlParameter[3].Size = 1;

        }

    }
}