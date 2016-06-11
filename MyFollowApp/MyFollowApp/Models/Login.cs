using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFollowApp.Models
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}