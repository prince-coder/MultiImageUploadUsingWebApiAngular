using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductFollowApp.Models
{
    public class EndUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual MyFollow MyFollow { get; set; }
        public virtual ICollection<FollowProduct> FollowProduct { get; set; }
    }
}