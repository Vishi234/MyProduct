using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Web;

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