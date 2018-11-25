using DAL;
using Invent.Models.Entity.Common;
using Invent.Models.Entity.Configuration;
using Invent.Models.Entity.Setting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Invent.Models.BAL.Setting
{
    public class CategoryModel
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        public ResponseEntity ManageCategory(CategoryEntity catMdl)
        {
            SqlParameter[] sqlParameter = new SqlParameter[14];
            sqlParameter[0] = new SqlParameter("@USER_ID", catMdl.UserId);
            sqlParameter[1] = new SqlParameter("@CATEGORY_ID", catMdl.CategoryId);
            sqlParameter[2] = new SqlParameter("@CATEGORY_NAME", catMdl.Name);
            sqlParameter[3] = new SqlParameter("@CODE", catMdl.Code);
            sqlParameter[4] = new SqlParameter("@PRICE_RANGE", catMdl.PriceRange);
            sqlParameter[5] = new SqlParameter("@IGST", catMdl.IGST);
            sqlParameter[6] = new SqlParameter("@CGST", catMdl.CGST);
            sqlParameter[7] = new SqlParameter("@SGST", catMdl.SGST);
            sqlParameter[8] = new SqlParameter("@UTGST", catMdl.UTGST);
            sqlParameter[9] = new SqlParameter("@CESS", catMdl.CESS);
            sqlParameter[10] = new SqlParameter("@STATUS", catMdl.Status);
            sqlParameter[11] = new SqlParameter("@FLAG", catMdl.Flag);
            sqlParameter[12] = new SqlParameter("@ERROR_MSG", SqlDbType.NVarChar);
            sqlParameter[12].Direction = ParameterDirection.Output;
            sqlParameter[12].Size = 2000;
            sqlParameter[13] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[13].Direction = ParameterDirection.Output;
            sqlParameter[13].Size = 1;
            SqlHelper.ExecuteScalar(sqlconn, CommandType.StoredProcedure, "SP_MANAGE_CATEGORY", sqlParameter);
            ResponseEntity error = ResponseEntity.GetInstance();
            error.ERROR_MSG = sqlParameter[12].Value.ToString();
            error.ERROR_FLAG = sqlParameter[13].Value.ToString();
            return error;
        }
        public List<CategoryEntity> GetProductCategory(string UserId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@USER_ID", UserId);
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_GET_PRODUCT_CATEGORY", sqlParameter);
            List<CategoryEntity> lstCatEntity = new List<CategoryEntity>();
            CategoryEntity objCatEnty;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        objCatEnty = new CategoryEntity();
                        objCatEnty.CategoryId = ds.Tables[0].Rows[i]["CATEGORY_ID"].ToString();
                        objCatEnty.Name = ds.Tables[0].Rows[i]["CATEGORY_NAME"].ToString();
                        objCatEnty.Code = ds.Tables[0].Rows[i]["CODE"].ToString();
                        objCatEnty.PriceRange = ds.Tables[0].Rows[i]["PRICE_RANGE"].ToString();
                        objCatEnty.IGST = ds.Tables[0].Rows[i]["IGST"].ToString();
                        objCatEnty.CGST = ds.Tables[0].Rows[i]["CGST"].ToString();
                        objCatEnty.SGST = ds.Tables[0].Rows[i]["SGST"].ToString();
                        objCatEnty.UTGST = ds.Tables[0].Rows[i]["UTGST"].ToString();
                        objCatEnty.CESS = ds.Tables[0].Rows[i]["CESS"].ToString();
                        objCatEnty.Status = ((ds.Tables[0].Rows[i]["Status"].ToString() == "1") ? true : false);
                        lstCatEntity.Add(objCatEnty);
                    }

                }
            }
            return lstCatEntity;
        }
    }
}
