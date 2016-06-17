using AngularWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularWebApiDemo.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeContext db = new EmployeeContext();

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return db.Employee.AsEnumerable();
        }

        public Employee Get(int id)
        {
            Employee Employee = db.Employee.Find(id);
            if(Employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return Employee;
        }
        public HttpResponseMessage Post(Employee Employee)
        {
            if(ModelState.IsValid)
            {
                db.Employee.Add(Employee);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Employee);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Employee.EmpId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        public HttpResponseMessage Put(Employee Employee)
        {
            int id = Employee.EmpId;
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if(id != Employee.EmpId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(Employee).State = System.Data.Entity.EntityState.Modified;
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

        public HttpResponseMessage Delete(int id)
        {
            Employee Employee = db.Employee.Find(id);
            if(Employee==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Employee.Remove(Employee);
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
    }
}
