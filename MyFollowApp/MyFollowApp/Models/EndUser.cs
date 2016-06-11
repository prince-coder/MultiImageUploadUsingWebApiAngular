using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFollowApp.Models
{
    public class EndUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual MyFollow MyFollow { get; set; }
    }
}