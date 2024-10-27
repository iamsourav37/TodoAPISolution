using System.Security.Claims;

namespace TodoAPI.Utility
{
    public class CurrentUser
    {
        public static Guid GetCurrentUserId(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true)
            {
                var userIdString = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                return Guid.Parse(userIdString); // Assuming user ID is a Guid
            }

            return Guid.Empty; // Or throw an exception if user is not authenticated
        }
    }
}
