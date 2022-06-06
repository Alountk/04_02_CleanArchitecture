using Blog.Core.DTO;
using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostCommentController : ControllerBase
    {
        private readonly IPostCommentRepository _postCommentRepository;
        public PostCommentController(IPostCommentRepository postCommentRepository)
        {
            _postCommentRepository = postCommentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostComments()
        {
            var _postComments = await _postCommentRepository.GetAllCommentsAsync();
            return Ok(_postComments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostCommentById(Guid id)
        {
            var _postComment = await _postCommentRepository.GetCommentByIdAsync(id);
            return Ok(_postComment);
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetPostCommentsByPostId(Guid postId)
        {
            var _postComments = await _postCommentRepository.GetAllCommentsByPostIdAsync(postId);
            return Ok(_postComments);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostComment(PostCommentDTO postComment)
        {
            PostComment entitie = new PostComment
            {
                Id = Guid.NewGuid(),
                PostId = postComment.PostId,
                CategoryId = postComment.CategoryId,
                AuthorId = postComment.AuthorId,
                Title = postComment.Title,
                Content = postComment.Content,
                CreatedAt = DateTime.Now
            };

            postComment.Id = entitie.Id;

            await _postCommentRepository.AddCommentAsync(entitie);
            return Ok(postComment);
        }
    }
}