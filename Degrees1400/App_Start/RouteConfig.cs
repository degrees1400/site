using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Degrees1400
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Privacy",
                "privacy",
                new { controller = "Home", action = "Privacy" }
                );

            routes.MapRoute(
                "About",
                "about",
                new { controller = "Home", action = "About" }
                );

            routes.MapRoute(
                name: "Products",
                url: "products/{id}",
                defaults: new { controller = "Product", action = "Index", id = "" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}