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
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemsController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItem()
        {
            var orderItems = await _orderItemRepository.GetOrderItems();
            return Ok(orderItems);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var orderItem = await _orderItemRepository.GetOrderItem(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        // PUT: api/OrderItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await _orderItemRepository.PutOrderItem(id, orderItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_orderItemRepository.OrderItemExists(id))
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

        // POST: api/OrderItems
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {
            var createdOrderItem = await _orderItemRepository.PostOrderItem(orderItem);
            return CreatedAtAction(nameof(GetOrderItem), new { id = createdOrderItem.Id }, createdOrderItem);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItem = await _orderItemRepository.GetOrderItem(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            await _orderItemRepository.DeleteOrderItem(id);
            return NoContent();
        }
    }
}
