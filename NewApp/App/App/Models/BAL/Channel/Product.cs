using App.Models.Entity;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App.Models.BAL.Channel
{
    public class Product
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        public List<Dictionary<string, object>> BulkUpload(string userId, string jsonData)
        {
            Response error = Response.GetInstance();
            DataSet ds = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[4];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            sqlParameter[1] = new SqlParameter("@JSON_DATA", jsonData);
            sqlParameter[2] = new SqlParameter("@FLAG", SqlDbType.Char);
            sqlParameter[2].Direction = ParameterDirection.Output;
            sqlParameter[2].Size = 1;
            sqlParameter[3] = new SqlParameter("@MSG", SqlDbType.NVarChar);
            sqlParameter[3].Direction = ParameterDirection.Output;
            sqlParameter[3].Size = 100;
            ds = SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_PRODUCT_BULK_UPLOAD", sqlParameter);
            Dictionary<string, object> row = new Dictionary<string, object>();
            List<Dictionary<string, object>> tableRows = new List<Dictionary<string, object>>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow datr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, datr[col]);
                        }
                        row.Add("FLAG", sqlParameter[2].Value.ToString());
                        row.Add("MESSAGE", sqlParameter[3].Value.ToString());
                        tableRows.Add(row);
                    }
                }
                else
                {
                    row.Add("FLAG", sqlParameter[2].Value.ToString());
                    row.Add("MESSAGE", sqlParameter[3].Value.ToString());
                    tableRows.Add(row);
                }
            }
            else
            {
                row.Add("FLAG", sqlParameter[2].Value.ToString());
                row.Add("MESSAGE", sqlParameter[3].Value.ToString());
                tableRows.Add(row);
            }
            return tableRows;
        }
    }
}