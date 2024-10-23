using TodoAPI.Models.Domain;

namespace TodoAPI.Repository.Interface
{
    public interface ITodoRepository
    {
        Task CreateTodoAsync(Todo todo);
        Task UpdateTodoAsync(Todo todo);
        Task DeleteTodoAsync(Guid todoId);
        Task<Todo> GetTodoByIdAsync(Guid id);
        Task<IEnumerable<Todo>> GetAllTodoAsync();
    }
}
