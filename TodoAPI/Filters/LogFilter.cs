using Microsoft.AspNetCore.Mvc.Filters;

namespace TodoAPI.Filters
{
    public class LogFilter : Attribute, IActionFilter
    {
        private readonly ILogger<LogFilter> _logger;

        public LogFilter(ILogger<LogFilter> logger)
        {
            this._logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"LogFilter (OnActionExecuted), {context.HttpContext.Response.StatusCode}, {context.HttpContext.Response.ToString}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"LogFilter (OnActionExecuting), {context.HttpContext.Request.Method}, {context.HttpContext.Request.Path}");
        }
    }
}
