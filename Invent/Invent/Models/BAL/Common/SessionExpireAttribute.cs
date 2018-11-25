using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Invent.Models.BAL.Common
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        bool redirect = false;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            // check  sessions here
            if (HttpContext.Current.Session["UserEntity"] == null && redirect == false)
            {
                filterContext.HttpContext.Response.Redirect("~/Auth/Login");
                redirect = true;
                return;
            }
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            redirect = false;
            base.OnActionExecuted(filterContext);
        }
    }
}