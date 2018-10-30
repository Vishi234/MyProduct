using Invent.Models.Entity.Channel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Invent.Models.BAL.Order
{
    public class OrderModel
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        //public string SaveOrderDetails(List<OrderEntity> orderEntity)
        //{
        //    SqlParameter[] sqlParameter = new SqlParameter[11];
        //    sqlParameter[0] = new SqlParameter("@USER_ID", regModel.UserID);
        //    sqlParameter[1] = new SqlParameter("@COMAPNY_NAME", regModel.CompanyName);
        //    sqlParameter[2] = new SqlParameter("@FIRST_NAME", regModel.FirstName);
        //    sqlParameter[3] = new SqlParameter("@LAST_NAME", regModel.LastName);
        //    sqlParameter[4] = new SqlParameter("@EMAIL_ID", regModel.EmailAddress);
        //    sqlParameter[5] = new SqlParameter("@PASSWORD", regModel.Password);
        //    sqlParameter[6] = new SqlParameter("@VER_CODE", regModel.VerCode);
        //    sqlParameter[7] = new SqlParameter("@FLAG", regModel.Flag);
        //    sqlParameter[8] = new SqlParameter("@MSG", SqlDbType.NVarChar);
        //    sqlParameter[8].Direction = ParameterDirection.Output;
        //    sqlParameter[8].Size = 2000;
        //    sqlParameter[9] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
        //    sqlParameter[9].Direction = ParameterDirection.Output;
        //    sqlParameter[9].Size = 1;
        //    sqlParameter[10] = new SqlParameter("@PO_USER_ID", SqlDbType.NVarChar);
        //    sqlParameter[10].Direction = ParameterDirection.Output;
        //    sqlParameter[10].Size = 100;
        //    DataSet ds = new DataSet();
        //    ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_CHECK_LOGIN", sqlParameter);
        //    regModel.Msg = sqlParameter[8].Value.ToString();
        //    regModel.ErrorFlag = sqlParameter[9].Value.ToString();
        //    regModel.UserID = sqlParameter[10].Value.ToString();
        //}
    }
}