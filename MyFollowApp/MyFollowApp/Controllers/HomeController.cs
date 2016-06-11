using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyFollowApp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "End User")]
        public ActionResult Index()
        {
           
            ViewBag.Message = "Product owner Interface";

            return View();
        }
        [Authorize(Roles ="End User")]
        public ActionResult EndUserIndex()
        {
            ViewBag.Message = "End User Interface";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}