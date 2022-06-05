using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Blog.Core.Interfaces;
using Blog.Core.DTO;
using Blog.Core.Entities;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            var _post = await _postRepository.GetPostByIdAsync(id);
            return Ok(_post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDTO post)
        {
            Post entitie = new Post
            {
                Id = Guid.NewGuid(),
                AuthorId = post.AuthorId,
                Title = post.Title,
                MetaTitle = post.MetaTitle,
                Slug = post.Slug,
                Summary = post.Summary,
                Published = true,
                Deleted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                PublishedAt = DateTime.Now,
                Content = post.Content
            };

            post.Id = entitie.Id;

            await _postRepository.AddPostAsync(entitie);
            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, PostUpdateDTO post)
        {
            var _post = await _postRepository.GetPostByIdAsync(id);
            if (_post == null)
            {
                return NotFound();
            }
            _post.Title = post.Title;
            _post.MetaTitle = post.MetaTitle;
            _post.Slug = post.Slug;
            _post.Summary = post.Summary;
            _post.Content = post.Content;
            _post.UpdatedAt = DateTime.Now;

            await _postRepository.UpdatePostAsync(_post);
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var _post = await _postRepository.GetPostByIdAsync(id);
            if (_post == null)
            {
                return NotFound();
            }
            await _postRepository.DeletePostAsync(_post);
            return Ok();
        }
    }

}