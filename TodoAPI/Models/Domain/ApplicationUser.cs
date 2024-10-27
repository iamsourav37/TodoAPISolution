using Microsoft.AspNetCore.Identity;

namespace TodoAPI.Models.Domain
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
    }
}
