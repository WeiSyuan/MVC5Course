using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class RazorTestController : Controller
    {
        // GET: RazorTest
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult layout_test()
        {
            return View();
        }
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}
