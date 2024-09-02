using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using todo_migration_app.DTOs;
using todo_migration_app.Services;

namespace todo_migration_app.Controllers
{
    [ApiController]
    [Route("api/todo")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoDto createTodoDto)
        {
            try
            {
                string username = User.FindFirst("username").Value.ToString();

                await _todoService.CreateTodo(createTodoDto, username);
                return Ok("Todo created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            try
            {
                string username = User.FindFirst("username").Value.ToString();

                var todos = await _todoService.GetAllTodos(username);
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }

}