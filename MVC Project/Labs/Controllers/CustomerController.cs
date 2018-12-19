using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labs.Models;
using Labs.DAL;

/// lab 4
//another controller that defines a class and sends it and is strongly tied to the view
namespace Labs.Controllers
{
    public class CustomerController : Controller
    {

        //returns the view for the customer's home page
        public ActionResult CustomerGate()
        {
            if (Session["Logged"] == null || Session["Logged"].ToString() != "Customer")
            {
                return View("~/Views/Home/NotLogged.cshtml");
            }
            return View();
        }

        //allows the registration of a new customer in the database - pre action
        public ActionResult Enter()
        {
            return View(new Customer());
        }


        [HttpPost]
        //after successful registration, adds the new customer the the database
        public ActionResult Submit(Customer cust)
        {
            if (ModelState.IsValid)
            {
                CustomerDAL dal = new CustomerDAL();
                try
                {
                    dal.Customers.Add(cust);
                    dal.SaveChanges();
                }
                catch (Exception)
                {
                    dal.Customers.Remove(cust);
                    Session["cDuplicateError"] = "Choose another customer number";
                    return View("Enter", cust);
                }
                return View("Customer", cust);
            }
            return View("Enter", cust);
        }


    }
}