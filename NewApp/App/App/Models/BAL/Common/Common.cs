using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
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