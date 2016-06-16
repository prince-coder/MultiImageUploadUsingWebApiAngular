using AngularWebApiDemo.Models;
using System;
using System.Collections.Generic;
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

    }
}
