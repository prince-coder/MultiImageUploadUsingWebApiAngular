using MyFollowApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFollowApp.Controllers
{
    public class MyFollowController : Controller
    {
       private  MyFollowContext db = new MyFollowContext();
        // GET: MyFollow
        public ActionResult Index()
        {

            return View(db.MyFollows.ToList());
        }
        public ActionResult Create()
        {
            return View(); 
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(MyFollow myFollow)
        {
            if(ModelState.IsValid)
            {
                db.MyFollows.Add(myFollow);
                db.SaveChanges();
                TempData["UserId"] = myFollow.UserId;
                if (myFollow.Role == "Product Owner")
                {
                    return RedirectToAction("Create", "ProductOwner");
                }
                else
                {
                    
                    return RedirectToAction("Create", "EndUser");
                }
            }
            return View(myFollow);
        }
    }
}