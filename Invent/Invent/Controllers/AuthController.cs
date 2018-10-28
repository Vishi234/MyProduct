using Invent.Models.BAL.Authorization;
using Invent.Models.BAL.Common;
using Invent.Models.Entity;
using Invent.Models.Entity.Common;
using Invent.Models.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invent.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        ErrorEntity error = new ErrorEntity();
        public ActionResult Login()
        {
            return View(new LoginEntity());
        }
        public ActionResult Register()
        {
            return View(new RegisterEntity());
        }
        [HttpPost]
        public JsonResult Register(RegisterEntity regModel)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                regModel.Flag = 'A';
                regModel.Password = CommonModel.Encrypt(regModel.Password);
                regModel.VerCode = guid.ToString();
                regModel = new AuthModel().UserAuthorization(regModel);
                error.ERROR_MSG = regModel.Msg;
                error.ERROR_FLAG = regModel.ErrorFlag;
                ViewBag.UserID = regModel.UserID;
                if (error.ERROR_FLAG == "S")
                {
                    if (CommonModel.SendEmail(regModel.FirstName, "Account Verfication", regModel.EmailAddress, guid) != "Sent")
                    {
                        error.ERROR_MSG = "Registration has been failed. Please contact help desk.";
                        error.ERROR_FLAG = "F";
                    }

                }

            }
            catch (Exception ex)
            {
                error.ERROR_MSG = "Something went wrong while registration. Please try after sometime.";
                error.ERROR_FLAG = "F";
                ExceptionHandling.WriteException(ex);
            }
            return Json(error);
        }

        [HttpPost]
        public JsonResult Login(LoginEntity logModel)
        {
            try
            {
                RegisterEntity regModel = new RegisterEntity();
                regModel.Flag = 'L';
                regModel.EmailAddress = logModel.EmailAddress;
                regModel.Password = CommonModel.Encrypt(logModel.Password);
                regModel = new AuthModel().UserAuthorization(regModel);

                error.ERROR_MSG = regModel.Msg;
                error.ERROR_FLAG = regModel.ErrorFlag;
                error.ADD_PARAM = regModel.UserID;
                if (error.ERROR_FLAG == "S")
                {
                    if (regModel.UserID.Split('~')[2] == "0")
                    {
                        error.ERROR_FLAG = "F";
                        error.ERROR_MSG = "Your account is not verified till now. Please verify it first.";
                    }
                }
            }
            catch (Exception ex)
            {
                error.ERROR_MSG = "Something went wrong while login. Please try after sometime.";
                error.ERROR_FLAG = "F";
                ExceptionHandling.WriteException(ex);
            }
            return Json(error);
        }
        public ActionResult Verification()
        {
            try
            {
                RegisterEntity regModel = new RegisterEntity();
                Guid activationCode = new Guid(RouteData.Values["id"].ToString());
                regModel.VerCode = activationCode.ToString();
                regModel.Flag = 'V';
                regModel = new AuthModel().UserAuthorization(regModel);
                error.ERROR_MSG = regModel.Msg;
                error.ERROR_FLAG = regModel.ErrorFlag;
                if (error.ERROR_FLAG == "S")
                {
                    return RedirectToAction("login");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return View(error);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}