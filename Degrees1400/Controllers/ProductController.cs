using Degrees1400.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Degrees1400.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Products/

        public ActionResult Index([FromUri] string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                var model = new CuratorViewModel
                {
                    Timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds)
                };

                return View(model);
            }

            try
            {
                GoogleAnalytics ga = new GoogleAnalytics(this.HttpContext.Request);
                ga.TrackPage(id);
            }
            catch (Exception ex)
            {
            }

            string url = "http://quarterly.co/products/" + id;
            return Redirect(url);
        }

    }
}
