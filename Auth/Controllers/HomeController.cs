using System.Web.Mvc;
using Auth.Repositorio;

namespace Auth.Controllers
{
    public class HomeController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}