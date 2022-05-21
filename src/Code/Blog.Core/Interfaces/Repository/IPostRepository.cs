using System.Linq.Expressions;
using Blog.Core.Entities;
using Blog.Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Interfaces
{
    public interface IPostRepository<TContext> : IBaseRepository<Post, TContext> where TContext : DbContext, new()
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post?> GetPostByIdAsync(Guid postId);
        Task<List<Post>> FilterPostsAsync(Expression<Func<Post, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddPostAsync(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}