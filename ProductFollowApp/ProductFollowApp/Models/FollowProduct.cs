using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductFollowApp.Models
{
    public class FollowProduct
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public virtual EndUser EndUser { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}