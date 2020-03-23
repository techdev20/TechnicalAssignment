using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnException(ExceptionContext filterContext)
        {
            // Set View Result  
            ViewResult view = new ViewResult();
            
            //Set View Name
            view.ViewName = "Error";

             //Set Result
            filterContext.Result = view;
            
            // Set Exception Handler 
            filterContext.ExceptionHandled = true;
        }
    }
}