using Invent.Models.BAL.Common;
using Invent.Models.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invent.Controllers
{
    
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View(UserEntity.GetInstance());
        }
        
    }
}