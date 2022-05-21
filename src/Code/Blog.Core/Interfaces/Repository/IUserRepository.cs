using Microsoft.EntityFrameworkCore;

using Blog.Core.Entities;
using Blog.Core.Interfaces.Base;
using System.Linq.Expressions;

namespace Blog.Core.Interfaces.Repository
{
    public interface IUserRepository<TContext> : IBaseRepository<User, TContext> where TContext : DbContext, new()
    {
        Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<List<User>> FilterUserAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddUserAsync(User user, CancellationToken cancellationToken = default);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}