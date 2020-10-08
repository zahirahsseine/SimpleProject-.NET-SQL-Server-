using MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Models
{
    public class LoggedOrAuthorizedAttribute : AuthorizeAttribute
    {
        public string ViewName { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            CheckIfUserIsAuthenticated(filterContext);
        }
        private void CheckIfUserIsAuthenticated(AuthorizationContext filterContext)
        {
           
            if (filterContext.HttpContext.Session==null)
            {
                ViewDataDictionary dic = new ViewDataDictionary();
                dic.Add("Message", "You don't have sufficient privileges for this operation");
                var result = new ViewResult() { ViewName = this.ViewName, ViewData = dic };

                filterContext.Result = result;
            }
            else
                base.HandleUnauthorizedRequest(filterContext);
        }
    }
}