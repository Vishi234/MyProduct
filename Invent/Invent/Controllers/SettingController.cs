using Invent.Models.BAL.Common;
using Invent.Models.BAL.Configuration;
using Invent.Models.BAL.Setting;
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
        GeneralDetailsEntity objGenEnt = new GeneralDetailsEntity();
        UserAccountingEntity objAcEnt = new UserAccountingEntity();
        UserBillingEntity objBiEnt = new UserBillingEntity();
        ConfigurationManageModel objConfig = new ConfigurationManageModel();
        DataSet ds = new DataSet();
        // GET: Setting
        public ActionResult Account()
        {
            Initialize();
            return View(Tuple.Create(objGenEnt, objAcEnt, objBiEnt));
        }

        public ActionResult Category()
        {
            return View(new CategoryEntity());
        }
        public void Initialize()
        {
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            ds = objConfig.GetLocation("0", "0", "0");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                objBiEnt.Country.Add(new SelectListItem { Text = dr[1].ToString(), Value = dr[0].ToString() });
                objBiEnt.S_Country.Add(new SelectListItem { Text = dr[1].ToString(), Value = dr[0].ToString() });
            }
            ds = objConfig.GetUserDetails(objUserEntity.UserID, objUserEntity.Status);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        objGenEnt.CompanyName = dr["COMPANY_NAME"].ToString();
                        objGenEnt.DisplayName = dr["DISPLAY_NAME"].ToString();
                        objGenEnt.FirstName = dr["FIRST_NAME"].ToString();
                        objGenEnt.LastName = dr["LAST_NAME"].ToString();
                        objGenEnt.ProfilePic = dr["PROFILE_PIC"].ToString();
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        objAcEnt.GSTIN = dr["GSTIN"].ToString();
                        objAcEnt.PAN = dr["PAN"].ToString();
                        objAcEnt.TIN = dr["TIN"].ToString();
                    }
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        objBiEnt.AddressLine1 = dr["ADDRESS_LINE_1"].ToString();
                        objBiEnt.AddressLine2 = dr["ADDRESS_LINE_2"].ToString();
                        objBiEnt.CountryId = Convert.ToInt32(dr["COUNTRY"].ToString());
                        ds = objConfig.GetLocation(objBiEnt.CountryId.ToString(), "0", "0");
                        foreach (DataRow drow in ds.Tables[0].Rows)
                        {
                            objBiEnt.State.Add(new SelectListItem { Text = drow[1].ToString(), Value = drow[0].ToString() });
                            objBiEnt.S_State.Add(new SelectListItem { Text = drow[1].ToString(), Value = drow[0].ToString() });
                        }
                        objBiEnt.StateId = Convert.ToInt32(dr["STATE"].ToString());
                        ds = objConfig.GetLocation(objBiEnt.CountryId.ToString(), objBiEnt.StateId.ToString(), "0");
                        foreach (DataRow drow in ds.Tables[0].Rows)
                        {
                            objBiEnt.City.Add(new SelectListItem { Text = drow[1].ToString(), Value = drow[0].ToString() });
                            objBiEnt.S_City.Add(new SelectListItem { Text = drow[1].ToString(), Value = drow[0].ToString() });
                        }
                        objBiEnt.CityId = Convert.ToInt32(dr["CITY"].ToString());
                        objBiEnt.Phone = dr["PHONE"].ToString();
                        objBiEnt.PinCode = dr["PIN_CODE"].ToString();
                        objBiEnt.S_AddressLine1 = dr["S_ADDRESS_LINE_1"].ToString();
                        objBiEnt.S_AddressLine2 = dr["S_ADDRESS_LINE_2"].ToString();
                        objBiEnt.S_CityId = Convert.ToInt32(dr["S_CITY"].ToString());
                        objBiEnt.S_CountryId = Convert.ToInt32(dr["S_COUNTRY"].ToString());
                        objBiEnt.S_StateId = Convert.ToInt32(dr["S_STATE"].ToString());
                        objBiEnt.S_Phone = dr["S_PHONE"].ToString();
                        objBiEnt.S_PinCode = dr["S_PIN_CODE"].ToString();
                    }
                }
            }
        }
        [HttpGet]
        public JsonResult GetCategory()
        {
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            return Json(new CategoryModel().GetProductCategory(objUserEntity.UserID), JsonRequestBehavior.AllowGet);
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
    }
}