using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MyFollowApp.CustomAuthorization
{
    public class UserAuthentication : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string ProductOwnerRole = "ProductOwner"; // can be taken from resource file or config file
            string EndUserRole = "EndUser";
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {

                if (filterContext.HttpContext.User.IsInRole(ProductOwnerRole))
                {
                    filterContext.Result = new RedirectToRouteResult("Default",
                    new System.Web.Routing.RouteValueDictionary{
                        {"controller", "Account"},
                        {"action", "Login"},
                        {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                    });

                }
                if (filterContext.HttpContext.User.IsInRole(EndUserRole))
                {
                    filterContext.Result = new RedirectToRouteResult("Default",
                    new System.Web.Routing.RouteValueDictionary{
                        {"controller", "Account"},
                        {"action", "Login"},
                        {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                    });

                }
            }

        }
    }
}