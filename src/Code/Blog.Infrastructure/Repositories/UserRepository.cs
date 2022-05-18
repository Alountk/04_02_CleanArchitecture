using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogDbContext _context;
        public UserRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> _users = await _context.Users.ToListAsync();
            return _users;
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            User? _user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return _user;
        }
    }
}