using Invent.Models.BAL.Common;
using Invent.Models.BAL.Configuration;
using Invent.Models.Entity.Common;
using Invent.Models.Entity.Configuration;
using Invent.Models.Entity.User;
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
        GeneralDetailsEntity gDtl = new GeneralDetailsEntity();
        UserAccountingEntity acDtl = new UserAccountingEntity();
        UserBillingEntity bDtl = new UserBillingEntity();
        ConfigurationManageModel cm = new ConfigurationManageModel();
        ChannelGeneralDetailsEntity chDtl = new ChannelGeneralDetailsEntity();
        FlipkartEntity fAPi = new FlipkartEntity();
        AmazonEntity aApi = new AmazonEntity();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        ErrorEntity error = new ErrorEntity();
        public ActionResult Intro()
        {
            return View();
        }
        public ActionResult Step_1()
        {
            return View(Tuple.Create(gDtl, acDtl, bDtl));
        }
        public ActionResult Step_2()
        {
            return View(Tuple.Create(chDtl, fAPi, aApi));
        }
        public JsonResult SaveGeneralDetails([Bind(Prefix = "Item1")] GeneralDetailsEntity gDtl)
        {
            try
            {
                UserEntity objUsrEntity = new UserEntity();
                objUsrEntity = (UserEntity)Session["UserEntity"];
                gDtl.Flag = "U";
                gDtl.UserId = objUsrEntity.UserID;
                gDtl.Status = objUsrEntity.Status;
                ViewBag.Count = "1";
            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(cm.SaveGeneralDetails(gDtl));
        }
        [HttpPost]
        public JsonResult SaveAccountingDetails([Bind(Prefix = "Item2")] UserAccountingEntity acDtl)
        {
            try
            {
                UserEntity objUsrEntity = new UserEntity();
                objUsrEntity = (UserEntity)Session["UserEntity"];
                acDtl.Flag = "A";
                acDtl.UserId = objUsrEntity.UserID;
                ViewBag.Count = "2";

            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(cm.SaveAccountingDetails(acDtl));
        }
        [HttpPost]
        public JsonResult SaveBillingDetails([Bind(Prefix = "Item3")] UserBillingEntity bDtl)
        {
            try
            {
                UserEntity objUsrEntity = new UserEntity();
                objUsrEntity = (UserEntity)Session["UserEntity"];
                bDtl.Flag = "A";
                bDtl.UserId = objUsrEntity.UserID;
                ViewBag.Count = "3";

            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(cm.SaveBillingDetails(bDtl));
        }
        [HttpPost]
        public JsonResult SaveChannelDetails([Bind(Prefix = "Item1")]ChannelGeneralDetailsEntity chDtl)
        {
            Session["ChannelGeneraDetail"] = chDtl;
            ErrorEntity error = new ErrorEntity();
            error.ERROR_FLAG = "S";
            error.ERROR_MSG = "Channel details has been saved.";
            return Json(error);
        }
        [HttpPost]
        public JsonResult SaveChannelApiDetails([Bind(Prefix = "Item2")]FlipkartEntity flDtl)
        {
            string response = string.Empty;
            TokenEntity token = new TokenEntity();
            TokenErrorEntity tokenError = new TokenErrorEntity();
            UserEntity objUserEntity = new UserEntity();
            try
            {
                response = CommonModel.FlipkartToken(flDtl.ApplicationId, flDtl.ApplicationSecret);
                token = serializer.Deserialize<TokenEntity>(response);
                tokenError = serializer.Deserialize<TokenErrorEntity>(response);
                if (token.access_token != null)
                {
                    ChannelGeneralDetailsEntity chDtl = (ChannelGeneralDetailsEntity)Session["ChannelGeneraDetail"];
                    Session["FlipkartToken"] = token;
                    objUserEntity = (UserEntity)Session["UserEntity"];
                    flDtl.Status = '1';
                    flDtl.Flag = 'A';
                    chDtl.Ch_Prefix = "FP";
                    flDtl.UserId = objUserEntity.UserID;
                    chDtl.ApiDetails = response;
                    error = cm.SaveChannelDetails(flDtl, chDtl);
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
        public JsonResult SaveChannelAmazonDetails([Bind(Prefix = "Item3")]AmazonEntity amApi)
        {
            string response = serializer.Serialize(amApi);
            UserEntity objUserEntity = new UserEntity();
            try
            {
                ChannelGeneralDetailsEntity chDtl = (ChannelGeneralDetailsEntity)Session["ChannelGeneraDetail"];
                objUserEntity = (UserEntity)Session["UserEntity"];
                fAPi.Status = '1';
                fAPi.Flag = 'A';
                fAPi.Username = amApi.Username;
                fAPi.Password = amApi.Password;
                fAPi.UserId = objUserEntity.UserID;
                chDtl.Ch_Prefix = "AZ";
                chDtl.ApiDetails = response;
                error = cm.SaveChannelDetails(fAPi, chDtl);
            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(error);
        }
    }
}