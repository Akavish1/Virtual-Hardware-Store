using Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//product view model - allows the access to a list of products present in the database table
namespace Labs.ModelView
{
    public class ProductViewModel
    {
        public List<Product> products { get; set; }
    }
}