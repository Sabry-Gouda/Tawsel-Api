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
    public class PremssionsController : ControllerBase
    {
        private readonly tawseel _context;

        public PremssionsController(tawseel context)
        {
            _context = context;
        }

        // GET: api/Premssions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Premssion>>> GetPremssions()
        {
            return await _context.Premssions.ToListAsync();
        }

        // GET: api/Premssions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Premssion>> GetPremssion(int id)
        {
            var premssion = await _context.Premssions.FindAsync(id);

            if (premssion == null)
            {
                return NotFound();
            }

            return premssion;
        }

        // PUT: api/Premssions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [RequestsFilter("update", "Premssions")]

        public async Task<IActionResult> PutPremssion(int id, Premssion premssion)
        {
            if (id != premssion.Id)
            {
                return BadRequest();
            }

            _context.Entry(premssion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremssionExists(id))
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

        // POST: api/Premssions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [RequestsFilter("insert", "Premssions")]

        public async Task<ActionResult<Premssion>> PostPremssion(Premssion premssion)
        {
            _context.Premssions.Add(premssion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPremssion", new { id = premssion.Id }, premssion);
        }

        // DELETE: api/Premssions/5
        [HttpDelete("{id}")]
        [RequestsFilter("delete", "Premssions")]

        public async Task<IActionResult> DeletePremssion(int id)
        {
            var premssion = await _context.Premssions.FindAsync(id);
            if (premssion == null)
            {
                return NotFound();
            }

            _context.Premssions.Remove(premssion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PremssionExists(int id)
        {
            return _context.Premssions.Any(e => e.Id == id);
        }
    }
}
