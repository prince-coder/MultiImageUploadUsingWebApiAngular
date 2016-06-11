using MyFollowApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace MyFollowApp.Controllers
{
    public class EndUserController : Controller
    {
        private MyFollowContext db = new MyFollowContext();
        // GET: EndUser
        [RequireHttps]
        [Authorize(Roles ="End User")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var endUserData = db.EndUsers.Include(x => x.MyFollow);
            EndUser endUser = new EndUser();
            
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(EndUser endUser)
        {
            if (ModelState.IsValid)
            {
                endUser.UserId = Convert.ToInt32(TempData["UserId"]);
                db.EndUsers.Add(endUser);
                db.SaveChanges();
                return RedirectToAction("Index", "MyFollow");
                
            }
            return View(endUser);
        }
    }
}