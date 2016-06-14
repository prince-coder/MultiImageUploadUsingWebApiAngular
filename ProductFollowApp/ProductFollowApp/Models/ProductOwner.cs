using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductFollowApp.Models
{
    public class ProductOwner
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int FoundedIn { get; set; }
        public string WebsiteURL { get; set; }
        public string TwitterHandler { get; set; }
        public string FacebookPageURL { get; set; }
        public virtual MyFollow MyFollow { get; set; }
        public ICollection<ProductDetails> ProductDetails { get; set; }
        public virtual Login Login { get; set; }
    }
}