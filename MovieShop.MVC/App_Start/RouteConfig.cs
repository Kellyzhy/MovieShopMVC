using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieShop.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //ASP .NET MVC Routing
            //Two kinds of routing
            //1.convention based routing
            //2.attribute based routing --introduced in MVC 5 -- preferred
            //Routing in MVC is pattern matching technique
            //{} braces are place holder, they will be used for incomng URL

            // attribute based routing
            routes.MapMvcAttributeRoutes();

            //conventional based routing
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
