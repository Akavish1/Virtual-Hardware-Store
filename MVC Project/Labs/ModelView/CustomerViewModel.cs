using Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//customer view model - allows the access to a list of customer present in the database table
namespace Labs.ModelView
{
    public class CustomerViewModel
    {
        public List<Customer> customers { get; set; }
    }
}