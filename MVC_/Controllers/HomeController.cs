using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace MVC_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            efdataEntities db = new efdataEntities();
            Repository resp = new Repository(db);
            Console.Write(resp.checkConnexion("test", "test"));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}