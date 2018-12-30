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
        public string GetSKUs(string userId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.Text, "SELECT DISTINCT VARIANT_SKU,PRODUCT_NAME FROM MST_PRODUCT_MASTER WHERE USER_ID=@USER_ID", sqlParameter);
            DataTable dt = new DataTable();
            if (ds != null)
            {
                dt = ds.Tables[0];
            }
            return Common.CommonModel.DATATABLETOJSON(dt);
        }
        public ResponseEntity LinkListing(string listingId, string systemSku, string userId)
        {

            ResponseEntity error = ResponseEntity.GetInstance();
            SqlParameter[] sqlParameter = new SqlParameter[11];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            sqlParameter[1] = new SqlParameter("@SYSTEM_SKU", systemSku);
            sqlParameter[2] = new SqlParameter("@LISTING_ID", listingId);
            sqlParameter[3] = new SqlParameter("@ERROR_FLAG", SqlDbType.NVarChar);
            sqlParameter[3].Direction = ParameterDirection.Output;
            sqlParameter[3].Size = 1;
            sqlParameter[4] = new SqlParameter("@ERROR_MSG", SqlDbType.Char);
            sqlParameter[4].Direction = ParameterDirection.Output;
            sqlParameter[4].Size = 2000;
            SqlHelper.ExecuteScalar(sqlconn, CommandType.StoredProcedure, "SP_LINK_LISTING", sqlParameter);
            error.ERROR_FLAG = sqlParameter[3].Value.ToString();
            error.ERROR_MSG = sqlParameter[4].Value.ToString();
            return error;
        }
    }
}