using todo_migration_app.Models;
using todo_migration_app.Repository;
using todo_migration_app.DTOs;
using todo_migration_app.Exceptions;

namespace todo_migration_app.Services
{
    public class AuthService
    {
            private readonly UserRepository _userRepository;
            private readonly TokenService _tokenService;

            public AuthService(UserRepository userRepository, TokenService tokenService)
            {
                _userRepository = userRepository;
                _tokenService = tokenService;
            }
            public async Task AddUser(RegisterDTO registerDTO)
            {
                User existingUser = await _userRepository.GetUserByIdAsync(registerDTO.Username);
                if (existingUser != null)
                {
                    throw new EmailAlreadyExistsException("Username already found");
                }
                User user = MapRegisterDTOWithUser(registerDTO);
                await _userRepository.CreateUserAsync(user);

            }
            private User MapRegisterDTOWithUser(RegisterDTO registerDTO)
            {
                User user = new User();
                user.FirstName = registerDTO.FirstName;
                user.LastName= registerDTO.LastName;
                user.Username = registerDTO.Username;
                user.Password = registerDTO.Password;
                return user;
            }


            public async Task<LoginReturnDTO> Login(LoginDTO loginDTO)
            {
                User storedUser = await _userRepository.GetUserByIdAsync(loginDTO.Email);
                if (storedUser == null)
                {
                    throw new Exception("User not found");
                }

                bool isPasswordSame = storedUser.Password == loginDTO.Password;
                if (isPasswordSame)
                {
                    LoginReturnDTO loginReturnDTO = new LoginReturnDTO();
                    loginReturnDTO.Username = storedUser.Username;
                    loginReturnDTO.token = _tokenService.GenerateToken(storedUser);
                    return loginReturnDTO;
                }
                throw new Exception("Invalid usernme or password");
            }


        } 
    }
