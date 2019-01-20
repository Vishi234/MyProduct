using App.Models.Entity;
using App.Models.Entity.AuthEntity;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App.Models.BAL.Authorization
{
    public class Authorization
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        public Response Registration(RegisterEntity register)
        {
            Response res = Response.GetInstance();
            SqlParameter[] sqlParameter = new SqlParameter[8];
            sqlParameter[0] = new SqlParameter("@COMPANY_NAME", register.company);
            sqlParameter[1] = new SqlParameter("@EMAIL_ADDRESS", register.email);
            sqlParameter[2] = new SqlParameter("@FULL_NAME", register.name);
            sqlParameter[3] = new SqlParameter("@MOBILE_NO", register.mobile);
            sqlParameter[4] = new SqlParameter("@PASSWORD", register.password);
            sqlParameter[5] = new SqlParameter("@VER_CODE", register.verification);
            sqlParameter[6] = new SqlParameter("@FLAG", SqlDbType.Char);
            sqlParameter[6].Direction = ParameterDirection.Output;
            sqlParameter[6].Size = 1;
            sqlParameter[7] = new SqlParameter("@MSG", SqlDbType.NVarChar);
            sqlParameter[7].Direction = ParameterDirection.Output;
            sqlParameter[7].Size = 2000;
            SqlHelper.ExecuteScalar(sqlconn, CommandType.StoredProcedure, "SP_COMPANY_REGISTERATION", sqlParameter);
            res.ERROR_FLAG = sqlParameter[6].Value.ToString();
            res.ERROR_MSG = sqlParameter[7].Value.ToString();
            return res;
        }
        public Response Verification(string code)
        {
            Response res = Response.GetInstance();
            SqlParameter[] sqlParameter = new SqlParameter[3];
            sqlParameter[0] = new SqlParameter("@VERIFICATION_CODE", code);
            sqlParameter[1] = new SqlParameter("@FLAG", SqlDbType.Char);
            sqlParameter[1].Direction = ParameterDirection.Output;
            sqlParameter[1].Size = 1;
            sqlParameter[2] = new SqlParameter("@MSG", SqlDbType.NVarChar);
            sqlParameter[2].Direction = ParameterDirection.Output;
            sqlParameter[2].Size = 2000;
            SqlHelper.ExecuteScalar(sqlconn, CommandType.StoredProcedure, "SP_MAIL_VERIFICATION", sqlParameter);
            res.ERROR_FLAG = sqlParameter[1].Value.ToString();
            res.ERROR_MSG = sqlParameter[2].Value.ToString();
            return res;
        }
        public Response Login(string email, string password, string ipAdd)
        {
            Response res = Response.GetInstance();
            UserEntity objUserEntity;
            DataSet ds = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[6];
            sqlParameter[0] = new SqlParameter("@EMAIL_ADDRESS", email);
            sqlParameter[1] = new SqlParameter("@PASSWORD", password);
            sqlParameter[2] = new SqlParameter("@IP_ADDRESS", ipAdd);
            sqlParameter[3] = new SqlParameter("@FLAG", SqlDbType.Char);
            sqlParameter[3].Direction = ParameterDirection.Output;
            sqlParameter[3].Size = 1;
            sqlParameter[4] = new SqlParameter("@MSG", SqlDbType.NVarChar);
            sqlParameter[4].Direction = ParameterDirection.Output;
            sqlParameter[4].Size = 2000;
            sqlParameter[5] = new SqlParameter("@USER_ID", SqlDbType.Int);
            sqlParameter[5].Direction = ParameterDirection.Output;
            sqlParameter[5].Size = 1000;
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_CHECK_LOGIN", sqlParameter);
            res.ERROR_FLAG = sqlParameter[3].Value.ToString();
            res.ERROR_MSG = sqlParameter[4].Value.ToString();
            res.ADD_PARAM = sqlParameter[5].Value.ToString();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objUserEntity = UserEntity.GetInstance();
                    objUserEntity.COMPANY_NAME = ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
                    objUserEntity.EMAIL_ADDRESS = ds.Tables[0].Rows[0]["EMAIL_ADDRESS"].ToString();
                    objUserEntity.FULL_NAME = ds.Tables[0].Rows[0]["FULL_NAME"].ToString();
                    objUserEntity.MOBILE_NO = ds.Tables[0].Rows[0]["MOBILE_NO"].ToString();
                    objUserEntity.ACCOUNT_LOCKED = ds.Tables[0].Rows[0]["ACCOUNT_LOCKED"].ToString();
                    objUserEntity.ACTIVE_USER = ds.Tables[0].Rows[0]["ACTIVE_USER"].ToString();
                    objUserEntity.IP_ADDRESS = ds.Tables[0].Rows[0]["IP_ADDRESS"].ToString();
                    objUserEntity.LAST_LOGIN = ds.Tables[0].Rows[0]["LAST_LOGIN_TIME"].ToString();
                    objUserEntity.USER_ID = ds.Tables[0].Rows[0]["USER_ID"].ToString();
                    objUserEntity.CONFIG_STATUS = ds.Tables[0].Rows[0]["CONFIG_STATUS"].ToString();
                    HttpContext.Current.Session["UserEntity"] = objUserEntity;
                }
            }
            return res;
        }
    }
}