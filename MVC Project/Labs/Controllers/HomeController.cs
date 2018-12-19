using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using Labs.Models;
using Labs.ModelView;
using Labs.DAL;


namespace Labs.Controllers
{
    public class HomeController : Controller
    {
        //the regular infamous index
        public ActionResult Index()
        {
            ///LAB 3
            //ViewBag.CurrentTime1 = DateTime.Now.ToString();
            //allows for moving of objects and data between actions (and later to a view)
            //TempData["CurrentTime"] = DateTime.Now.ToString();
            return RedirectToAction("ShowHomePage", "Home");
            //return View();
        }

        //the regular infamous about
        public ActionResult About()
        {
            return View();
        }

        //the regular infamous (please dont) contact me
        public ActionResult Contact()
        {
            return View();
        }

        //the regular home page actionresult
        public ActionResult ShowHomePage()
        {
            Session["CurrentTime"] = DateTime.Now.ToString();
            return View();
        }

        //allows returning the list of products from the database to the server in json format
        public ActionResult ProductsByJson()
        {
            ProductDAL dal = new ProductDAL();
            List<Product> objp = dal.Products.ToList<Product>();
            return Json(objp, JsonRequestBehavior.AllowGet);
        }

        //displays a beutiful catalog of 2018's best hardware
        public ActionResult ProductCatalog()
        {
            ProductDAL dal = new ProductDAL();
            List<Product> objp = dal.Products.ToList<Product>();
            ProductViewModel pvm = new ProductViewModel();
            pvm.products = objp;
            return View(pvm);
        }

        //search a product by name - pre action
        public ActionResult SearchpName()
        {
            ProductViewModel pvm = new ProductViewModel();
            pvm.products = new List<Product>();
            return View("SearchProducts", pvm);
        }

        //search a product by name
        public ActionResult SearchProducts()
        {
            ProductDAL dal = new ProductDAL();
            Session["pnameValue"] = Request.Form["txtname"].ToString();
            string z = Session["pnameValue"].ToString();
            List<Product> objp = (from x in dal.Products where x.ProductName.Contains(z) select x).ToList<Product>();
            ProductViewModel pvm = new ProductViewModel();
            pvm.products = objp;
            return View("ProductCatalog", pvm);
        }

        //checks if the user isnt logged in, and allows him to log in if so
        public ActionResult Signin()
        {
            if (Session["Logged"] == null)
            {
                Session["Error"] = "Hello";
                return View("Login");
            }
            return View("AlreadyLogged");
        }

        //although abit spaghetti, manages the website's login functionallity
        public ActionResult Login()
        {
            CustomerViewModel cvm = new CustomerViewModel();
            AdminViewModel avm = new AdminViewModel();
            cvm.customers = new List<Customer>();
            avm.admins = new List<Admin>();
            CustomerDAL cdal = new CustomerDAL();
            AdminDAL adal = new AdminDAL();
            Session["nameValue"] = Request.Form["txtusername"].ToString();
            Session["passValue"] = Request.Form["txtpassword"].ToString();
            string u = Session["nameValue"].ToString();
            string p = Session["passValue"].ToString();
            List<Customer> objc = (from x in cdal.Customers where x.username.Contains(u) select x).ToList<Customer>();
            List<Admin> obja = (from x in adal.Admins where x.username.Contains(u) select x).ToList<Admin>();
            foreach(Customer obj in objc)
            {
                if (obj.password.Equals(p))
                {
                    Customer c = new Customer();
                    c = obj;
                    Session["Logged"] = "Customer";
                    Session["LoggedName"] = obj.username;
                    return RedirectToAction("CustomerGate", "Customer");
                }
            }
            foreach (Admin obj in obja)
            {
                if (obj.password.Equals(p))
                {
                    Admin a = new Admin();
                    a = obj;
                    Session["Logged"] = "Admin";
                    Session["LoggedName"] = obj.username;
                    return RedirectToAction("AdminGate", "Admin");
                }
            }
            Session["Error"] = "Invalid Credentials";
            return View();
        }

        //does the opposite of the previous comment
        public ActionResult Logout()
        {
            if(Session["Logged"] == null)
            {
                return View("NotLogged");
            }
            Session["Logged"] = null;
            Session["LoggedName"] = null;
            return View();
        }

        //allows a customer to purchase 2018's best hardware for non inflated prices
        [HttpPost]
        public ActionResult Purchase(string item)
        {
            if (Session["Logged"] == null)
            {
                return View("NotLogged");
            }
            ProductDAL dal = new ProductDAL();
            bool flag = false;
            foreach (Product obj in dal.Products)
            {
                if (obj.ProductID.Equals(item) && obj.Quantity > 0)
                {
                    obj.Quantity--;
                    Session["Purchased"] = obj.ProductName;
                    flag = true;
                    break;
                }
            }
            if (flag == true)
            {
                dal.SaveChanges();
                return View("PurchaseSuccess");
            }
            return View("PurchaseFail");
        }

    }
}