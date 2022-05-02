using System.Threading.Tasks;
using Blog.Core.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository) => _postRepository = postRepository;

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var _posts = _postRepository.GetAllPostsAsync();
            return Ok(_posts);
        }
    }

}