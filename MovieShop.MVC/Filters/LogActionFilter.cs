using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieShop.MVC.Filters
{
    //ActionFilter Attribute
    //ExceptionFilter Attribute
    //AuthenticationFilter Attribute
    //AuthorizationFilter Attribute

        //Creating a custom filter to log some information about user
        //like his/her browser, tyoe of request, url he is accessing

    public class LogActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogSomeInformation("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogSomeInformation("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            LogSomeInformation("OnResultExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            LogSomeInformation("OnResultExecuting", filterContext.RouteData);
        }

        private void LogSomeInformation(string methodName, RouteData routData)
        {
            //we can log this info to any text file using any 3rd party logging
            //framework such as Nlog, Derling, Log4net
            var controllerName = routData.Values["controller"];
            var actionrName = routData.Values["action"];
        }
    }
}