using DAL;
using Invent.Models.Entity.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Invent.Models.BAL.Setting
{
    public class ItemMasterModel
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        public List<Dictionary<string, object>> SaveItemsMaster(string userId, string jsonData, string flag)
        {
            ResponseEntity error = ResponseEntity.GetInstance();
            DataSet ds = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[5];
            sqlParameter[0] = new SqlParameter("@USER_ID", userId);
            sqlParameter[1] = new SqlParameter("@JSON_DATA", jsonData);
            sqlParameter[2] = new SqlParameter("@FLAG", flag);
            sqlParameter[3] = new SqlParameter("@ERROR_FLAG", SqlDbType.Char);
            sqlParameter[3].Direction = ParameterDirection.Output;
            sqlParameter[3].Size = 1;
            sqlParameter[4] = new SqlParameter("@ERROR_MSG", SqlDbType.NVarChar);
            sqlParameter[4].Direction = ParameterDirection.Output;
            sqlParameter[4].Size = 100;
            ds=SqlHelper.ExecuteDataset(sqlconn, CommandType.StoredProcedure, "SP_PRODUCT_BULK_UPLOAD", sqlParameter);
            Dictionary<string, object> row = new Dictionary<string, object>();
            List<Dictionary<string, object>> tableRows = new List<Dictionary<string, object>>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                foreach (DataRow datr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, datr[col]);
                    }
                    row.Add("FLAG", sqlParameter[3].Value.ToString());
                    row.Add("MESSAGE", sqlParameter[4].Value.ToString());
                    tableRows.Add(row);
                }
            }
            else
            {
                row.Add("FLAG", sqlParameter[3].Value.ToString());
                row.Add("MESSAGE", sqlParameter[4].Value.ToString());
                tableRows.Add(row);
            }
            return tableRows;
        }
    }
}