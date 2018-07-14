using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

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
            ViewData["Text"] = "ViewData";  //弱型別
            return View();
        }


        #region 通常表單會用這種技巧 寫入成功使用這在重整是不會再做第二次了
        public ActionResult TempDataDemo()
        {
            return View();
        }


        public ActionResult SaveTempData()
        {
            Client C = new Client();
            C.City = "桃園市";
            TempData["Text"] = C;
            return Redirect("TempDataDemo");
        }
        #endregion

        public ActionResult MBinding(string id)
        {
            return Content(id);
        }
    }
}