using Labs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


//a admin model - represented by a c# class
//pointlessly inherits from the user class, because otherwise microsoft's code first wont allow me to access the admin's table because it "has no key"
namespace Labs.Models
{
    public class Admin : User
    {
        [Key]
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Input must be 3 to 15 characters")]
        public string username { get; set; }
    }
}