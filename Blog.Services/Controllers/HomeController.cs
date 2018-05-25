using System.Web.Mvc;

namespace Blog.Services.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return Json(new { Details = "vsjakoe" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            return Json(new { Contacts = 3 }, JsonRequestBehavior.AllowGet);
        }
    }
}