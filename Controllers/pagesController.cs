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
    public class pagesController : ControllerBase
    {
        private readonly tawseel _context;

        public pagesController(tawseel context)
        {
            _context = context;
        }

        // GET: api/pages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<page>>> Getpages()
        {
            return await _context.pages.ToListAsync();
        }

        // GET: api/pages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<page>> Getpage(int id)
        {
            var page = await _context.pages.FindAsync(id);

            if (page == null)
            {
                return NotFound();
            }

            return page;
        }

        // PUT: api/pages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpage(int id, page page)
        {
            if (id != page.id)
            {
                return BadRequest();
            }

            _context.Entry(page).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pageExists(id))
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

        // POST: api/pages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<page>> Postpage(page page)
        {
            _context.pages.Add(page);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpage", new { id = page.id }, page);
        }

        // DELETE: api/pages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepage(int id)
        {
            var page = await _context.pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }

            _context.pages.Remove(page);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool pageExists(int id)
        {
            return _context.pages.Any(e => e.id == id);
        }
    }
}
