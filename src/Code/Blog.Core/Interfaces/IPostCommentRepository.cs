using Blog.Core.Entities;

namespace Blog.Core.Interfaces
{
    public interface IPostCommentRepository
    {
        Task<List<PostComment?>> GetAllCommentsAsync();
        Task<List<PostComment?>> GetAllCommentsByPostIdAsync(Guid postId);
        Task<PostComment?> GetCommentByIdAsync(Guid commentId);
        Task AddCommentAsync(PostComment comment);
        Task UpdateCommentAsync(PostComment comment);
        Task DeleteCommentAsync(PostComment comment);
    }
}