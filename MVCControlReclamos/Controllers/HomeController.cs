using Common.Constantes;
using MVCControlReclamos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControlReclamos.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string username = (string)Session[CLogin.KEY_SESSION_USERNAME];
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