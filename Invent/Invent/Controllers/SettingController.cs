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
            CategoryEntity catMdl = new CategoryEntity();
            catMdl.Flag = 'G';
            catMdl.UserId = objUserEntity.UserID;
            return Json(new CategoryModel().ManageCategory(catMdl));
        }
        [HttpPost]
        public JsonResult SaveCategory(CategoryEntity catMdl)
        {
            catMdl.Flag = 'A';
            catMdl.Status = '0';
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            catMdl.UserId = objUserEntity.UserID;
            return Json(new CategoryModel().ManageCategory(catMdl));
        }
    }
}