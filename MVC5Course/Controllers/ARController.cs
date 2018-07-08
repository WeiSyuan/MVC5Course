using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TestView()
        {
            string test = "test123";
            return View((object)test);
        }

        public ActionResult PartialTestView()
        {
            string test = "test123";
            return PartialView("TestView",(object)test);
        }


        public ActionResult FileView(string dl)
        {
            if (String.IsNullOrEmpty(dl))
            {
                return File(Server.MapPath("~/App_Data/maxresdefault.jpg"), "image/jpeg");
            }
            else
            {
                return File(Server.MapPath("~/App_Data/maxresdefault.jpg"), "image/jpeg","Moba.jpg");
            }
        }


    }
}