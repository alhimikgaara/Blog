using System.Web.Mvc;

namespace Blog.Services.Controllers
{
    public class MyController : Controller
    {
        public ActionResult About()
        {
            return Json(new { Details = "vsjakoe2" }, JsonRequestBehavior.AllowGet);
        }
    }
}