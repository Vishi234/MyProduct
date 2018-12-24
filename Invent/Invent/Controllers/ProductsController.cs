using Invent.Models.BAL.Product;
using Invent.Models.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invent.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Manage()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetProduct(string status, string productId)
        {
            ProductModel objPro = new ProductModel();
            UserEntity objUserEntity = UserEntity.GetInstance();
            return Json(objPro.GetProducts(productId, objUserEntity.UserID, status), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Listing()
        {
            return View();
        }
    }
}