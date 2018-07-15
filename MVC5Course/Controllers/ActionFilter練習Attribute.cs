using System;
using System.Web.Mvc;

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
}