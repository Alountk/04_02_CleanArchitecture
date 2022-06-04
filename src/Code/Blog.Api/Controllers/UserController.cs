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
                Username = user.Username,
                Password = user.Password,
                PasswordSalt = "blahblah",
                IsAdmin = false,
                IsActive = true,
                RegisteredAt = DateTime.Now,
            };

            user.Id = entitie.Id;

            await _userRepository.AddUserAsync(entitie);
            return Ok(user);
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
    }

}