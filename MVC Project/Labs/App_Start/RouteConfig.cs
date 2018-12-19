using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Labs
{
    /// <summary>
    /// LAB 2
    /// </summary>
    //This file contains the routing for the website
    //ignoreroute defines what routes are being blocked for user access
    //maproute is a dictionary that takes a url and directs the explorer to the releveant controller's action
    //search engines look into the url, then into the content - url should be relevant
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.config");
            routes.IgnoreRoute("{AdminGate}.Admin");


            //Website's default page 
            routes.MapRoute(
              name: "DefaultPage",
              url: "",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
          );

            //Customer list
            routes.MapRoute(
              name: "CustomerList",
              url: "CustomerList",
              defaults: new { controller = "Admin", action = "CustomerList", id = UrlParameter.Optional }
          );

            //Search customers by name
            routes.MapRoute(
              name: "NameSearch",
              url: "name",
              defaults: new { controller = "Admin", action = "SearchName", id = UrlParameter.Optional }
          );
            //Search customers by name
            routes.MapRoute(
              name: "NameHelp",
              url: "SearchCustomers",
              defaults: new { controller = "Admin", action = "SearchCustomers", id = UrlParameter.Optional }
          );

            //Search customers by ID
            routes.MapRoute(
              name: "IDSearch",
              url: "id",
              defaults: new { controller = "Admin", action = "SearchID", id = UrlParameter.Optional }
          );
            //Search customers by ID
            routes.MapRoute(
              name: "IDHelp",
              url: "searchcustomerid",
              defaults: new { controller = "Admin", action = "searchcustomerid", id = UrlParameter.Optional }
          );


            //Customer's default page
            routes.MapRoute(
              name: "CustomerDefault",
              url: "Enter",
              defaults: new { controller = "Customer", action = "Enter", id = UrlParameter.Optional }
          );

            //homepage maproute
            routes.MapRoute(
               name: "Home",
               url: "Home",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            //homepage second maproute
            routes.MapRoute(
               name: "Home1",
               url: "Home/ShowHome",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            //default maproute
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
