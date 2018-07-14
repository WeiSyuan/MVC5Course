using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            var data = "Hello World";
            ViewData.Model = data;  //強型別
            return View();
        }

        public ActionResult ViewBagDemo()
        {
            ViewBag.Text = "ViewBag";
            return View();
        }
        public ActionResult ViewDataDemo()
        {
            ViewData["Text"] = "ViewData";
            return View();
        }


        #region 通常表單會用這種技巧 寫入成功使用這在重整是不會再做第二次了
        public ActionResult TempDataDemo()
        {
            return View();
        }


        public ActionResult SaveTempData()
        {
            TempData["Text"] = "TempData";
            return Redirect("TempDataDemo");
        }
        #endregion
    }
}