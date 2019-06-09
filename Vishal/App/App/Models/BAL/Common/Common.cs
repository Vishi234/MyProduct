﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace App.Models.BAL.Common
{
    public static class Common
    {
        #region Password Encyption
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        #endregion

        public static void WriteException(Exception e)
        {
            string logfileadd = ConfigurationManager.AppSettings["ExceptionLogFile"].ToString();
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logfileadd, true))
            {

                writer.WriteLine("Exception :" + e.ToString() + "\r\n");
                writer.WriteLine("Time :" + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + "\r\n");
                writer.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                writer.Close();
            }

        }
    }
}