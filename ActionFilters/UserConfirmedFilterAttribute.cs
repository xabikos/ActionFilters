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
        public override async void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = filterContext.HttpContext.User.Identity.GetUserId();
            var userManager = filterContext.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            if (!await userManager.IsEmailConfirmedAsync(userId))
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