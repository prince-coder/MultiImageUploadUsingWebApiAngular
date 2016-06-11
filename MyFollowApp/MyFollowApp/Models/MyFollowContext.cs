using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MyFollowApp.Models
{
    public class MyFollowContext: DbContext

    {
        public MyFollowContext(): base("MyFollowContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<MyFollow> MyFollows { get; set; }
        public DbSet<ProductOwner> ProductOwners { get; set; }
        public DbSet<EndUser> EndUsers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    
}