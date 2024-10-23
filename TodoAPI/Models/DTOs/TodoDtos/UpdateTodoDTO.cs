using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models.DTOs.TodoDtos
{
    public class UpdateTodoDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
