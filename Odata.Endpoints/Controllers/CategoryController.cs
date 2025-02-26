using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Odata.Endpoints.Data;
using Odata.Endpoints.Data.Dto;

namespace Odata.Endpoints.Controllers
{
    [Route("Odata/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {

            return Ok(_context.Categories.AsQueryable());
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = new Category
            {
                CategoryName = category.CategoryName,
            };

            _context.Categories.Add(data);
            _context.SaveChangesAsync();
            return Ok("Created Successfully");
        }
    }
}
