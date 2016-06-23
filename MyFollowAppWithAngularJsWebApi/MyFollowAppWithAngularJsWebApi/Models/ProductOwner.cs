using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFollowAppWithAngularJsWebApi.Models
{
    public class ProductOwner
    {
        [Key]
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
        public virtual Admin Admin { get; set; }
    }
}