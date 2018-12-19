using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


/// lab 4
//a customer model - represented by a c# class

namespace Labs.Models
{
    public class Customer : User
    {
        /// lab 7
        //states that those attributes must be given values and defines their error message
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Name must be 2 to 30 characters")]
        public string firstname { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be 2 to 50 characters")]
        public string lastname { get; set; }
        [Key]
        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Customer number must be 4 digits long whole number")]
        public string customernumber { get; set; }

    }
}