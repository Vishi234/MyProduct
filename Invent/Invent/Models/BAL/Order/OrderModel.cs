using DAL;
using Invent.Models.Entity.Channel;
using Invent.Models.Entity.Common;
using Invent.Models.Entity.User;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Invent.Models.BAL.Order
{
    public class OrderModel
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        public string SaveOrderDetails(string jsonString, string userId, string emailid)
        {
            SqlParameter[] sqlParameter = new SqlParameter[7];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            sqlParameter[1] = new SqlParameter("@EMAIL_ID", emailid);
            sqlParameter[2] = new SqlParameter("@JSON_DATA", jsonString);
            sqlParameter[3] = new SqlParameter("@LAST_SYNC", DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"));
            sqlParameter[4] = new SqlParameter("@FLAG", "A");
            sqlParameter[5] = new SqlParameter("@ERROR_MSG", SqlDbType.NVarChar);
            sqlParameter[5].Direction = ParameterDirection.Output;
            sqlParameter[5].Size = 2000;
            sqlParameter[6] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[6].Direction = ParameterDirection.Output;
            sqlParameter[6].Size = 1;
            SqlHelper.ExecuteScalar(sqlconn, CommandType.StoredProcedure, "SP_MANAGE_ORDERS", sqlParameter);
            ResponseEntity error = ResponseEntity.GetInstance();
            error.ERROR_MSG = sqlParameter[5].Value.ToString();
            error.ERROR_FLAG = sqlParameter[6].Value.ToString();
            return "";
        }
        public string GetOrders(string userId, string channelName, string orderDate, string orderStatus)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[7];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            sqlParameter[1] = new SqlParameter("@CHANNEL_NAME", channelName);
            sqlParameter[2] = new SqlParameter("@ORDER_DATE", orderDate);
            sqlParameter[3] = new SqlParameter("@ORDER_STATUS", orderStatus);
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_GET_ORDERS", sqlParameter);
            DataTable dt = new DataTable();
            if (ds != null)
            {
                dt = ds.Tables[0];
            }

            return Common.CommonModel.DATATABLETOJSON(dt);
        }
    }
}