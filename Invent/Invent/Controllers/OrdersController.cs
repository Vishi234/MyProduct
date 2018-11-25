using System.Web.Mvc;
using Invent.Models.Entity.User;
using System.Web.Script.Serialization;
using Invent.Models.BAL.Order;
using Invent.Models.BAL.Common;


namespace Invent.Controllers
{
    
    public class OrdersController : Controller
    {
        // GET: Orders
        JavaScriptSerializer serializer;
        UserEntity objUserEntity;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetOrders(string orderType)
        {
            UserEntity objUserEntity = UserEntity.GetInstance();
            objUserEntity = (UserEntity)Session["UserEntity"];
            OrderModel objOrdMdl = new OrderModel();
            return Json(objOrdMdl.GetOrders(objUserEntity.UserID, "", "", ""));
        }
    }

}
