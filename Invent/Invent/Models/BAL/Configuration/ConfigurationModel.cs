using DAL;
using Invent.Models.BAL.Common;
using Invent.Models.Entity.Common;
using Invent.Models.Entity.Configuration;
using Invent.Models.Entity.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invent.Models.BAL.Configuration
{
    public class ConfigurationModel
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        private Dictionary<string, object> aDict;
        private static ConfigurationModel _instance;
        protected ConfigurationModel()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
        }
        public static ConfigurationModel GetInstance()
        {
            if (_instance == null) _instance = new ConfigurationModel();
            return _instance;
        }

        public ResponseEntity SaveGeneralDetails(UserGeneralEntity gDtl)
        {
            SqlParameter[] sqlParameter = new SqlParameter[11];
            sqlParameter[0] = new SqlParameter("@USER_ID", gDtl.UserId);
            sqlParameter[1] = new SqlParameter("@COMPANY_NAME", gDtl.CompanyName);
            sqlParameter[2] = new SqlParameter("@DISPLAY_NAME", gDtl.DisplayName);
            sqlParameter[3] = new SqlParameter("@FIRST_NAME", gDtl.FirstName);
            sqlParameter[4] = new SqlParameter("@LAST_NAME", gDtl.LastName);
            sqlParameter[5] = new SqlParameter("@EMAIL_ID", gDtl.EmailId);
            sqlParameter[6] = new SqlParameter("@STATUS", gDtl.Status);
            sqlParameter[7] = new SqlParameter("@PROFILE_PIC", gDtl.ProfilePic);
            sqlParameter[8] = new SqlParameter("@FLAG", gDtl.Flag);
            sqlParameter[9] = new SqlParameter("@ERROR_MSG", SqlDbType.NVarChar);
            sqlParameter[9].Direction = ParameterDirection.Output;
            sqlParameter[9].Size = 2000;
            sqlParameter[10] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[10].Direction = ParameterDirection.Output;
            sqlParameter[10].Size = 1;
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_SAVE_USR_GENERAL_DTL", sqlParameter);
            ResponseEntity error = ResponseEntity.GetInstance();
            error.ERROR_MSG = sqlParameter[9].Value.ToString();
            error.ERROR_FLAG = sqlParameter[10].Value.ToString();
            return error;
        }
        public ResponseEntity SaveAccountingDetails(UserAccountingEntity acDtl)
        {
            SqlParameter[] sqlParameter = new SqlParameter[7];
            sqlParameter[0] = new SqlParameter("@USER_ID", acDtl.UserId);
            sqlParameter[1] = new SqlParameter("@PAN", acDtl.PAN);
            sqlParameter[2] = new SqlParameter("@TIN", acDtl.TIN);
            sqlParameter[3] = new SqlParameter("@GSTIN", acDtl.GSTIN);
            sqlParameter[4] = new SqlParameter("@FLAG", acDtl.Flag);
            sqlParameter[5] = new SqlParameter("@ERROR_MSG", SqlDbType.NVarChar);
            sqlParameter[5].Direction = ParameterDirection.Output;
            sqlParameter[5].Size = 2000;
            sqlParameter[6] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[6].Direction = ParameterDirection.Output;
            sqlParameter[6].Size = 1;
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_SAVE_USR_ACCOUNTING_DTL", sqlParameter);
            ResponseEntity error = ResponseEntity.GetInstance();
            error.ERROR_MSG = sqlParameter[5].Value.ToString();
            error.ERROR_FLAG = sqlParameter[6].Value.ToString();
            return error;
        }
        public ResponseEntity SaveBillingDetails(UserBillingEntity bDtl)
        {
            SqlParameter[] sqlParameter = new SqlParameter[18];
            sqlParameter[0] = new SqlParameter("@USER_ID", bDtl.UserId);
            sqlParameter[1] = new SqlParameter("@ADDRESS_LINE_1", bDtl.AddressLine1);
            sqlParameter[2] = new SqlParameter("@ADDRESS_LINE_2", bDtl.AddressLine2);
            sqlParameter[3] = new SqlParameter("@COUNTRY", bDtl.CountryId);
            sqlParameter[4] = new SqlParameter("@STATE", bDtl.StateId);
            sqlParameter[5] = new SqlParameter("@CITY", bDtl.CityId);
            sqlParameter[6] = new SqlParameter("@PHONE", bDtl.Phone);
            sqlParameter[7] = new SqlParameter("@PIN_CODE", bDtl.PinCode);
            sqlParameter[8] = new SqlParameter("@S_ADDRESS_LINE_1", bDtl.S_AddressLine1);
            sqlParameter[9] = new SqlParameter("@S_ADDRESS_LINE_2", bDtl.S_AddressLine2);
            sqlParameter[10] = new SqlParameter("@S_COUNTRY", bDtl.S_CountryId);
            sqlParameter[11] = new SqlParameter("@S_STATE", bDtl.StateId);
            sqlParameter[12] = new SqlParameter("@S_CITY", bDtl.S_CityId);
            sqlParameter[13] = new SqlParameter("@S_PHONE", bDtl.S_Phone);
            sqlParameter[14] = new SqlParameter("@S_PIN_CODE", bDtl.S_PinCode);
            sqlParameter[15] = new SqlParameter("@FLAG", bDtl.Flag);
            sqlParameter[16] = new SqlParameter("@ERROR_MSG", SqlDbType.NVarChar);
            sqlParameter[16].Direction = ParameterDirection.Output;
            sqlParameter[16].Size = 2000;
            sqlParameter[17] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[17].Direction = ParameterDirection.Output;
            sqlParameter[17].Size = 1;
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_SAVE_BILLING_DTLS", sqlParameter);
            ResponseEntity error = ResponseEntity.GetInstance();
            error.ERROR_MSG = sqlParameter[16].Value.ToString();
            error.ERROR_FLAG = sqlParameter[17].Value.ToString();
            return error;
        }

        public ResponseEntity SaveChannelDetails(FlipkartEntity flp, ApiGeneralEntity chDtl)
        {
            SqlParameter[] sqlParameter = new SqlParameter[14];
            sqlParameter[0] = new SqlParameter("@USER_ID", flp.UserId);
            sqlParameter[1] = new SqlParameter("@CHANNEL_ID", chDtl.ChannelId);
            sqlParameter[2] = new SqlParameter("@CHANNEL_NAME", chDtl.ChannelName);
            sqlParameter[3] = new SqlParameter("@LEADGER_NAME", chDtl.LeadgerName);
            sqlParameter[4] = new SqlParameter("@ORDER_SYNC", chDtl.OrderSync);
            sqlParameter[5] = new SqlParameter("@INVENTORY_SYNC", chDtl.InventorySync);
            sqlParameter[6] = new SqlParameter("@USERNAME", flp.Username);
            sqlParameter[7] = new SqlParameter("@PASSWORD", flp.Password);
            sqlParameter[8] = new SqlParameter("@API_DETAILS", chDtl.ApiDetails);
            sqlParameter[9] = new SqlParameter("@CH_PREFIX", chDtl.Ch_Prefix);
            sqlParameter[10] = new SqlParameter("@STATUS", flp.Status);
            sqlParameter[11] = new SqlParameter("@FLAG", flp.Flag);
            sqlParameter[12] = new SqlParameter("@ERROR_MSG", SqlDbType.NVarChar);
            sqlParameter[12].Direction = ParameterDirection.Output;
            sqlParameter[12].Size = 2000;
            sqlParameter[13] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[13].Direction = ParameterDirection.Output;
            sqlParameter[13].Size = 1;
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_SAVE_USER_CHANNEL", sqlParameter);
            ResponseEntity error = ResponseEntity.GetInstance();
            error.ERROR_MSG = sqlParameter[12].Value.ToString();
            error.ERROR_FLAG = sqlParameter[13].Value.ToString();
            return error;
        }
        public List<LocationEntity> GetLocation(string countryId, string stateId, string cityId)
        {
            SqlDataReader dr;
            SqlParameter[] sqlParameter = new SqlParameter[2];
            sqlParameter[0] = new SqlParameter("@COUNTRY_ID", Convert.ToInt32(countryId));
            sqlParameter[1] = new SqlParameter("@STATE_ID", Convert.ToInt32(stateId));
            dr = SqlHelper.ExecuteReader(sqlconn, CommandType.StoredProcedure, "SP_GET_LOCATION", sqlParameter);
            List<LocationEntity> locLst = new List<LocationEntity>();
            LocationEntity objLoc;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    objLoc = new LocationEntity();
                    if (countryId == "0")
                    {
                        objLoc.CountryId = dr["COUNTRY_ID"].ToString();
                        objLoc.CountryName = dr["COUNTRY_NAME"].ToString();
                    }
                    if (Convert.ToInt32(countryId) > 0 && stateId == "0")
                    {
                        objLoc.StateId = dr["STATE_ID"].ToString();
                        objLoc.StateName = dr["STATE_NAME"].ToString();
                    }
                    if (Convert.ToInt32(countryId) > 0 && Convert.ToInt32(stateId) > 0)
                    {
                        objLoc.CityId = dr["CITY_ID"].ToString();
                        objLoc.CityName = dr["CITY_NAME"].ToString();
                    }
                    locLst.Add(objLoc);
                }
            }
            return locLst;
        }

        public ResponseEntity RemoveImage(string userId)
        {
            ResponseEntity error = ResponseEntity.GetInstance();
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[1];
                string query = "UPDATE MST_SAVE_USR_GENERAL_DTL SET PROFILE_PIC = NULL  WHERE USER_ID=@userId";
                sqlParameter[0] = new SqlParameter("@userId", userId);
                SqlHelper.ExecuteScalar(sqlconn, CommandType.Text, query, sqlParameter);
                error.ERROR_MSG = "Image has been removed.";
                error.ERROR_FLAG = "S";
            }
            catch (Exception ex)
            {
                error.ERROR_MSG = "Image remove failed.";
                error.ERROR_FLAG = "F";
            }
            return error;
        }

        public Dictionary<string, object> GetUserDetails(string userId, string status)
        {
            SqlDataReader dr;

            SqlParameter[] sqlParameter = new SqlParameter[3];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            sqlParameter[1] = new SqlParameter("@STATUS", status);
            dr = SqlHelper.ExecuteReader(sqlconn,CommandType.StoredProcedure, "SP_GET_USER_DETAILS", sqlParameter);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Dictionary<string, object> surveyDict = new Dictionary<string, object>();
                    aDict = Enumerable.Range(0, dr.FieldCount).ToDictionary(dr.GetName, dr.GetValue);

                }
            }
            return aDict;
        }
        public int UpdatePassword(string userId, string password)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            sqlParameter[1] = new SqlParameter("@PASSWORD", password);
            string query = "UPDATE MST_USER_CREDENTIALS SET PASSWORD=@PASSWORD WHERE USER_ID=@USER_ID";
            int result = SqlHelper.ExecuteNonQuery(sqlconn, CommandType.Text, query, sqlParameter);
            return result;
        }
    }
}