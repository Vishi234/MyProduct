using Invent.Models.BAL.Configuration;
using Invent.Models.BAL.Setting;
using Invent.Models.Entity.Configuration;
using Invent.Models.Entity.Setting;
using Invent.Models.Entity.User;
using System;
using System.Collections.Generic;
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
            ds = objConfig.GetLocation("0", "0", "0");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                objBiEnt.Country.Add(new SelectListItem { Text = dr[1].ToString(), Value = dr[0].ToString() });
                objBiEnt.S_Country.Add(new SelectListItem { Text = dr[1].ToString(), Value = dr[0].ToString() });
            }
            return View(Tuple.Create(objGenEnt, objAcEnt, objBiEnt));
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

            catMdl.Flag = ((catMdl.Flag.ToString() != "E") ? 'A' : 'E');
            catMdl.Status = catMdl.Status;
            UserEntity objUserEntity = new UserEntity();
            objUserEntity = (UserEntity)Session["UserEntity"];
            catMdl.UserId = objUserEntity.UserID;
            return Json(new CategoryModel().ManageCategory(catMdl));
        }
    }
}