using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic_8_25.Models;

namespace Topic_8_25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public MyDbContext db;

        public CategoriesController(MyDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var category = db.Categories.ToList();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = db.Categories.Where(c => c.CategoryId == id);
            return Ok(category);
        }

    }
}
