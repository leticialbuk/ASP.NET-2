using Blog.Data;
using Blog.Models;
using Blog_2.Extensions;
using Blog_2.Services;
using Blog_2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog_2.Conrollers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("v1/accounts/")]
        public async Task<IActionResult> Post(
           [FromBody]RegisterViewModel model,
           [FromServices]BlogDataContext context)  
        {
            if (!ModelState.IsValid) 
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Email.Replace("@", "-").Replace(".", "-")
            };
        }
            
        [HttpPost("v1/accounts/login")]
        public IActionResult Login([FromServices] TokenService tokenService) 
        {
            var token = tokenService.GenerateToken(null);
            return Ok(token);
        }

        // teste de roles

        //[Authorize(Roles = "user")]
        //[HttpGet("v1/user")]
        //public IActionResult GetUser() => Ok(User.Identity.Name);

        //[Authorize(Roles = "author")]
        //[HttpGet("v1/author")]
        //public IActionResult GetAuthor() => Ok(User.Identity.Name);

        //[Authorize(Roles = "admin")]
        //[HttpGet("v1/admin")]
        //public IActionResult GetAdmin() => Ok(User.Identity.Name);
    }
}
