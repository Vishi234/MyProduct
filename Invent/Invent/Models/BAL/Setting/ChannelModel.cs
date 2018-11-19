using Invent.Models.Entity.Configuration;
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
    public class ChannelModel
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        public List<ChannelGeneralDetailsEntity> GetUserChannel(string UserId)
        {
            SqlDataReader dr;
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@USER_ID", UserId);
            string query = "SELECT * FROM MST_USER_CHANNEL WHERE USER_ID=@USER_ID";
            dr = SqlHelper.ExecuteReader(sqlconn, CommandType.Text, query, sqlParameter);
            List<ChannelGeneralDetailsEntity> lstCh = new List<ChannelGeneralDetailsEntity>();
            ChannelGeneralDetailsEntity objCh;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    objCh = new ChannelGeneralDetailsEntity();
                    objCh.ChannelId = dr["CHANNEL_ID"].ToString();
                    objCh.ChannelName = dr["CHANNEL_NAME"].ToString();
                    objCh.Ch_Prefix = dr["Prefix"].ToString();
                    objCh.ApiDetails = dr["API_DETAILS"].ToString();
                    objCh.OrderSync = ((dr["ORDER_SYNC"].ToString() == "1") ? true : false);
                    objCh.InventorySync = ((dr["INVENTORY_SYNC"].ToString() == "1") ? true : false);
                    objCh.ConnectingStatus = ((dr["CHANNEL_STATUS"].ToString() == "1") ? true : false);
                    lstCh.Add(objCh);
                }
            }
            return lstCh;
        }
    }
}