
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using TodoAPI.Utility;

namespace TodoAPI.Middlewares
{
    public class TokenCheckMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("Token Check Middleware is invoked.");
            var endpoint = context.GetEndpoint();
            var authorizeAttribute = endpoint.Metadata.GetMetadata<AuthorizeAttribute>();

            if (authorizeAttribute != null)
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (string.IsNullOrEmpty(token))
                {
                    // Token is missing, return a custom error response
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";

                    var errorResponse = new ApiResponse
                    {
                        Errors = ["Unauthorized", "Token is missing or invalid."],
                        StatusCode = 401
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                    return;
                }
            }

            await next(context);
        }
    }
}
