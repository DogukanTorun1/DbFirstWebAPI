using DbFirstWebAPI.Data;
using DbFirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly NorthwndContext _db;

        public SupplierController(NorthwndContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                return Ok(_db.Suppliers);
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
                Supplier supplier = _db.Suppliers.Find(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                return Ok(supplier);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _db.Suppliers.Add(supplier);
                _db.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = supplier.SupplierId }, supplier);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }   
    }
}
