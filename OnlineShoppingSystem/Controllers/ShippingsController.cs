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
    public class ShippingsController : ControllerBase
    {
        private readonly IShippingRepository _shippingRepository;

        public ShippingsController(IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }

        // GET: api/Shippings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping>>> GetShipping()
        {
            var shippings = await _shippingRepository.GetShipping();
            return Ok(shippings);
        }

        // GET: api/Shippings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping>> GetShipping(int id)
        {
            var shipping = await _shippingRepository.GetShipping(id);

            if (shipping == null)
            {
                return NotFound();
            }

            return shipping;
        }

        // PUT: api/Shippings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping(int id, Shipping shipping)
        {
            if (id != shipping.Id)
            {
                return BadRequest();
            }

            try
            {
                await _shippingRepository.PutShipping(id, shipping);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_shippingRepository.ShippingExists(id))
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

        // POST: api/Shippings
        [HttpPost]
        public async Task<ActionResult<Shipping>> PostShipping(Shipping shipping)
        {
            var createdShipping = await _shippingRepository.PostShipping(shipping);
            return CreatedAtAction(nameof(GetShipping), new { id = createdShipping.Id }, createdShipping);
        }

        // DELETE: api/Shippings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping(int id)
        {
            var shipping = await _shippingRepository.GetShipping(id);
            if (shipping == null)
            {
                return NotFound();
            }

            await _shippingRepository.DeleteShipping(id);
            return NoContent();
        }
    }
}
