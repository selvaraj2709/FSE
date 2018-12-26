using System.Web.Mvc;

namespace TaskManagerService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";

            return View();
        }
    }
}
