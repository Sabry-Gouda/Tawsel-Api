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
    public class CustomRolesController : ControllerBase
    {
        private readonly tawseel _context;

        public CustomRolesController(tawseel context)
        {
            _context = context;
        }

        // GET: api/CustomRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomRole>>> GetCustomRoles()
        {
            return await _context.CustomRoles.ToListAsync();
        }

        // GET: api/CustomRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomRole>> GetCustomRole(string id)
        {
            var customRole = await _context.CustomRoles.FindAsync(id);

            if (customRole == null)
            {
                return NotFound();
            }

            return customRole;
        }

        // PUT: api/CustomRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomRole(string id, CustomRole customRole)
        {
            if (id != customRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(customRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomRoleExists(id))
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

        // POST: api/CustomRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomRole>> PostCustomRole(CustomRole customRole)
        {
            _context.CustomRoles.Add(customRole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomRoleExists(customRole.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomRole", new { id = customRole.Id }, customRole);
        }

        // DELETE: api/CustomRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomRole(string id)
        {
            var customRole = await _context.CustomRoles.FindAsync(id);
            if (customRole == null)
            {
                return NotFound();
            }

            _context.CustomRoles.Remove(customRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomRoleExists(string id)
        {
            return _context.CustomRoles.Any(e => e.Id == id);
        }
    }
}
