using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogDbContext _context;
        public UserRepository(BlogDbContext context) => _context = context;
        public Task<List<User>> GetAllUsersAsync()
        {
            var _users = _context.Users.ToListAsync();
            return _users;
        }

        public Task<User?> GetUserByIdAsync(Guid userId)
        {
            var _user = _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return _user;
        }
    }
}