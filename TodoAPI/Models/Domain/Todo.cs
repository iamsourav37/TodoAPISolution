﻿namespace TodoAPI.Models.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Guid UserId { get; set; }

    }
}
