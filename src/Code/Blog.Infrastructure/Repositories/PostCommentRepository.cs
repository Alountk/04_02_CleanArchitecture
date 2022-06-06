using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class PostCommentRepository : IPostCommentRepository
    {
        private readonly BlogDbContext _context;
        public PostCommentRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(PostComment comment)
        {
            _context.PostComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public Task DeleteCommentAsync(PostComment comment)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PostComment?>> GetAllCommentsAsync()
        {
            List<PostComment?> _comments = await _context.PostComments.ToListAsync();
            return _comments;
        }

        public async Task<List<PostComment?>> GetAllCommentsByPostIdAsync(Guid postId)
        {
            List<PostComment?> _comment = await _context.PostComments.Where(u => u.PostId == postId).ToListAsync();
            return _comment;
        }

        public async Task<PostComment?> GetCommentByIdAsync(Guid commentId)
        {
            PostComment? _comment = await _context.PostComments.FirstOrDefaultAsync(u => u.Id == commentId);
            return _comment;
        }

        public Task UpdateCommentAsync(PostComment comment)
        {
            throw new NotImplementedException();
        }
    }
}