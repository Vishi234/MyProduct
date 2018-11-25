using Invent.Models.BAL.Common;
using Invent.Models.BAL.Configuration;
using Invent.Models.Entity.Common;
using Invent.Models.Entity.Configuration;
using Invent.Models.Entity.User;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Invent.Controllers
{
    
    public class ConfigurationController : Controller
    {
        // GET: Configuration
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        ConfigurationModel config = ConfigurationModel.GetInstance();
        public ActionResult Intro()
        {
            return View();
        }
        public ActionResult Step_1()
        {
            return View(Tuple.Create(UserGeneralEntity.GetInstance(), UserAccountingEntity.GetInstance(), UserBillingEntity.GetInstance()));
        }
        public ActionResult Step_2()
        {
            return View(Tuple.Create(ApiGeneralEntity.GetInstance(), FlipkartEntity.GetInstance(), AmazonEntity.GetInstance()));
        }
        public JsonResult SaveGeneralDetails([Bind(Prefix = "Item1")] UserGeneralEntity objGeneral)
        {
            try
            {
                UserEntity objUsrEntity = UserEntity.GetInstance();
                objUsrEntity = (UserEntity)Session["UserEntity"];
                objGeneral.Flag = "U";
                objGeneral.UserId = objUsrEntity.UserID;
                objGeneral.Status = objUsrEntity.Status;
                ViewBag.Count = "1";
            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(config.SaveGeneralDetails(objGeneral));
        }
        [HttpPost]
        public JsonResult SaveAccountingDetails([Bind(Prefix = "Item2")] UserAccountingEntity objAccount)
        {
            try
            {
                UserEntity objUsrEntity = UserEntity.GetInstance();
                objUsrEntity = (UserEntity)Session["UserEntity"];
                objAccount.Flag = "A";
                objAccount.UserId = objUsrEntity.UserID;
                ViewBag.Count = "2";

            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(config.SaveAccountingDetails(objAccount));
        }
        [HttpPost]
        public JsonResult SaveBillingDetails([Bind(Prefix = "Item3")] UserBillingEntity objBilling)
        {
            try
            {
                UserEntity objUsrEntity = UserEntity.GetInstance();
                objUsrEntity = (UserEntity)Session["UserEntity"];
                objBilling.Flag = "A";
                objBilling.UserId = objUsrEntity.UserID;
                ViewBag.Count = "3";

            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(config.SaveBillingDetails(objBilling));
        }
        [HttpPost]
        public JsonResult SaveChannelDetails([Bind(Prefix = "Item1")]ApiGeneralEntity objGeneral)
        {
            ResponseEntity error = ResponseEntity.GetInstance();
            Session["ChannelGeneraDetail"] = objGeneral;
            error.ERROR_FLAG = "S";
            error.ERROR_MSG = "Channel details has been saved.";
            return Json(error);
        }
        [HttpPost]
        public JsonResult SaveChannelApiDetails([Bind(Prefix = "Item2")]FlipkartEntity objFP)
        {
            string response = string.Empty;
            TokenEntity token = new TokenEntity();
            TokenErrorEntity tokenError = new TokenErrorEntity();
            UserEntity objUserEntity = UserEntity.GetInstance();
            ResponseEntity error = ResponseEntity.GetInstance();
            try
            {
                response = CommonModel.FlipkartToken(objFP.ApplicationId, objFP.ApplicationSecret);
                token = serializer.Deserialize<TokenEntity>(response);
                tokenError = serializer.Deserialize<TokenErrorEntity>(response);
                if (token.access_token != null)
                {
                    JObject jsonObject = JObject.Parse(response);
                    jsonObject["ApplicationId"] = objFP.ApplicationId;
                    jsonObject["ApplicationName"] = objFP.ApplicationName;
                    jsonObject["ApplicationSecret"] = objFP.ApplicationSecret;
                    jsonObject["ApplicationSecret"] = objFP.Username;
                    jsonObject["Password"] = objFP.Password;

                    ApiGeneralEntity chDtl = (ApiGeneralEntity)Session["ChannelGeneraDetail"];
                    Session["FlipkartToken"] = token;
                    objUserEntity = (UserEntity)Session["UserEntity"];
                    objFP.Status = '1';
                    objFP.Flag = ((objFP.Flag == '\0') ? 'A' : objFP.Flag);
                    chDtl.Ch_Prefix = "FP";
                    objFP.UserId = objUserEntity.UserID;
                    chDtl.ApiDetails = jsonObject.ToString();   
                    error = config.SaveChannelDetails(objFP, chDtl);
                }
                else
                {
                    error.ERROR_FLAG = "F";
                    error.ERROR_MSG = tokenError.error_description;
                }

            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(error);
        }
        [HttpPost]
        public JsonResult SaveChannelAmazonDetails([Bind(Prefix = "Item3")]AmazonEntity objAZ)
        {
            string response = serializer.Serialize(objAZ);
            UserEntity objUserEntity = UserEntity.GetInstance();
            FlipkartEntity fAPi = FlipkartEntity.GetInstance();
            ResponseEntity error = ResponseEntity.GetInstance();
            try
            {
                ApiGeneralEntity chDtl = (ApiGeneralEntity)Session["ChannelGeneraDetail"];
                objUserEntity = (UserEntity)Session["UserEntity"];
                fAPi.Status = '1';
                fAPi.Flag = ((objAZ.Flag == '\0') ? 'A' : objAZ.Flag);
                fAPi.Username = objAZ.Username;
                fAPi.Password = objAZ.Password;
                fAPi.UserId = objUserEntity.UserID;
                chDtl.Ch_Prefix = "AZ";
                chDtl.ApiDetails = response;
                error = config.SaveChannelDetails(fAPi, chDtl);
            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(error);
        }
    }
}