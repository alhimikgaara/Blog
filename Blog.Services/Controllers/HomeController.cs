using System.Web.Mvc;

namespace Blog.Services.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return Json(new { mdeeee = "vsjakoe" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            return Json(new { Contacts = 3 }, JsonRequestBehavior.AllowGet);
        }
    }
}