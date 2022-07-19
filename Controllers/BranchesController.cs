using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tawsel.models;

namespace tawsel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchesController : ControllerBase
    {
        private readonly tawseel _context;

        public BranchesController(tawseel context)
        {
            _context = context;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branches>>> GetBranches()
        {
            return await _context.Branches.ToListAsync();
        }


        [HttpGet("statustrue")]
        public  ActionResult<List<Branches>> GetBranchesTrue()
        {
            var branches = _context.Branches.Where(n => n.status == true);

            if (branches == null)
            {
                return NotFound();
            }

            return branches.ToList();
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Branches>> GetBranches(int id)
        {
            var branches = await _context.Branches.FindAsync(id);

            if (branches == null)
            {
                return NotFound();
            }

            return branches;
        }
      

        // PUT: api/Branches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranches(int id, Branches branches)
        {
            if (id != branches.id)
            {
                return BadRequest();
            }

            _context.Entry(branches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchesExists(id))
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

        // POST: api/Branches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Branches>> PostBranches(Branches branches)
        {
            _context.Branches.Add(branches);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranches", new { id = branches.id }, branches);
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranches(int id)
        {
            var branches = await _context.Branches.FindAsync(id);
            if (branches == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branches);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BranchesExists(int id)
        {
            return _context.Branches.Any(e => e.id == id);
        }
    }
}
