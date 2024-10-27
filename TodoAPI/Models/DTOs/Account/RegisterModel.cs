using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models.DTOs.Account
{
    public class RegisterModel
    {
        public string? FullName { get; set; }

        [EmailAddress(ErrorMessage ="Please provide a proper email")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
