using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Core.Interfaces;
using Blog.Api.DTO;
using Blog.Core.Entities;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var _posts = await _postRepository.GetAllPostsAsync();
            return Ok(_posts);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(PostDTO post)
        {
            Post entitie = new Post
            {
                Id = Guid.NewGuid(),
                AuthorId = post.AuthorId,
                ParentId = post.ParentId,
                Title = post.Title,
                MetaTitle = post.MetaTitle,
                Slug = post.Slug,
                Summary = post.Summary,
                Published = post.Published,
                Deleted = post.Deleted,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                PublishedAt = DateTime.Now,
                Content = post.Content
            };
            await _postRepository.AddPostAsync(entitie);
            return Ok(post);
        }
    }

}