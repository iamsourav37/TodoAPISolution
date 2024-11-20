using TodoAPI.Utility;

namespace TodoAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                ApiResponse apiResponse = new ApiResponse()
                {
                    StatusCode = 500,
                    Errors = ["Exception occured", ex.Message.ToString()]
                };
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(apiResponse);

            }
        }
    }
}
