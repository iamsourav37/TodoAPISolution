using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models.DTOs.TodoDtos
{
    public class CreateTodoDTO
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }

    }
}
