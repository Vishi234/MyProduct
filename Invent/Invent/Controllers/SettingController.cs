using Invent.Models.BAL.Common;
using Invent.Models.BAL.Configuration;
using Invent.Models.BAL.Setting;
using Invent.Models.Entity.Common;
using Invent.Models.Entity.Configuration;
using Invent.Models.Entity.Setting;
using Invent.Models.Entity.User;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Invent.Controllers
{

    public class SettingController : Controller
    {
        DataSet ds = new DataSet();
        ConfigurationModel objConfig = ConfigurationModel.GetInstance();
        // GET: Setting
        public ActionResult Account()
        {
            //Initialize();
            RegisterEntity objRegEnt = new RegisterEntity();
            return View(Tuple.Create(UserGeneralEntity.GetInstance(), UserAccountingEntity.GetInstance(), UserBillingEntity.GetInstance(), objRegEnt));
        }
        public ActionResult Category()
        {
            return View(new CategoryEntity());
        }
        public ActionResult Channel()
        {
            return View(Tuple.Create(ApiGeneralEntity.GetInstance(), FlipkartEntity.GetInstance(), AmazonEntity.GetInstance()));
        }

        public ActionResult Add_Channel()
        {
            return View(Tuple.Create(ApiGeneralEntity.GetInstance(), FlipkartEntity.GetInstance(), AmazonEntity.GetInstance()));
        }

        public ActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ImportFile(string key)
        {
            HttpPostedFileBase postedFile = null;
            string filePath = string.Empty;
            int skipHeader = 0;
            bool colMatch = true;
            bool blankFile = false;
            ResponseEntity error = ResponseEntity.GetInstance();
            DataTable dt = new DataTable();
            if (Request.Files.Count > 0)
            {
                postedFile = Request.Files[0];
                string path = Server.MapPath(ConfigurationManager.AppSettings["UploadedTemplate"]);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                string csvData = System.IO.File.ReadAllText(filePath);
                JArray Columns = JArray.Parse(ReadConfiguration(key, "Setting/Import.json"));

                //Add Columns from json to datatable
                for (int i = 0; i < Columns.Count; i++)
                {
                    dt.Columns.Add(Columns[i]["headerName"].ToString());
                }
                //End

                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        int i = 0;
                        if (skipHeader == 0)
                        {
                            i = 0;
                            foreach (string cell in row.Split(','))
                            {
                                i++;
                            }
                            if (i != dt.Columns.Count)
                            {
                                colMatch = false;
                            }
                        }
                        if (colMatch == true)
                        {
                            if (skipHeader != 0)
                            {
                                dt.Rows.Add();
                                i = 0;
                                foreach (string cell in row.Split(','))
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell;
                                    i++;
                                }
                            }
                        }
                    }
                    skipHeader = 1;
                }
                if (dt.Rows.Count == 0)
                {
                    blankFile = true;
                }
                if (colMatch == false)
                {
                    error.ERROR_FLAG = "F";
                    error.ERROR_MSG = "Please check no. of columns in file.";

                }
                else if (blankFile == true)
                {
                    error.ERROR_FLAG = "F";
                    error.ERROR_MSG = "File can not be blank.";
                }
                else
                {
                    ItemMasterModel objItem = new ItemMasterModel();
                    UserEntity objUserEntity = UserEntity.GetInstance();

                    return Json(objItem.SaveItemsMaster(objUserEntity.UserID, CommonModel.DATATABLETOJSON(dt), "A"));
                }
               
            }
            return Json(error);
        }

        public string ReadConfiguration(string key, string path)
        {
            string file = Server.MapPath("~/GridConfiguration/" + path);
            var fileData = System.IO.File.ReadAllText(file);
            var json = JObject.Parse(fileData);
            var columns = json[key];
            return columns.ToString();
        }
        [HttpGet]
        public JsonResult Initialize()
        {
            UserEntity objUserEntity = UserEntity.GetInstance();
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
            UserEntity objUserEntity = UserEntity.GetInstance();
            objUserEntity = (UserEntity)Session["UserEntity"];
            return Json(new CategoryModel().GetProductCategory(objUserEntity.UserID), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetChannel()
        {
            UserEntity objUserEntity = UserEntity.GetInstance();
            objUserEntity = (UserEntity)Session["UserEntity"];
            return Json(new ChannelModel().GetUserChannel(objUserEntity.UserID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveCategory(CategoryEntity catMdl)
        {

            catMdl.Flag = ((catMdl.Flag.ToString() != "E") ? 'A' : 'E');
            catMdl.Status = catMdl.Status;
            UserEntity objUserEntity = UserEntity.GetInstance();
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
                UserEntity objUsrEntity = UserEntity.GetInstance();
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
        public JsonResult SaveGeneralDetail([Bind(Prefix = "Item1")] UserGeneralEntity genEntity)
        {
            try
            {
                HttpPostedFileBase file = null;
                UserEntity objUsrEntity = UserEntity.GetInstance();
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
            UserEntity objUserEntity = UserEntity.GetInstance();
            objUserEntity = (UserEntity)Session["UserEntity"];
            return Json(objConfig.RemoveImage(objUserEntity.UserID), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveAccountingDetails([Bind(Prefix = "Item2")] UserAccountingEntity acEntity)
        {
            try
            {
                UserEntity objUsrEntity = UserEntity.GetInstance();
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
                UserEntity objUsrEntity = UserEntity.GetInstance();
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
            UserEntity objUsrEntity = UserEntity.GetInstance();
            objUsrEntity = (UserEntity)Session["UserEntity"];
            ResponseEntity error = ResponseEntity.GetInstance();
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