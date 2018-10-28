using Invent.Models.BAL.Common;
using Invent.Models.Entity.Common;
using Invent.Models.Entity.Configuration;
using Invent.Models.Entity.User;
using Microsoft.ApplicationBlocks.Data;
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
    public class ConfigurationManageModel
    {
        DataTable dt = new DataTable();
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        ErrorEntity error = new ErrorEntity();
        public ErrorEntity SaveGeneralDetails(GeneralDetailsEntity gDtl)
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
            error.ERROR_MSG = sqlParameter[9].Value.ToString();
            error.ERROR_FLAG = sqlParameter[10].Value.ToString();
            return error;
        }
        public ErrorEntity SaveAccountingDetails(UserAccountingEntity acDtl)
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
            error.ERROR_MSG = sqlParameter[5].Value.ToString();
            error.ERROR_FLAG = sqlParameter[6].Value.ToString();
            return error;
        }
        public ErrorEntity SaveBillingDetails(UserBillingEntity bDtl)
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
            error.ERROR_MSG = sqlParameter[16].Value.ToString();
            error.ERROR_FLAG = sqlParameter[17].Value.ToString();
            return error;
        }

        public ErrorEntity SaveChannelDetails(FlipkartEntity flp,ChannelGeneralDetailsEntity chDtl)
        {
            SqlParameter[] sqlParameter = new SqlParameter[13];
            sqlParameter[0] = new SqlParameter("@USER_ID", flp.UserId);
            sqlParameter[1] = new SqlParameter("@CHANNEL_NAME", chDtl.ChannelName);
            sqlParameter[2] = new SqlParameter("@LEADGER_NAME", chDtl.LeadgerName);
            sqlParameter[3] = new SqlParameter("@ORDER_SYNC", chDtl.OrderSync);
            sqlParameter[4] = new SqlParameter("@INVENTORY_SYNC", chDtl.InventorySync);
            sqlParameter[5] = new SqlParameter("@USERNAME", flp.Username);
            sqlParameter[6] = new SqlParameter("@PASSWORD", flp.Password);
            sqlParameter[7] = new SqlParameter("@API_DETAILS", chDtl.ApiDetails);
            sqlParameter[8] = new SqlParameter("@CH_PREFIX", chDtl.Ch_Prefix);
            sqlParameter[9] = new SqlParameter("@STATUS", flp.Status);
            sqlParameter[10] = new SqlParameter("@FLAG",flp.Flag);
            sqlParameter[11] = new SqlParameter("@ERROR_MSG", SqlDbType.NVarChar);
            sqlParameter[11].Direction = ParameterDirection.Output;
            sqlParameter[11].Size = 2000;
            sqlParameter[12] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[12].Direction = ParameterDirection.Output;
            sqlParameter[12].Size = 1;
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_SAVE_USER_CHANNEL", sqlParameter);
            error.ERROR_MSG = sqlParameter[11].Value.ToString();
            error.ERROR_FLAG = sqlParameter[12].Value.ToString();
            return error;
        }
        public DataSet GetLocation(string countryId, string stateId, string cityId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[2];
            sqlParameter[0] = new SqlParameter("@COUNTRY_ID", Convert.ToInt32(countryId));
            sqlParameter[1] = new SqlParameter("@STATE_ID", Convert.ToInt32(stateId));
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_GET_LOCATION", sqlParameter);
            return ds;
        }
    }
}