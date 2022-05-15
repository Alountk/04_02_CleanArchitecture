using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllPosts()
        {
            return Ok(new { blah = "blah" });
        }
        [HttpGet("{id}")]
        public IActionResult GetPostById(Guid id)
        {
            return Ok(new { blah = "blah" });
        }
    }
}