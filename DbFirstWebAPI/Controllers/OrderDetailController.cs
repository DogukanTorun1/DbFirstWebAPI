using DbFirstWebAPI.Data;
using DbFirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {

        private readonly NorthwndContext _db;

        public OrderDetailController(NorthwndContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {

                List<OrderDetail> orderDetails = _db.OrderDetails.ToList();
                return Ok(orderDetails);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("OrderID/ProductID")]
        public IActionResult Get(int OrderId, int ProductId)
        {
            if (ModelState.IsValid)
            {

                OrderDetail orderDetail = _db.OrderDetails.Find(OrderId, ProductId);
                if (orderDetail == null)
                {
                    return NotFound();
                }
                return Ok(orderDetail);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("OrderId")]
        public IActionResult Get(int OrderId)
        {
            if (ModelState.IsValid)
            {

                List<OrderDetail> orderDetails = _db.OrderDetails.Where(o => o.OrderId == OrderId).ToList();
                if (orderDetails == null)
                {
                    return NotFound();
                }
                return Ok(orderDetails);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }



    }
}
