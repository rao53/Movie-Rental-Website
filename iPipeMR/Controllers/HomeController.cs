using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace iPipeMR.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)] //This is an action filter allowing my page to not have to query the database again whenever the action is requested.
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
