using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ActionFilters.Infrastructure
{
    /// <summary>
    /// Action filter attribute can be used in Web Api Controller class or methods to verify the current user has confirmed his email
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class UserConfirmedWebApiFilterAttribute : ActionFilterAttribute 
    {
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var userId = actionContext.RequestContext.Principal.Identity.GetUserId();
            // User is not logged in so redirect him to log in controller action
            if (string.IsNullOrEmpty(userId))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,
                    "You must be logged in to access this resource");
                return Task.FromResult(0);
            }

            var userManager = actionContext.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (!userManager.IsEmailConfirmed(userId))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "You must be verify your email address in order to access this resource");
                return Task.FromResult(0);
            }

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

    }
}