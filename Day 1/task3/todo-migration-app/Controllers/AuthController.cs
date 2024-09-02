using Microsoft.AspNetCore.Mvc;
using todo_migration_app.DTOs;
using todo_migration_app.Services;

namespace todo_migration_app.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                await _authService.AddUser(registerDTO);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                    return BadRequest(ex.Message);
             
            }
        }

            [HttpPost]
            [Route("login")]

            public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
            {
            try
            {

                LoginReturnDTO data = await _authService.Login(loginDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        }
    }
