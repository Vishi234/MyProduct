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

namespace Invent.Models.BAL.Product
{
    public class ProductModel
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        public string GetProducts(string productId, string userId, string status)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[3];
            sqlParameter[0] = new SqlParameter("@PRODUCT_ID", productId);
            sqlParameter[1] = new SqlParameter("@USER_ID", userId);
            sqlParameter[2] = new SqlParameter("@STATUS", Convert.ToChar(status));
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_GET_PRODUCT_DETAILS", sqlParameter);
            DataTable dt = new DataTable();
            if (ds != null)
            {
                dt = ds.Tables[0];
            }

            return Common.CommonModel.DATATABLETOJSON(dt);
        }
    }
}