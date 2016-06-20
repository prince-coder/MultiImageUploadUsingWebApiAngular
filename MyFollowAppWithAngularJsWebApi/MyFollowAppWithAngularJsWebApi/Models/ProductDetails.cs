using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFollowAppWithAngularJsWebApi.Models
{
    public class ProductDetails
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductIntro { get; set; }
        public string Detail { get; set; }
        public string Media { get; set; }
        public int UserId { get; set; }
        public virtual ProductOwner ProductOwner { get; set; }
        public ICollection<FollowProduct> FollowProduct { get; set; }
    }
}