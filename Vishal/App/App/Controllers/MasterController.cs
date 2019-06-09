using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Academic()
        {
            return PartialView();
        }
    }
}