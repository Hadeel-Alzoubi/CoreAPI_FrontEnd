using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Topic_8_25.Models;

namespace Topic_8_25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public MyDbContext db;

        public ProductController(MyDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var product = db.Products.ToList();
            return Ok(product);
        }

        [HttpGet("getProduct/{product}")]
        public IActionResult GetBy(int product)
        {
            var products = db.Products.Where(p => p.ProductId == product);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = db.Products.Where(p => p.Category.CategoryId == id).Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.ProductImage,
                p.Price,
                Category = new
                {
                    p.Category.CategoryId,
                    p.Category.CategoryImage,
                    p.Category.CategoryName
                }
            }).ToList();
            return Ok(product);
        }
    }
}
