using DbFirstWebAPI.Data;
using DbFirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly NorthwndContext _db;

        public CustomerController(NorthwndContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {

                List<Customer> customers = _db.Customers.ToList();
                return Ok(customers);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (ModelState.IsValid)
            {

                Customer customer = _db.Customers.Find(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
