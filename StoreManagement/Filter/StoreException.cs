using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StoreManagement
{
    public class StoreException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is NullReferenceException)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "ErrorHandling", action = "Error" }));
                filterContext.ExceptionHandled = true;
            }
        }
    }
}