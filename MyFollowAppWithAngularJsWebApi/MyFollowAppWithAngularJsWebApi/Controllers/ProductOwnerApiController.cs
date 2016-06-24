using MyFollowAppWithAngularJsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFollowAppWithAngularJsWebApi.Controllers
{
    public class ProductOwnerApiController : ApiController
    {
        private MyFollowAppContext db = new MyFollowAppContext();
        public HttpResponseMessage Post(ProductOwner productOwner)
        {
            if (ModelState.IsValid)
            {
                db.ProductOwners.Add(productOwner);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, productOwner);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}
