using DAL;
using Invent.Models.Entity.Configuration;
using Invent.Models.Entity.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Invent.Models.BAL.Authorization
{
    public class AuthModel
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        DataTable dt = new DataTable();
        public RegisterEntity UserAuthorization(RegisterEntity regModel)
        {
            SqlParameter[] sqlParameter = new SqlParameter[11];
            sqlParameter[0] = new SqlParameter("@USER_ID", regModel.UserID);
            sqlParameter[1] = new SqlParameter("@COMAPNY_NAME", regModel.CompanyName);
            sqlParameter[2] = new SqlParameter("@FIRST_NAME", regModel.FirstName);
            sqlParameter[3] = new SqlParameter("@LAST_NAME", regModel.LastName);
            sqlParameter[4] = new SqlParameter("@EMAIL_ID", regModel.EmailAddress);
            sqlParameter[5] = new SqlParameter("@PASSWORD", regModel.Password);
            sqlParameter[6] = new SqlParameter("@VER_CODE", regModel.VerCode);
            sqlParameter[7] = new SqlParameter("@FLAG", regModel.Flag);
            sqlParameter[8] = new SqlParameter("@MSG", SqlDbType.NVarChar);
            sqlParameter[8].Direction = ParameterDirection.Output;
            sqlParameter[8].Size = 2000;
            sqlParameter[9] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[9].Direction = ParameterDirection.Output;
            sqlParameter[9].Size = 1;
            sqlParameter[10] = new SqlParameter("@PO_USER_ID", SqlDbType.NVarChar);
            sqlParameter[10].Direction = ParameterDirection.Output;
            sqlParameter[10].Size = 100;
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(sqlconn,CommandType.StoredProcedure, "SP_CHECK_LOGIN", sqlParameter);
            regModel.Msg = sqlParameter[8].Value.ToString();
            regModel.ErrorFlag = sqlParameter[9].Value.ToString();
            regModel.UserID = sqlParameter[10].Value.ToString();
            if (ds.Tables.Count > 0)
            {
                UserEntity objUserEntity = UserEntity.GetInstance();
                List<ApiGeneralEntity> lstDtl = new List<ApiGeneralEntity>();
                ApiGeneralEntity chDtl;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objUserEntity.UserID = ds.Tables[0].Rows[0]["USER_ID"].ToString();
                    objUserEntity.CompanyName = ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
                    objUserEntity.DisplayName = ds.Tables[0].Rows[0]["DISPLAY_NAME"].ToString();
                    objUserEntity.FirstName = ds.Tables[0].Rows[0]["FIRST_NAME"].ToString();
                    objUserEntity.LastName = ds.Tables[0].Rows[0]["LAST_NAME"].ToString();
                    objUserEntity.EmailId = ds.Tables[0].Rows[0]["EMAIL_ID"].ToString();
                    objUserEntity.ProfilePic= ds.Tables[0].Rows[0]["PROFILE_PIC"].ToString();
                    objUserEntity.Pan = ds.Tables[0].Rows[0]["PAN"].ToString();
                    objUserEntity.Tin = ds.Tables[0].Rows[0]["TIN"].ToString();
                    objUserEntity.GSTIN = ds.Tables[0].Rows[0]["GSTIN"].ToString();
                    objUserEntity.B_AddressLine1 = ds.Tables[0].Rows[0]["Address_line_1"].ToString();
                    objUserEntity.B_AddressLine2 = ds.Tables[0].Rows[0]["Address_line_2"].ToString();
                    objUserEntity.B_Country = ds.Tables[0].Rows[0]["Country"].ToString();
                    objUserEntity.B_State = ds.Tables[0].Rows[0]["State"].ToString();
                    objUserEntity.B_City = ds.Tables[0].Rows[0]["City"].ToString();
                    objUserEntity.B_Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                    objUserEntity.B_PinCode = ds.Tables[0].Rows[0]["Pin_Code"].ToString();
                    objUserEntity.S_AddressLine1 = ds.Tables[0].Rows[0]["S_Address_Line_1"].ToString();
                    objUserEntity.S_AddressLine2 = ds.Tables[0].Rows[0]["S_Address_Line_2"].ToString();
                    objUserEntity.S_Country = ds.Tables[0].Rows[0]["S_Country"].ToString();
                    objUserEntity.S_State = ds.Tables[0].Rows[0]["S_State"].ToString();
                    objUserEntity.S_City = ds.Tables[0].Rows[0]["S_City"].ToString();
                    objUserEntity.S_Phone = ds.Tables[0].Rows[0]["S_Phone"].ToString();
                    objUserEntity.S_PinCode = ds.Tables[0].Rows[0]["S_Pin_Code"].ToString();
                    objUserEntity.Status = ds.Tables[0].Rows[0]["STATUS"].ToString();
                    objUserEntity.Verified = ds.Tables[0].Rows[0]["VERIFIED"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        chDtl = ApiGeneralEntity.GetInstance();
                        chDtl.ChannelName = dr["CHANNEL_NAME"].ToString();
                        chDtl.InventorySync = ((Convert.ToChar(dr["INVENTORY_SYNC"]) == '0') ? false : true);
                        chDtl.OrderSync = ((Convert.ToChar(dr["ORDER_SYNC"]) == '0') ? false : true);
                        chDtl.LeadgerName = dr["LEADGER_NAME"].ToString();
                        chDtl.Ch_Prefix = dr["PREFIX"].ToString();
                        chDtl.ApiDetails = dr["API_DETAILS"].ToString();
                        lstDtl.Add(chDtl);
                    }
                    objUserEntity.ChannelDetails = lstDtl;

                }
                HttpContext.Current.Session["UserEntity"] = objUserEntity;
            }
            return regModel;
        }
    }
}