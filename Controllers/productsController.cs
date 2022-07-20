using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tawsel.Helpers;
using tawsel.models;

namespace tawsel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class productsController : ControllerBase
    {
        private readonly tawseel _context;

        public productsController(tawseel context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<product>>> Getproducts()
        {
            return await _context.products.ToListAsync();
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<product>> Getproduct(int id)
        {
            var product = await _context.products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [RequestsFilter("update", "products")]

        public async Task<IActionResult> Putproduct(int id, product product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productExists(id))
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

        // POST: api/products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [RequestsFilter("insert", "products")]

        public async Task<ActionResult<product>> Postproduct(product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproduct", new { id = product.id }, product);
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        [RequestsFilter("update", "delete")]

        public async Task<IActionResult> Deleteproduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool productExists(int id)
        {
            return _context.products.Any(e => e.id == id);
        }
    }
}
