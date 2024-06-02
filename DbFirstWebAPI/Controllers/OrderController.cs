using DbFirstWebAPI.Data;
using DbFirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly NorthwndContext _db;

        public OrderController(NorthwndContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {

                List<Order> orders = _db.Orders.ToList();
                return Ok(orders);
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

                Order order = _db.Orders.Find(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Update(order);
                _db.SaveChanges();
                return Ok("Order updated");

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
