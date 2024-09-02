using Microsoft.EntityFrameworkCore;
using todo_migration_app.Models;

namespace todo_migration_app.Repository
{
    public class TodoRepository
    {

        private readonly TodoAppContext _context;

        public TodoRepository(TodoAppContext context)
        {
            _context = context;
        }

        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> GetUserByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<List<Todo>> GetAllTodosAsync(string username)
        {
            return await _context.Todos
                         .Where(todo => todo.Username == username)
                         .ToListAsync();
        }

        public async Task<Todo> UpdateTodosAsync(Todo todo)
        {
            if (!_context.Todos.Any(t => t.Id == todo.Id))
            {
                return null;
            }

            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return false;
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
