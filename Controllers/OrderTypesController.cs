using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tawsel.models;

namespace tawsel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTypesController : ControllerBase
    {
        private readonly tawseel _context;

        public OrderTypesController(tawseel context)
        {
            _context = context;
        }

        // GET: api/OrderTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderTypes>>> GetOrderTypes()
        {
            return await _context.OrderTypes.ToListAsync();
        }

        // GET: api/OrderTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderTypes>> GetOrderTypes(int id)
        {
            var orderTypes = await _context.OrderTypes.FindAsync(id);

            if (orderTypes == null)
            {
                return NotFound();
            }

            return orderTypes;
        }

        // PUT: api/OrderTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderTypes(int id, OrderTypes orderTypes)
        {
            if (id != orderTypes.id)
            {
                return BadRequest();
            }

            _context.Entry(orderTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderTypesExists(id))
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

        // POST: api/OrderTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderTypes>> PostOrderTypes(OrderTypes orderTypes)
        {
            _context.OrderTypes.Add(orderTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderTypes", new { id = orderTypes.id }, orderTypes);
        }

        // DELETE: api/OrderTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderTypes(int id)
        {
            var orderTypes = await _context.OrderTypes.FindAsync(id);
            if (orderTypes == null)
            {
                return NotFound();
            }

            _context.OrderTypes.Remove(orderTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderTypesExists(int id)
        {
            return _context.OrderTypes.Any(e => e.id == id);
        }
    }
}
