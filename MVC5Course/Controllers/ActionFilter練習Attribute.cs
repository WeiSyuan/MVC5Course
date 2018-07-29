using System;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Linq;

namespace MVC5Course.Controllers
{
    public class ActionFilter練習Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new RedirectResult("/MB/Index");
            }
            base.OnActionExecuting(filterContext);
        }

    }

    public class Rating下拉式選單Attribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var repo = RepositoryHelper.GetClientRepository();
            var items = (repo.All().Select(p => p.CreditRating)).Distinct().OrderBy(p => p).Select(p => new SelectListItem()
            {
                Text = p.Value.ToString(),
                Value = p.Value.ToString(),
            });


            filterContext.Controller.ViewBag.CreditRating = new SelectList(items, "Value", "Text");


            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //var repo = RepositoryHelper.GetClientRepository();
            //var items = (repo.All().Select(p => p.CreditRating)).Distinct().OrderBy(p => p).Select(p => new SelectListItem()
            //{
            //    Text = p.Value.ToString(),
            //    Value = p.Value.ToString(),
            //});


            //filterContext.Controller.ViewBag.CreditRating = new SelectList(items, "Value", "Text");

            base.OnActionExecuting(filterContext);
        }

    }
}