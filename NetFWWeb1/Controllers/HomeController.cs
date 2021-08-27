using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFWWeb1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ServiceReference1.Service1Client c1 = new ServiceReference1.Service1Client();
            var v1 = c1.GetData(3);
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