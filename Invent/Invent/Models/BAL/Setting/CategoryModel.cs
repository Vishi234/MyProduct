﻿using Invent.Models.Entity.Common;
using Invent.Models.Entity.Setting;
using Microsoft.ApplicationBlocks.Data;
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
        public ErrorEntity ManageCategory(CategoryEntity catMdl)
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
            DataSet ds = new DataSet();

            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_MANAGE_CATEGORY", sqlParameter);
            ErrorEntity error = new ErrorEntity();
            error.ERROR_MSG = sqlParameter[12].Value.ToString();
            error.ERROR_FLAG = sqlParameter[13].Value.ToString();
            List<CategoryEntity> lstCat = new List<CategoryEntity>();
            CategoryEntity catEntity;
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    catEntity = new CategoryEntity();
                    catEntity.CategoryId = ds.Tables[0].Rows[i]["CATEGORY_ID"].ToString();
                }
            }
            return error;
        }
    }
}