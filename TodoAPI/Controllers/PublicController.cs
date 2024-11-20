using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Filters;

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

        [HttpGet("exception-test")]
        public IActionResult ExceptionTest()
        {
            throw new NotImplementedException();
        }

        [HttpGet("zero-division-exception")]
        public IActionResult ExceptionTest2(int a, int b)
        {
            var result = a / b;
            return Ok(result);
        }
    }
}
