using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Models.Domain;
using TodoAPI.Repository.Interface;

namespace TodoAPI.Repository.Implementation
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TodoRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task CreateTodoAsync(Todo todo)
        {
            _dbContext.Todos.Add(todo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteTodoAsync(Guid todoId, Guid userId)
        {
            var existingTodo = _dbContext.Todos.FirstOrDefault(todo => todo.Id == todoId && todo.UserId == userId);
            if (existingTodo != null)
            {
                _dbContext.Remove(existingTodo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Todo>> GetAllTodoAsync(Guid userId)
        {
            return await _dbContext.Todos.Where(todo => todo.UserId == userId).ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(Guid id, Guid userId)
        {
            return await _dbContext.Todos.FirstOrDefaultAsync(todo => todo.UserId == userId);
        }

        public Task UpdateTodoAsync(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
