using Invent.Models.BAL.Common;
using Invent.Models.BAL.Configuration;
using Invent.Models.BAL.Setting;
using Invent.Models.Entity.Common;
using Invent.Models.Entity.Configuration;
using Invent.Models.Entity.Setting;
using Invent.Models.Entity.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invent.Controllers
{
    public class SettingController : Controller
    {
        DataSet ds = new DataSet();
        GeneralDetailsEntity objGenEnt = new GeneralDetailsEntity();
        UserAccountingEntity objAcEnt = new UserAccountingEntity();
        UserBillingEntity objBiEnt = new UserBillingEntity();
        RegisterEntity objRegEnt = new RegisterEntity();
        ConfigurationManageModel objConfig = new ConfigurationManageModel();
        // GET: Setting
        public ActionResult Account()
        {
            //Initialize();

            return View(Tuple.Create(objGenEnt, objAcEnt, objBiEnt, objRegEnt));
        }

        public ActionResult Category()
        {
            return View(new CategoryEntity());
        }
        public ActionResult Channel()
        {
            return View();
        }

        public ActionResult Add_Channel()
        {
            return View();
        }
        public ActionResult Channel_Detail()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Channel_Detail(string Ch, string Key)
        {
            return View();
        }
        [HttpGet]
        public JsonResult Initialize()
        {
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            Dictionary<string, object> aDict;
            aDict = objConfig.GetUserDetails(objUserEntity.UserID, objUserEntity.Status);
            return Json(aDict, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetLocation(string countryId, string stateId)
        {
            return Json(objConfig.GetLocation(countryId, stateId, "0"), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCategory()
        {
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            return Json(new CategoryModel().GetProductCategory(objUserEntity.UserID), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetChannel()
        {
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            return Json(new ChannelModel().GetUserChannel(objUserEntity.UserID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveCategory(CategoryEntity catMdl)
        {

            catMdl.Flag = ((catMdl.Flag.ToString() != "E") ? 'A' : 'E');
            catMdl.Status = catMdl.Status;
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            catMdl.UserId = objUserEntity.UserID;
            return Json(new CategoryModel().ManageCategory(catMdl));
        }

        [HttpPost]
        public ActionResult UploadLogo()
        {
            HttpPostedFileBase file = null;
            if (Request.Files.Count > 0)
            {
                UserEntity objUsrEntity = new UserEntity();
                objUsrEntity = (UserEntity)Session["UserEntity"];
                file = Request.Files[0];
                string imageName = CommonModel.SaveImages(file, objUsrEntity.CompanyName, objUsrEntity.UserID, ConfigurationManager.AppSettings["ProfilePicLocation"]);
                TempData["ProfilePic"] = imageName;
                return Json("File uploaded.");
            }
            else
            {
                return Json("No files selected.");
            }
        }
        [HttpPost]
        public JsonResult SaveGeneralDetail([Bind(Prefix = "Item1")] GeneralDetailsEntity genEntity)
        {
            try
            {
                HttpPostedFileBase file = null;
                UserEntity objUsrEntity = new UserEntity();
                objUsrEntity = (UserEntity)Session["UserEntity"];
                genEntity.Flag = "U";
                genEntity.UserId = objUsrEntity.UserID;
                genEntity.Status = objUsrEntity.Status;
                genEntity.ProfilePic = TempData["ProfilePic"].ToString();
            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }

            return Json(objConfig.SaveGeneralDetails(genEntity));
        }

        [HttpGet]
        public JsonResult RemoveImage()
        {
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            return Json(objConfig.RemoveImage(objUserEntity.UserID), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveAccountingDetails([Bind(Prefix = "Item2")] UserAccountingEntity acEntity)
        {
            try
            {
                UserEntity objUsrEntity = new UserEntity();
                objUsrEntity = (UserEntity)Session["UserEntity"];
                acEntity.Flag = "U";
                acEntity.UserId = objUsrEntity.UserID;
            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(objConfig.SaveAccountingDetails(acEntity));
        }
        [HttpPost]
        public JsonResult SaveBillingDetails([Bind(Prefix = "Item3")] UserBillingEntity bDtl)
        {
            try
            {
                UserEntity objUsrEntity = new UserEntity();
                objUsrEntity = (UserEntity)Session["UserEntity"];
                bDtl.Flag = "U";
                bDtl.UserId = objUsrEntity.UserID;
                ViewBag.Count = "3";

            }
            catch (Exception ex)
            {
                ExceptionHandling.WriteException(ex);
            }
            return Json(objConfig.SaveBillingDetails(bDtl));
        }

        [HttpPost]
        public JsonResult ChangePassword([Bind(Prefix = "Item4")] RegisterEntity regEnt)
        {
            UserEntity objUsrEntity = new UserEntity();
            objUsrEntity = (UserEntity)Session["UserEntity"];
            ErrorEntity error = new ErrorEntity();
            try
            {
                regEnt.Password = CommonModel.Encrypt(regEnt.Password);
                int result = objConfig.UpdatePassword(objUsrEntity.UserID, regEnt.Password);
                if (result == 1)
                {
                    error.ERROR_FLAG = "S";
                    error.ERROR_MSG = "Password updated successfully.";
                }
                else
                {
                    error.ERROR_FLAG = "F";
                    error.ERROR_MSG = "Password change failed.";
                }
            }
            catch (Exception ex)
            {
                error.ERROR_FLAG = "F";
                error.ERROR_MSG = "Password change failed.";
                ExceptionHandling.WriteException(ex);
            }
            return Json(error);
        }
    }
}