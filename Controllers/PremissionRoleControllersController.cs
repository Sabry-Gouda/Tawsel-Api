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
    public class PremissionRoleControllersController : ControllerBase
    {
        private readonly tawseel _context;

        public PremissionRoleControllersController(tawseel context)
        {
            _context = context;
        }

        // GET: api/PremissionRoleControllers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PremissionRoleController>>> GetPremissionRoleControllers()
        {
            return await _context.PremissionRoleControllers.ToListAsync();
        }

        // GET: api/PremissionRoleControllers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PremissionRoleController>> GetPremissionRoleController(string id)
        {
            var premissionRoleController = await _context.PremissionRoleControllers.FindAsync(id);

            if (premissionRoleController == null)
            {
                return NotFound();
            }

            return premissionRoleController;
        }

        // PUT: api/PremissionRoleControllers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPremissionRoleController(string id, PremissionRoleController premissionRoleController)
        {
            if (id != premissionRoleController.RoleID)
            {
                return BadRequest();
            }

            _context.Entry(premissionRoleController).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremissionRoleControllerExists(id))
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

        // POST: api/PremissionRoleControllers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PremissionRoleController>> PostPremissionRoleController(PremissionRoleController premissionRoleController)
        {
            _context.PremissionRoleControllers.Add(premissionRoleController);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PremissionRoleControllerExists(premissionRoleController.RoleID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPremissionRoleController", new { id = premissionRoleController.RoleID }, premissionRoleController);
        }

        // DELETE: api/PremissionRoleControllers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePremissionRoleController(string id)
        {
            var premissionRoleController = await _context.PremissionRoleControllers.FindAsync(id);
            if (premissionRoleController == null)
            {
                return NotFound();
            }

            _context.PremissionRoleControllers.Remove(premissionRoleController);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PremissionRoleControllerExists(string id)
        {
            return _context.PremissionRoleControllers.Any(e => e.RoleID == id);
        }
    }
}
