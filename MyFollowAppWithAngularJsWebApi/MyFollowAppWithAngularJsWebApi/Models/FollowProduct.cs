using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFollowAppWithAngularJsWebApi.Models
{
    public class FollowProduct
    {
        [Key]
        public int id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public virtual EndUser EndUser { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}