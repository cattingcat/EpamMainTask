using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class ExceptionController: Controller
    {
        public ViewResult Index()
        {
            Exception e = Session["Exception"] as Exception;
            return View(e);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Session.Remove("Exception");
        }
    }
}