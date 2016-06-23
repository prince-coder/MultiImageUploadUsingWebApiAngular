using MyFollowAppWithAngularJsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFollowAppWithAngularJsWebApi.Controllers
{
    public class AdminController : ApiController
    {
        private MyFollowAppContext db = new MyFollowAppContext();
        public HttpResponseMessage Post(Admin model)
        {
            if (ModelState.IsValid)
            {
                var checkUser = (from data in db.Admin where data.UserName == model.UserName && data.Password == model.Password select data).ToList();
                if (checkUser.Count() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            }
        public void Get()
        {

        }
        }
    }

