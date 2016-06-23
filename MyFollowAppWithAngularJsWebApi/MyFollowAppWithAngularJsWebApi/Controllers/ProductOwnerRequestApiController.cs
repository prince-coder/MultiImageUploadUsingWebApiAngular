using MyFollowAppWithAngularJsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Http;

namespace MyFollowAppWithAngularJsWebApi.Controllers
{
    public class ProductOwnerRequestApiController : ApiController
    {
        private MyFollowAppContext db = new MyFollowAppContext();
        public HttpResponseMessage Post(ProductOwnerRequest p)
        {
            if (ModelState.IsValid)
            {
                db.ProductOwnerRequest.Add(p);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, p);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = p.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }
        [HttpGet]
        public IEnumerable<ProductOwnerRequest> Get()
        {
            return db.ProductOwnerRequest.AsEnumerable();

        }
        public ProductOwnerRequest Get(int id)
        {
            ProductOwnerRequest p = db.ProductOwnerRequest.Find(id);
            if (p == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            SendMail(p.Email, p.Name, p.CompanyName);

            return p;
        }
        public HttpResponseMessage Delete(int id)
        {
            ProductOwnerRequest p = db.ProductOwnerRequest.Find(id);
            if(p == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.ProductOwnerRequest.Remove(p);
            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        private void SendMail(string mailTo,string name,string companyName)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(mailTo);
                mail.From = new MailAddress("info.myfollow@gmail.com");
                mail.Subject = "Registration Request Accepted";
                string URL = string.Format("http://localhost:60847/ProductOwner/Create?Name={1}&Email={0}&CompanyName={2}", mailTo, name, companyName);
                mail.Body = string.Format("Dear {0}, <br/><br/><br/> Your Request for Product Owner Registration has been Approved. <br/>" +
                 "please click on the below link to complete your registration:<br/>{1}", name, URL);
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("info.myfollow@gmail.com ", "myfollow@admin");
                smtp.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback =
                 delegate (object s, X509Certificate certificate,
                 X509Chain chain, SslPolicyErrors sslPolicyErrors)
                 { return true; };
                smtp.Send(mail);
            }
            catch(Exception e)
            {

            }
        }

    }
}
