using System.Reflection.Metadata;

using Blog.Infrastructure.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPosts()
        {
            var _posts = new PostRepository().GetAllPosts();
            return Ok(_posts);
        }
    }

}