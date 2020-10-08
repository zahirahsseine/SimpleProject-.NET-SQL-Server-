using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        Repository rep;
        public HomeController()
        {
            rep = new Repository(new efdataEntities());
        }
        public ActionResult Index()
        {
            return View();
        }
       
        [Authorize]
        [HttpPost]
         public ActionResult AddUser(C_user user)
        {
            return  Json(new { message= rep.addUser(user) ? "Succesfull Opération!": "Failed Opération!" });
        }
        [HttpGet]
        public ActionResult SignOut(string pseudo, string password)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
            [HttpPost]
         public ActionResult SignIn(string pseudo, string password)
        {
            var session = HttpContext.Session;
            if ( rep.checkConnexion(pseudo, password))
            {
                session["pseudo"] = pseudo;
                return Json(new { url = "http://localhost:4956/Home/ManageUser" });
            }
                 
            else return Json(new { message="Your login or password are not correct!" }); ;
            
        }
        [Authorize]
        [HttpGet]
        public ActionResult ListUser()
        {
            return Json(new
            {
                list = rep.listUser()
            }, JsonRequestBehavior.AllowGet);
           
        }
        [Authorize]
        public ActionResult ManageUser()
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