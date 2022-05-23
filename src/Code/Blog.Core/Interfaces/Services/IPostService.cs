using System.Linq.Expressions;
using Blog.Core.DTO;
using Blog.Core.Entities;

namespace Blog.Core.Interfaces.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Post> GetByIdAsync(Guid postId, CancellationToken cancellationToken = default);
        Task<List<Post>> FilterAsync(Expression<Func<Post, bool>> predicate, CancellationToken cancellationToken = default);
        Task<Post> AddAsync(PostDTO dto, CancellationToken cancellationToken = default);
        Task<Post> UpdateAsync(PostDTO dto, CancellationToken cancellationToken = default);
        Task<Post> DeleteAsync(PostDTO dto, CancellationToken cancellationToken = default);
    }
}