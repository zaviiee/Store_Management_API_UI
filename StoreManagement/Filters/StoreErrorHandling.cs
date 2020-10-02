using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StoreManagement.Filters
{
    public class StoreErrorHandling : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(filterContext.Exception));
            if (!filterContext.ExceptionHandled)
            {
                filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary
                                   {
                                       { "action", "Error" },
                                       { "controller", "ErrorHandler" }
                                   });
                filterContext.ExceptionHandled = true;
            }
        }
    }
}