using Blog.Core.Entities;

namespace Blog.Infrastructure.Repositories
{
    public class PostRepository
    {

        public IEnumerable<Posts> GetAllPosts()
        {
            var _posts = Enumerable.Range(1, 50).Select(x => new Posts
            {
                id = Guid.NewGuid(),
                author_id = Guid.NewGuid(),
                parent_id = Guid.NewGuid(),
                title = "Post " + x,
                meta_title = "Post " + x,
                slug = "post-" + x,
                summary = "Post " + x,
                published = true,
                deleted = false,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                published_at = DateTime.Now,
                content = "Post " + x
            });
            return _posts;
        }
    }
}