using Blog_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog_2.Conrollers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("v1/login")]
        public IActionResult Login([FromServices] TokenService tokenService) 
        {
            var token = tokenService.GenerateToken(null);
            return Ok(token);
        }
    }
}
