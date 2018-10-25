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
        DataSet ds;
        GeneralDetails gDtl = new GeneralDetails();
        AccountingDetails acDtl = new AccountingDetails();
        Billing bDtl = new Billing();
        ConfigurationManage cm = new ConfigurationManage();
        ChannelGeneralDetails chDtl = new ChannelGeneralDetails();
        FlipkartApi fAPi = new FlipkartApi();
        Error error = new Error();
        public ActionResult Intro()
        {
            return View();
        }
        public ActionResult Step_1()
        {
            try
            {
                ds = new DataSet();
                ds = cm.GetLocation("0", "0", "0");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    bDtl.Country.Add(new SelectListItem { Text = dr[1].ToString(), Value = dr[0].ToString() });
                    bDtl.S_Country.Add(new SelectListItem { Text = dr[1].ToString(), Value = dr[0].ToString() });
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return View(Tuple.Create(gDtl, acDtl, bDtl));
        }
        public ActionResult Step_2()
        {
            try
            {

            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return View(Tuple.Create(chDtl, fAPi));
        }
        [HttpPost]
        public JsonResult GetStates(string countryId)
        {
            try
            {
                ds = new DataSet();
                ds = cm.GetLocation(countryId, "0", "0");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    bDtl.State.Add(new SelectListItem { Text = dr[1].ToString(), Value = dr[0].ToString() });
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(bDtl.State);
        }
        [HttpPost]
        public JsonResult GetCities(string countryId, string stateId)
        {
            try
            {
                ds = new DataSet();
                ds = cm.GetLocation(countryId, stateId, "0");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    bDtl.City.Add(new SelectListItem { Text = dr[1].ToString(), Value = dr[0].ToString() });
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(bDtl.City);
        }
        [HttpPost]
        public JsonResult SaveGeneralDetails([Bind(Prefix = "Item1")] GeneralDetails gDtl)
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
        public JsonResult SaveAccountingDetails([Bind(Prefix = "Item2")] AccountingDetails acDtl)
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
        public JsonResult SaveBillingDetails([Bind(Prefix = "Item3")] Billing bDtl)
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
        public JsonResult SaveChannelDetails([Bind(Prefix = "Item1")]ChannelGeneralDetails chDtl)
        {
            Session["ChannelGeneraDetail"] = chDtl;
            Error error = new Error();
            error.ERROR_FLAG = "S";
            error.ERROR_MSG = "Channel details has been saved.";
            return Json(error);
        }
        [HttpPost]
        public JsonResult SaveChannelApiDetails([Bind(Prefix = "Item2")]FlipkartApi flDtl)
        {
            string response = string.Empty;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Token token = new Token();
            TokenError tokenError = new TokenError();
            UserEntity objUserEntity = new UserEntity();
            try
            {
                response = Common.FlipkartToken(flDtl.ApplicationId, flDtl.ApplicationSecret);
                token = serializer.Deserialize<Token>(response);
                tokenError = serializer.Deserialize<TokenError>(response);
                if (token.access_token != null)
                {
                    Session["FlipkartToken"] = token;
                    objUserEntity = (UserEntity)Session["UserEntity"];
                    flDtl.Status = '1';
                    flDtl.Flag = 'A';
                    flDtl.UserId = objUserEntity.UserID;
                    ChannelGeneralDetails chDtl = (ChannelGeneralDetails)Session["ChannelGeneraDetail"];
                    chDtl.ApiDetails = response;
                    error = cm.SaveChannelDetails(flDtl, chDtl,token);
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
    }
}