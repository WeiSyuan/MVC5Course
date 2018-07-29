using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Areas.Area.Controllers
{
    public class HomeController : Controller
    {
        // GET: Area/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}