using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Core.Interfaces;
using Blog.Core.Entities;
using Blog.Core.DTO;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var _users = await _userRepository.GetAllUsersAsync();
            return Ok(_users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var _user = await _userRepository.GetUserByIdAsync(id);
            return Ok(_user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO user)
        {
            User entitie = new User
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                IsAdmin = false,
                IsActive = true,
                RegisteredAt = DateTime.Now,
            };

            user.Id = entitie.Id;

            await _userRepository.AddUserAsync(entitie);
            return Ok(user);
        }
    }

}