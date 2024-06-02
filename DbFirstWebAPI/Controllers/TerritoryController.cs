using DbFirstWebAPI.Data;
using DbFirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoryController : ControllerBase
    {
        private readonly NorthwndContext _db;

        public TerritoryController(NorthwndContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                return Ok(_db.Territories);
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
                Territory territory = _db.Territories.Find(id);
                if (territory == null)
                {
                    return NotFound();
                }
                return Ok(territory);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Territory territory)
        {
            if (ModelState.IsValid)
            {
                _db.Territories.Add(territory);
                _db.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = territory.TerritoryId }, territory);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
