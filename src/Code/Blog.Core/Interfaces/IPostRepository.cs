using Blog.Core.Entities;

namespace Blog.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post?> GetPostByIdAsync(Guid postId);
    }
}