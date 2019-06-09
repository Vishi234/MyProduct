using App.Models.BAL.Common;
using App.Models.BAL.Customer;
using App.Models.Entity.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class DevController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RefreshGridSettings()
        {
            GlobalCache gcObj = new GlobalCache();
            gcObj.CreateDynamicGridJS();
            ViewBag.msg = gcObj.CreateDynamicGridJS().msg;
            return View("Index");
        }
        public ActionResult New()
        {
            return PartialView(new CustomerEntity());
        }
        [HttpPost]
        public JsonResult SaveCustomer(CustomerEntity objCustomer)
        {
            Customer objCustModel = new Customer();
            objCustomer.reportId = 1;
            objCustomer.operType = "A";
            objCustomer.userId = "admin";
            return Json(objCustModel.SaveCustomer(objCustomer));
        }
    }
}