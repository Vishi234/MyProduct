using App.Models.BAL;
using App.Models.BAL.Authorization;
using App.Models.Entity;
using App.Models.Entity.AuthEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(RegisterEntity register)
        {
            Response res = App.Models.Entity.Response.GetInstance();
            try
            {
                Guid guid = Guid.NewGuid();
                Authorization auth = new Authorization();
                register.verification = guid.ToString();
                register.password = Common.Encrypt(register.password);
                res = auth.Registration(register);
                if (res.ERROR_FLAG == "S")
                {
                    if (Common.SendEmail(register.name, "Account Verfication", register.email, guid) != "Sent")
                    {
                        res.ERROR_MSG = "Registration has been failed. Please contact help desk.";
                        res.ERROR_FLAG = "F";
                    }
                }
            }
            catch (Exception ex)
            {
                res.ERROR_MSG = "Something went wrong while registration. Please try after sometime.";
                res.ERROR_FLAG = "F";
                EHCommon.WriteException(ex);
            }

            return Json(res);
        }
        public ActionResult Verification()
        {
            App.Models.Entity.Response res = App.Models.Entity.Response.GetInstance();
            try
            {
                Guid activationCode = new Guid(RouteData.Values["id"].ToString());
                Authorization auth = new Authorization();
                string code = activationCode.ToString();
                res = auth.Verification(code);
                if (res.ERROR_FLAG == "S")
                {
                    return RedirectToAction("login");
                }
            }
            catch (Exception ex)
            {
                EHCommon.WriteException(ex);
            }
            return View(res);
        }
        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            App.Models.Entity.Response res = App.Models.Entity.Response.GetInstance();
            try
            {
                Authorization auth = new Authorization();
                res = auth.Login(email, Common.Encrypt(password), Common.GetLocalIPAddress());
            }
            catch (Exception ex)
            {
                res.ERROR_MSG = "Something went wrong while login. Please try after sometime.";
                res.ERROR_FLAG = "F";
                EHCommon.WriteException(ex);
            }
            return Json(res);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}