using DAL;
using Invent.Models.Entity.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Invent.Models.BAL.Setting
{
    public class ItemMasterModel
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        public void SaveItemsMaster(string userId, string jsonData, string flag)
        {
            ResponseEntity error = ResponseEntity.GetInstance();
            SqlParameter[] sqlParameter = new SqlParameter[5];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            sqlParameter[1] = new SqlParameter("@JSON_DATA", jsonData);
            sqlParameter[2] = new SqlParameter("@FLAG", flag);
            sqlParameter[3] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[3].Direction = ParameterDirection.Output;
            sqlParameter[3].Size = 1;
            sqlParameter[4] = new SqlParameter("@ERROR_MSG", SqlDbType.NVarChar);
            sqlParameter[4].Direction = ParameterDirection.Output;
            sqlParameter[4].Size = 100;
            SqlHelper.ExecuteNonQuery(sqlconn, CommandType.StoredProcedure, "SP_MANAGE_ITEM_MASTER", sqlParameter);
            error.ERROR_FLAG = sqlParameter[3].Value.ToString();
            error.ERROR_MSG = sqlParameter[4].Value.ToString();
        }
    }
}