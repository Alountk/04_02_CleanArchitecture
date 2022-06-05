using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Blog.Core.Interfaces;
using Blog.Core.Entities;
using Blog.Core.DTO;
using Blog.Infrastructure.Services.Contracts;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public UserController(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var _users = await _userRepository.GetAllUsersAsync();
            return Ok(_users);
        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetUserById(Guid id)
        // {
        //     User _user = await _userRepository.GetUserByIdAsync(id);
        //     if (_user == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(_user);
        // }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            User _user = await _userRepository.GetUserByEmailAsync(email);
            if (_user == null)
            {
                return NotFound();
            }
            return Ok(_user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO user)
        {
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var userExist = await _userRepository.GetUserByUsernameAsync(user.Username);
            if (userExist != null)
            {
                return BadRequest("User already exist");
            }
            User entitie = new User
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                // Password = user.Password,
                Username = user.Username,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                IsAdmin = false,
                IsActive = true,
                RegisteredAt = DateTime.Now,
            };

            user.Id = entitie.Id;

            await _userRepository.AddUserAsync(entitie);
            // return Ok(user);
            return Ok(entitie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserUpdateDTO user)
        {
            var _user = await _userRepository.GetUserByIdAsync(id);
            if (_user == null)
            {
                return NotFound();
            }
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Username = user.Username;
            _user.UpdatedAt = DateTime.Now;

            await _userRepository.UpdateUserAsync(_user);
            return Ok(_user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var _user = await _userRepository.GetUserByIdAsync(id);
            if (_user == null)
            {
                return NotFound();
            }
            await _userRepository.DeleteUserAsync(_user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            var _user = await _userRepository.GetUserByUsernameAsync(user.Username);
            if (_user == null)
            {
                return NotFound();
            }
            if (!VerifyPasswordHash(user.Password, _user.PasswordHash, _user.PasswordSalt))
            {
                return Unauthorized();
            }
            var actualDate = DateTime.UtcNow;
            var validate = TimeSpan.FromHours(5);
            var expirationDate = actualDate.Add(validate);

            var token = _authService.GenerateToken(actualDate, _user, validate);
            return Ok(new
            {
                Token = token,
                ExpireAt = expirationDate
            });
        }

        static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }

}