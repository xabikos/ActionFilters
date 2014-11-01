using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ActionFilters
{
    /// <summary>
    /// Action filter attribute can be used in Controller class or methods to verify the current user has confirmed his email
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class UserConfirmedFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = filterContext.HttpContext.User.Identity.GetUserId();
            // User is not logged in so redirect him to log in controller action
            if (string.IsNullOrEmpty(userId))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                            new
                            {
                                controller = "Account",
                                action = "Login",
                                returnUrl = filterContext.HttpContext.Request.RawUrl
                            }));
                return;
            }

            var userManager = filterContext.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (!userManager.IsEmailConfirmed(userId))
            {
                filterContext.Result =
                    new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "ConstrollerNameToRedirect", action = "ActionMethodToRedirect" }));
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}