using Degrees1400.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Degrees1400.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string id)
        {
            var model = new CuratorViewModel
            {
                Timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds)
            };

            var productId = "9424527";

            var mapping = HttpRuntime.Cache["ProductMapping"] as Dictionary<string,string>;

            if(!String.IsNullOrWhiteSpace(id) && mapping != null)
            {
                if (mapping.ContainsKey(id))
                    productId = mapping[id];
            }

            model.TrackingPixel = String.Format("http://bs.serving-sys.com/BurstingPipe/adServer.bs?cn=tf&c=20&mc=click&pli={0}&PluID=0&ord={1}", productId, model.Timestamp);


            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Email model )
        {
            if (ModelState.IsValid)
            {
                using (var context = new DatabaseContext())
                {
                    var email = new Email { Address = model.Address };

                    context.Emails.Add(email);

                    context.SaveChanges();
                }

                return new RedirectResult("https://quarterly.co/newsletter-almost-finished");
            }
            else
                return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
