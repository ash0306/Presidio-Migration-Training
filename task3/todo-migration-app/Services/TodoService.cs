using todo_migration_app.DTOs;
using todo_migration_app.Models;
using todo_migration_app.Repository;

namespace todo_migration_app.Services
{
    public class TodoService
    {
        private readonly TodoRepository _todoRepository;

        public TodoService(TodoRepository todoRepository) {
            _todoRepository = todoRepository;
        }

        public async Task CreateTodo(CreateTodoDto createTodoDto, string username)
        {
            Todo createTodoDto1 = new Todo
            {
                Description = createTodoDto.Description,
                Status = true,
                TargetDate = createTodoDto.TargetDate,
                Title = createTodoDto.Title,
                Username = username
            }
            ;
            await _todoRepository.CreateTodoAsync(createTodoDto1);

        }

        public async Task<List<Todo>> GetAllTodos(string username)
        {
            return await _todoRepository.GetAllTodosAsync(username);
        }

    }
}
