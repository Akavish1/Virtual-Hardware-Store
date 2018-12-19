using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


//a product model - represented by a c# class
namespace Labs.Models
{
    public class Product
    {
        [Key]
        [Required]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "Product ID must be 3 to 6 characters")]
        public string ProductID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Product name must be 4 to 50 characters")]
        public string ProductName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Price must be 1 to 10 characters")]
        public string Price { get; set; }
        [StringLength(1000, MinimumLength = 4, ErrorMessage = "Image path must be 4 to 1000 characters")]
        public string Image { get; set; }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public int Quantity { get; set; }
    }
}