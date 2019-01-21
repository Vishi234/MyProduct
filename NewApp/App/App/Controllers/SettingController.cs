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
            }
            return Json("Save");
        }
    }
}