using MyFollowApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MyFollowApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        string EmailId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string roles = string.Empty;

                        using (MyFollowContext entities = new MyFollowContext())
                        {
                            var user = entities.MyFollows.SingleOrDefault(u => u.EmailId == EmailId);

                            roles = user.Role;
                        }
                        //let us extract the roles from our own custom cookie
                        //if(roles =="Product Owner")
                        //{
                        //    RedirectToRouteResult(new RouteDirection());                        }

                        //Let us set the Pricipal with our user specific details
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(EmailId, "Forms"), roles.Split(';'));
                    }
                    catch (Exception e1)
                    {
                        //somehting went wrong
                        Response.Write(e1);
                    }
                }
            }
        }
    }
}
