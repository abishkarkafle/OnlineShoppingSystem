using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Interface;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetShipping()
        {
            var orders = await _orderRepository.GetOrders();
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetShipping(int id)
        {
            var order = await _orderRepository.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            try
            {
                await _orderRepository.PutOrder(id, order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_orderRepository.OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostShipping(Order order)
        {
            var createdOrder = await _orderRepository.PostOrder(order);
            return CreatedAtAction(nameof(GetShipping), new { id = createdOrder.Id }, createdOrder);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping(int id)
        {
            var order = await _orderRepository.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderRepository.DeleteOrder(id);
            return NoContent();
        }
    }
}
