using Microsoft.AspNetCore.Mvc;

namespace Blog_2.Conrollers
{
    [ApiController]
    [Route ("")]
    public class HomeController : ControllerBase
    {
        [HttpGet ("")]
        public IActionResult Get() 
        { 
            return Ok();
        }
    }
}
