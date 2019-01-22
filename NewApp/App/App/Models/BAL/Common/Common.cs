using App.Models.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace App.Models.BAL
{
    public static class Common
    {
        #region Password Encyption
        public static string Encrypt(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(bytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        #endregion
        #region Sendmail
        public static string SendEmail(string FullName, string mailSubject, string toMail, Guid guid)
        {
            string status = string.Empty;
            try
            {
                string body = "Hello " + FullName + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + string.Format("{0}://{1}/auth/Verification/{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, guid) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                var mail = new MailMessage(ConfigurationManager.AppSettings["FromMail"], ConfigurationManager.AppSettings["ToMail"], mailSubject, body);
                mail.To.Add(toMail);
                mail.IsBodyHtml = true;
                var smtpClient = new SmtpClient("smtp.gmail.com", 587); //if your from email address is "from@hotmail.com" then host should be "smtp.hotmail.com"**
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("devil.terex@gmail.com", "Terex@2018");
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess | DeliveryNotificationOptions.OnFailure;
                mail.Priority = MailPriority.Normal;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                status = "Sent";
            }
            catch (Exception ex)
            {
                status = "Fail";
                EHCommon.WriteException(ex);
            }
            return status;
        }
        #endregion
        #region IP Address
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            string ipAddress = string.Empty;
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ip.ToString();
                }
            }
            return ipAddress;
        }
        #endregion
        public static string ReadJsonFile(string key, string path)
        {
            string file = HttpContext.Current.Server.MapPath("~/Configuration/" + path);
            var fileData = System.IO.File.ReadAllText(file);
            var json = JObject.Parse(fileData);
            var columns = json[key];
            return columns.ToString();
        }
        #region Excel to datatable and validation
        public static Response CsvToDt(JArray Columns, string csvData)
        {
            int skipHeader = 0;
            bool colMatch = true;
            bool blankFile = false;
            DataTable dt = new DataTable();
            Response error = Response.GetInstance();
            //Add Columns from json to datatable
            for (int i = 0; i < Columns.Count - 1; i++)
            {
                dt.Columns.Add(Columns[i]["field"].ToString());
            }
            //End
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    int i = 0;
                    if (skipHeader == 0)
                    {
                        i = 0;
                        foreach (string cell in row.Split(','))
                        {
                            i++;
                        }
                        if (i != dt.Columns.Count)
                        {
                            colMatch = false;
                        }
                    }
                    if (colMatch == true)
                    {
                        if (skipHeader != 0)
                        {
                            dt.Rows.Add();
                            i = 0;
                            foreach (string cell in row.Split(','))
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell;
                                i++;
                            }
                        }
                    }
                }
                skipHeader = 1;
            }
            if (dt.Rows.Count == 0)
            {
                blankFile = true;
            }
            if (colMatch == false)
            {
                error.ERROR_FLAG = "F";
                error.ERROR_MSG = "Please check no. of columns in file.";

            }
            else if (blankFile == true)
            {
                error.ERROR_FLAG = "F";
                error.ERROR_MSG = "File can not be blank.";
            }
            else
            {
                error.ERROR_FLAG = "S";
                error.ERROR_MSG = "Uploaded Successfully.";
                error.ADD_PARAM = Common.DATATABLETOJSON(dt);
            }
            return error;
        }
        #endregion
        #region Datatable Serializer
        public static string DATATABLETOJSON(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }
        #endregion
    }
    public static class EHCommon
    {
        public static void WriteException(Exception ex)
        {
            string ExceptionPath = Path.Combine(HttpRuntime.AppDomainAppPath, ConfigurationManager.AppSettings["ErrorFileFolder"].ToString());
            string filePath = ExceptionPath;
            string Exfile = ConfigurationManager.AppSettings["ErrorFileName"].ToString();

            if (Directory.Exists(filePath))
            {
                if (File.Exists(Path.Combine(ExceptionPath, Exfile)))
                    WriteIntoTxt(filePath + "\\" + Exfile, ex);
                else
                    WriteIntoTxt(filePath + "\\" + Exfile, ex);
            }
            else
            {
                Directory.CreateDirectory(filePath);
                WriteIntoTxt(filePath + "\\" + Exfile, ex);
            }
        }
        private static void WriteIntoTxt(string filePath, Exception ex)
        {
            using (StreamWriter sw = File.CreateText(filePath)) //new StreamWriter(filePath, true))
            {

                sw.WriteLine("===============================start==============================================");
                sw.WriteLine("Inner Exception's" + ex.InnerException);
                sw.WriteLine("Message" + ex.Message);
                sw.WriteLine("StackTrace" + ex.StackTrace);
                sw.WriteLine("TargetSite" + ex.TargetSite);
                sw.WriteLine("DateTime : \t" + DateTime.Now);
                sw.WriteLine("================================end============================================= \n");
            }
        }
    }
}