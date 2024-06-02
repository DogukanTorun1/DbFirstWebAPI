using DbFirstWebAPI.Data;
using DbFirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NorthwndContext _db;

        public RegionController(NorthwndContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                return Ok(_db.Regions);
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
                Region region = _db.Regions.Find(id);
                if (region == null)
                {
                    return NotFound();
                }
                return Ok(region);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Region region)
        {
            if (ModelState.IsValid)
            {
                _db.Regions.Add(region);
                _db.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = region.RegionId }, region);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
