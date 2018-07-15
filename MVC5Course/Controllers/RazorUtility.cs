using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Helpers
{
    public static class RazorUtility
    {
       public static string GetRouteValue(WebViewPage v,string get_name)
        {
            return v.ViewContext.RouteData.Values[get_name]?.ToString();
        }
    }
}