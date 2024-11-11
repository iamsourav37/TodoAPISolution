using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("this is public api");
        }
    }
}
