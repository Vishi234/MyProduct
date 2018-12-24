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
        public ActionResult Enabled()
        {
            return View();
        }
    }
}