using MyFollowApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace MyFollowApp.Controllers
{
    public class ProductOwnerController : Controller
    {
        // GET: ProductOwner
        private MyFollowContext db = new MyFollowContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var endUserData = db.EndUsers.Include(x => x.MyFollow);
            //EndUser EndUser = new EndUser();

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ProductOwner productOwner)
        {
            if (ModelState.IsValid)
            {
                productOwner.UserId = Convert.ToInt32(TempData["UserId"]);
                db.ProductOwners.Add(productOwner);
                db.SaveChanges();
                TempData["UserId"] = "";
                return RedirectToAction("Index", "MyFollow");

            }
            return View(productOwner);
        }
    }
}