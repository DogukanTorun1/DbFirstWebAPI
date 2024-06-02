using DbFirstWebAPI.Data;
using DbFirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly NorthwndContext _db;

        public CategoryController(NorthwndContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {

                List<Category> categories = _db.Categories.ToList();
                return Ok(categories);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {

                Category category = _db.Categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }   

    }
}
