using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models.DTOs.TodoDtos
{
    public class CreateTodoDTO
    {
        [Required]
        [MinLength(5, ErrorMessage ="Title must be atleast 5 character long.")]
        [MaxLength(100, ErrorMessage = "Title should not exceed 100 character.")]
        public string Title { get; set; }
        public string? Description { get; set; }

    }
}
