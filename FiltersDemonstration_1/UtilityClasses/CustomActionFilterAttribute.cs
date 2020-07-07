using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersDemonstration_1.UtilityClasses
{
    public class CustomActionFilterAttribute : FilterAttribute, IActionFilter
    {
        private Stopwatch sw;

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            sw = new Stopwatch();
            sw.Start();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            sw.Stop();
            //write the Code to Log this information into DB;

            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];

            filterContext.HttpContext.Response.Write("Controller : <b>" + controllerName +
                "</b>, Action : <b>" + actionName + "</b> has taken : <b>" + sw.Elapsed + "</b>");
        }
    }

    public class CustomResultFilterAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            throw new NotImplementedException();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomActionResultFilterAttribute : FilterAttribute, IActionFilter, IResultFilter
    {
        private StreamWriter sw;

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            sw = new StreamWriter(@"D:\TestFile.txt", true);
            sw.WriteLine("In OnActionExecuting Method");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            sw.WriteLine("In OnActionExecuted Method");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            sw.WriteLine("In OnResultExecuting Method");
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            sw.WriteLine("In OnResultExecuted Method");
            sw.Close();
        }
    }
}