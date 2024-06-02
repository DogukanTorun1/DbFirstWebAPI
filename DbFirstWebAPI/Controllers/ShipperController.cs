using DbFirstWebAPI.Data;
using DbFirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly NorthwndContext _db;

        public ShipperController(NorthwndContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                return Ok(_db.Shippers);
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
                Shipper shipper = _db.Shippers.Find(id);
                if (shipper == null)
                {
                    return NotFound();
                }
                return Ok(shipper);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                _db.Shippers.Add(shipper);
                _db.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = shipper.ShipperId }, shipper);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
