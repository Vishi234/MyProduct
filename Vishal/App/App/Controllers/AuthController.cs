using App.Models.Entity;
using App.Models.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View(new LoginEntity());
        }
        [HttpPost]
        public ActionResult Login(LoginEntity objLgnEntity)
        {
            return View();
        }
    }
}