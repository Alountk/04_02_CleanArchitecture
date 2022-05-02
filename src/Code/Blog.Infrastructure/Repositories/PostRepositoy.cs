using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;
        public PostRepository(BlogDbContext context) => _context = context;

        public Task<List<Post>> GetAllPostsAsync()
        {
            var _posts = _context.Posts.ToListAsync();
            return _posts;
        }

        public Task<Post> GetPostByIdAsync(Guid postId)
        {
            var _user = _context.Posts.FirstOrDefaultAsync(u => u.Id == postId);
            return _user;
        }
    }
}