using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labs.DAL;
using Labs.Models;
using Labs.ModelView;



namespace Labs.Controllers
{
    public class AdminController : Controller
    {
        //returns the view for the admin's home page
        public ActionResult AdminGate()
        {
            if (Session["Logged"] == null || Session["Logged"].ToString() != "Admin")
            {
                return View("~/Views/Home/NotLogged.cshtml");
            }
            return View();
        }

        //allows the addition of new products - pre action
        public ActionResult Enter()
        {
            if (Session["Logged"] == null || Session["Logged"].ToString() != "Admin")
            {
                return View("~/Views/Home/NotLogged.cshtml");
            }
            return View(new Product());
        }

        //adds a new product to the database
        [HttpPost]
        public ActionResult Submit(Product prod)
        {
            if (ModelState.IsValid)
            {
                ProductDAL dal = new ProductDAL();
                try
                {
                    dal.Products.Add(prod);
                    dal.SaveChanges();
                }
                catch (Exception)
                {
                    dal.Products.Remove(prod);
                    Session["pDuplicateError"] = "Choose another product ID";
                    return View("Enter", prod);
                }
                return View("Product", prod);
            }
            return View("Enter", prod);
        }

        //search a customer by name - pre action
        public ActionResult SearchName()
        {
            if (Session["Logged"] == null || Session["Logged"].ToString() != "Admin")
            {
                return View("~/Views/Home/NotLogged.cshtml");
            }
            CustomerViewModel cvm = new CustomerViewModel();
            cvm.customers = new List<Customer>();
            return View("SearchCustomers", cvm);
        }

        //search a customer by name
        [HttpPost]
        public ActionResult SearchCustomers()
        {
            CustomerDAL dal = new CustomerDAL();
            Session["nameValue"] = Request.Form["txtfirstname"].ToString();
            string z = Session["nameValue"].ToString();
            List<Customer> objc = (from x in dal.Customers where x.firstname.Contains(z) select x).ToList<Customer>();
            CustomerViewModel cvm = new CustomerViewModel();
            cvm.customers = objc;
            return View(cvm);
        }

        //search a customer by id - pre action
        public ActionResult SearchID()
        {
            if (Session["Logged"] == null || Session["Logged"].ToString() != "Admin")
            {
                return View("~/Views/Home/NotLogged.cshtml");
            }
            CustomerViewModel cvm = new CustomerViewModel();
            cvm.customers = new List<Customer>();
            return View("SearchCustomerID", cvm);
        }

        //search a customer by id
        [HttpPost]
        public ActionResult SearchCustomerID()
        {
            CustomerDAL dal = new CustomerDAL();
            Session["idValue"] = Request.Form["txtcustomernumber"].ToString();
            string z = Session["idValue"].ToString();
            List<Customer> objc = (from x in dal.Customers where x.customernumber.Contains(z) select x).ToList<Customer>();
            CustomerViewModel cvm = new CustomerViewModel();
            cvm.customers = objc;
            return View(cvm);
        }

        //displays a list of all customers present in the database
        public ActionResult CustomerList()
        {
            if (Session["Logged"] == null || Session["Logged"].ToString() != "Admin")
            {
                return View("~/Views/Home/NotLogged.cshtml");
            }
            CustomerDAL dal = new CustomerDAL();
            List<Customer> objs = dal.Customers.ToList<Customer>();
            CustomerViewModel cvm = new CustomerViewModel();
            cvm.customers = objs;
            return View(cvm);
        }
    }

    
}