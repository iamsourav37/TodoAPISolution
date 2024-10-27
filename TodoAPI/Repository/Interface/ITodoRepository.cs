using TodoAPI.Models.Domain;

namespace TodoAPI.Repository.Interface
{
    public interface ITodoRepository
    {
        Task CreateTodoAsync(Todo todo);
        Task UpdateTodoAsync(Todo todo);
        Task<bool> DeleteTodoAsync(Guid todoId, Guid userId);
        Task<Todo> GetTodoByIdAsync(Guid id, Guid userId);
        Task<IEnumerable<Todo>> GetAllTodoAsync(Guid userId);
    }
}
