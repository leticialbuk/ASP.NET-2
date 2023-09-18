using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_2.Conrollers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync(
            [FromServices]BlogDataContext context) 
        {
            var categories = await context.Categories.ToListAsync();   
            return Ok(categories);    
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            var category = await context
                .Categories.
                FirstOrDefaultAsync(x=>x.Id == id);

            if (category == null) 
                return NotFound();

            return Ok(category);
        }
    }
}
