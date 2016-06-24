using MyFollowAppWithAngularJsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyFollowAppWithAngularJsWebApi.Controllers
{
    public class MyFollowApiController : ApiController
    {
        private MyFollowAppContext db = new MyFollowAppContext();
        public void Get(int id)
        {
            var checkStatus = (from data in db.ProductOwnerRequest where data.Id == id && data.Count == 0 select data);
            if(checkStatus.Count() > 0)
            {
                //RedirectToRoute("");
                var session = HttpContext.Current.Session;
                session["ProductOwnerRequestId"] = id;
                HttpContext.Current.Response.Redirect("http://localhost:60847/Myfollow/Create");
                //return response;
            }
            //return Request.CreateResponse(HttpStatusCode.NotFound);

        }
        public HttpResponseMessage Post(MyFollow myFollow)
        {
            if(ModelState.IsValid)
            {
                db.MyFollow.Add(myFollow);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, myFollow);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        public IEnumerable<MyFollow> Get()
        {
            return db.MyFollow.AsEnumerable();
        }

    }
}
