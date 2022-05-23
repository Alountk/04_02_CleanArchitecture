using System.Linq.Expressions;
using Blog.Core.DTO;
using Blog.Core.Entities;

namespace Blog.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<List<User>> FilterAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default);
        Task<User> AddAsync(UserDTO dto, CancellationToken cancellationToken = default);
        Task<User> UpdateAsync(UserDTO dto, CancellationToken cancellationToken = default);
        Task<User> DeleteAsync(UserDTO dto, CancellationToken cancellationToken = default);
    }
}