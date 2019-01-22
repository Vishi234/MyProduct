using App.Models.BAL;
using App.Models.BAL.Channel;
using App.Models.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public JsonResult FileUpload(string reportType)
        {
            HttpPostedFileBase postedFile = null;
            string filePath = string.Empty;
            string data = string.Empty;
            App.Models.Entity.Response res = App.Models.Entity.Response.GetInstance();
            try
            {
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

                    data = System.IO.File.ReadAllText(filePath);
                    JArray Columns = JArray.Parse(Common.ReadJsonFile(reportType, "setting/import.json"));
                    res = Common.CsvToDt(Columns, data);
                    if (res.ERROR_FLAG == "S")
                    {
                        Product objPro = new Product();
                        UserEntity objUserEntity = UserEntity.GetInstance();
                        return Json(objPro.BulkUpload(objUserEntity.USER_ID, res.ADD_PARAM));
                    }
                }
            }
            catch (Exception ex)
            {
                res.ERROR_FLAG = "F";
                res.ERROR_MSG = "Something went wrong while uploading. Please try again later.";
                EHCommon.WriteException(ex);
            }
            return Json(res);
        }
    }
}