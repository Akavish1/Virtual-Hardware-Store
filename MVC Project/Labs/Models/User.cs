using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

////a user model - parent class for customer and admin - represented by a c# class
namespace Labs.Models
{
    public class User
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Input must be 3 to 15 characters")]
        public string username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Input must be 3 to 20 characters and contain atleast one digit")]
        public string password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Valid email is required")]
        public string email { get; set; }
    }
}