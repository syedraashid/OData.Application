using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Odata.Endpoints.Data;
using Odata.Endpoints.Data.Dto;

namespace Odata.Endpoints.Controllers
{
    [Route("Odata/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {

            return Ok(_context.Products.AsQueryable());
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = new Product
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Rating = product.Rating,
                CategoryId = product.CategoryId,
            };

            _context.Products.Add(data);
            _context.SaveChangesAsync();
            return Ok("Created Successfully");
        }
    }
}
