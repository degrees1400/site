using Degrees1400.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Degrees1400
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Database.SetInitializer(new NullDatabaseInitializer<DatabaseContext>());

            HttpRuntime.Cache["ProductMapping"] = new Dictionary<string, string>
            {
                {"default", "9424527"},
                {"kalani","9424510"},
                {"uprise-art","9424511"},
                {"wander","9424512"},
                {"dooce","9424513"},
                {"sean-bonner","9424514"},
                {"mark-frauenfelder","9424515"},
                {"chris-guillebeau","9424516"},
                {"dean-karnazes","9424518"},
                {"alexis-ohanian","9424519"},
                {"hellofresh","9424517"},
                {"nina-garcia","9424520"},
                {"timothy-ferriss","9424521"},
                {"poketo","9424522"},
                {"quarterly-technology-toys","9424523"},
                {"brandon-long","9424524"},
                {"connor-franta","9424525"},
                {"jesse-kornbluth","9424526"},
            };
        }
    }
}