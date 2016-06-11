using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFollowApp.Models
{
    public class  MyFollow
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email Address")]
        public string EmailId { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
        public string Password { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Pin { get; set; }
        public string ContactNo { get; set; }
        [Required(ErrorMessage ="Please Enter Role")]
        public string Role { get; set; }

    }
}