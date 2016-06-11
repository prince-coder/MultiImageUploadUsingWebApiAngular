using MyFollowApp.CustomAuthorization;
using MyFollowApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyFollowApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
       private MyFollowContext db = new MyFollowContext();
        public ActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost,ActionName("Login")]
         public ActionResult LoginData([Bind(Include ="EmailId,Password")]   Login model)
        {
            if (ModelState.IsValid)
            {
                var checkUser = (from data in db.MyFollows where data.Password == model.Password && data.EmailId == model.EmailId select data);

                if (checkUser.Count() > 0)
                {
                    FormsAuthentication.SetAuthCookie(model.EmailId, false);
                    var role = from d in db.MyFollows where d.Password == model.Password && d.EmailId == model.EmailId select new { d.Role };
                    string userRole = role.First().ToString();

                    if (userRole.Contains("ProductOwner"))
                    {
                        return RedirectToAction("Index", "ProductOwner");
                    }
                    else if(userRole.Contains("End User"))
                    {
                        return RedirectToAction("Login", "Account");
                    }
                   else
                    {
                        return RedirectToAction("AccessDenied", "Error");
                    }
                }
                else
                {
                    ModelState.AddModelError("","Invalid UserName or Password");
                }
                
            }
            return View();
        }
    }
}