using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace TodoAPI.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if the user is authenticated
            if (context.HttpContext.User.Identity is not { IsAuthenticated: true })
            {
                // Return a custom response if the user is not authenticated
                context.Result = new JsonResult(new
                {
                    error = "Unauthorized",
                    message = "Access denied due to invalid or missing token."
                })
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
            }
        }
    }
}
