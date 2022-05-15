using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;
        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddPostAsync(Post post)
        {
            _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            List<Post> _posts = await _context.Posts.ToListAsync();
            return _posts;
        }

        public async Task<Post?> GetPostByIdAsync(Guid postId)
        {
            Post? _post = await _context.Posts.FirstOrDefaultAsync(u => u.Id == postId);
            return _post;
        }
    }
}