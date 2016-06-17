using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularWebApiDemo.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
    }
}