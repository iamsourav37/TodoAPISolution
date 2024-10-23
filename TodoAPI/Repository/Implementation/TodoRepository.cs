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

        public Task DeleteTodoAsync(Guid todoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Todo>> GetAllTodoAsync()
        {
            return await _dbContext.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(Guid id)
        {
            return await _dbContext.Todos.FindAsync(id);
        }

        public Task UpdateTodoAsync(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
