using Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//admin view model - allows the access to a list of admin present in the database table
namespace Labs.ModelView
{
    public class AdminViewModel
    {
        public List<Admin> admins { get; set; }
    }
}