using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace DependencyInversioon.Filters
{
    public class MyCustomExcepctions : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
           if(filterContext.Exception is NotImplementedException)
            {

                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error"
                };
            }
           
           else if (filterContext.Exception is DivideByZeroException)
            {

                filterContext.Result = new ViewResult()
                {
                    ViewName = "divideError"
                };
            }

            else
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error"
                };
            }



            filterContext.ExceptionHandled = true;

        }
    }
}