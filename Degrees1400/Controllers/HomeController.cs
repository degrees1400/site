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

        public ActionResult Index()
        {
            return View(new Email());
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
