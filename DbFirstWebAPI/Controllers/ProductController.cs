using DbFirstWebAPI.Data;
using DbFirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly NorthwndContext _db;

        public ProductController(NorthwndContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {

                List<Product> products = _db.Products.ToList();
                return Ok(products);
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
                
                Product product = _db.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
