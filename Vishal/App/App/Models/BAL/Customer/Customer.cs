using App.Models.BAL.Common;
using App.Models.Entity.Common;
using App.Models.Entity.Customer;
using DaL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App.Models.BAL.Customer
{
    public class Customer
    {
        string sqlConn = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        public ResultEntity SaveCustomer(CustomerEntity objCustomer)
        {
            ResultEntity result = new ResultEntity();
            try
            {

                SqlParameter[] sqlParameter = new SqlParameter[17];
                sqlParameter[0] = new SqlParameter("@CUSTOMER_ID", objCustomer.customerId);
                sqlParameter[1] = new SqlParameter("@CUSTOMER_NAME", objCustomer.customerName);
                sqlParameter[2] = new SqlParameter("@EMAIL_ADDRESS", objCustomer.emailAddress);
                sqlParameter[3] = new SqlParameter("@PHONE_NO", objCustomer.phoneNo);
                sqlParameter[4] = new SqlParameter("@MOBILE_NO", objCustomer.mobileNo);
                sqlParameter[5] = new SqlParameter("@COUNTRY", objCustomer.countryId);
                sqlParameter[6] = new SqlParameter("@STATE", objCustomer.stateId);
                sqlParameter[7] = new SqlParameter("@CITY", objCustomer.cityId);
                sqlParameter[8] = new SqlParameter("@ADDRESS", objCustomer.address);
                sqlParameter[9] = new SqlParameter("@PINCODE", objCustomer.pincode);
                sqlParameter[10] = new SqlParameter("@WEBSITE", objCustomer.website);
                sqlParameter[11] = new SqlParameter("@FAX_NO", objCustomer.faxNo);
                sqlParameter[12] = new SqlParameter("@REPORT_ID", objCustomer.reportId);
                sqlParameter[13] = new SqlParameter("@USER_ID", objCustomer.userId);
                sqlParameter[14] = new SqlParameter("@OPER_TYPE", objCustomer.operType);
                sqlParameter[15] = new SqlParameter("@FLAG", SqlDbType.Char);
                sqlParameter[15].Direction = ParameterDirection.Output;
                sqlParameter[15].Size = 1;
                sqlParameter[16] = new SqlParameter("@MSG", SqlDbType.NVarChar);
                sqlParameter[16].Direction = ParameterDirection.Output;
                sqlParameter[16].Size = 500;

                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "SP_SAVE_CUSTOMER", sqlParameter);
                result.flag = sqlParameter[15].Value.ToString();
                result.msg = sqlParameter[16].Value.ToString();

                if (result.flag.ToUpper() == "S")
                {
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            result.addParams = CommonFunc.DtToJSON(ds.Tables[0]);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Common.Common.WriteException(ex);
                return result;
            }
        }
    }
}