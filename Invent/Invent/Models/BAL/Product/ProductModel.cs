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
        public string GetListing(string isLinked, string isEnable, string sku, string fromDate, string toDate, string userId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[6];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            sqlParameter[1] = new SqlParameter("@SKU", sku);
            sqlParameter[2] = new SqlParameter("@IS_ENABLE", Convert.ToChar(isEnable));
            sqlParameter[3] = new SqlParameter("@IS_LINKED", Convert.ToChar(isLinked));
            sqlParameter[4] = new SqlParameter("@FROM_DATE", fromDate);
            sqlParameter[5] = new SqlParameter("@TO_DATE", toDate);
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_GET_LISTING_DETAILS", sqlParameter);
            DataTable dt = new DataTable();
            if (ds != null)
            {
                dt = ds.Tables[0];
            }
            return Common.CommonModel.DATATABLETOJSON(dt);
        }
        public string GetInventory(string userId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_GET_INVENTORY", sqlParameter);
            DataTable dt = new DataTable();
            if (ds != null)
            {
                dt = ds.Tables[0];
            }
            return Common.CommonModel.DATATABLETOJSON(dt);
        }
    }
}