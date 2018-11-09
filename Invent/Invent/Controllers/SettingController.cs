using Invent.Models.BAL.Setting;
using Invent.Models.Entity.Setting;
using Invent.Models.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invent.Controllers
{
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View(new CategoryEntity());
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

            catMdl.Flag = ((catMdl.Flag.ToString().Trim() == "") ? 'A' : catMdl.Flag);
            catMdl.Status = ((catMdl.Status.ToString() == "") ? false : catMdl.Status);
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            catMdl.UserId = objUserEntity.UserID;
            return Json(new CategoryModel().ManageCategory(catMdl));
        }
    }
}