using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Filters
{
    public class MovieShopExceptionFilter : HandleErrorAttribute
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
           
            //create a model for AhmdleErrorInfo, which is already built-in MVC
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            
           

            var dateExceptionHappened = DateTime.Now.TimeOfDay.ToString();

           

            var stackTrace = filterContext.Exception.StackTrace;

            var exceptionMessage = filterContext.Exception.Message;

            var innerException = filterContext.Exception.InnerException;

            //set breakpoint on the following line to see what the requested path and query is
            var pathAndQuery = filterContext.HttpContext.Request.Path + filterContext.HttpContext.Request.QueryString;

            //send some info to error view
            filterContext.Result = new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
            
           

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            //Http Status Code 500 should be used when and exception happens 
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            //Now used NLog to log above detalis to text file
            // throw new FileNotFoundException();
            // log the error using logging Frameworks such as nLog, SeriLog, log4net etc.
            try
            {
                Logger.Info("Something Wrong Here ===============>" + pathAndQuery);
                //System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Goodbye cruel world");
            }
            
            //send emails to Dev team
            //To send eamils in C# MailKit, download from Nuget
            base.OnException(filterContext);
           
        }
    }
}