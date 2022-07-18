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
    public class CashTypesController : ControllerBase
    {
        private readonly tawseel _context;

        public CashTypesController(tawseel context)
        {
            _context = context;
        }

        // GET: api/CashTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashType>>> GetCashType()
        {
            return await _context.CashType.ToListAsync();
        }

        // GET: api/CashTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CashType>> GetCashType(int id)
        {
            var cashType = await _context.CashType.FindAsync(id);

            if (cashType == null)
            {
                return NotFound();
            }

            return cashType;
        }

        // PUT: api/CashTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashType(int id, CashType cashType)
        {
            if (id != cashType.id)
            {
                return BadRequest();
            }

            _context.Entry(cashType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashTypeExists(id))
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

        // POST: api/CashTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CashType>> PostCashType(CashType cashType)
        {
            _context.CashType.Add(cashType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCashType", new { id = cashType.id }, cashType);
        }

        // DELETE: api/CashTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashType(int id)
        {
            var cashType = await _context.CashType.FindAsync(id);
            if (cashType == null)
            {
                return NotFound();
            }

            _context.CashType.Remove(cashType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CashTypeExists(int id)
        {
            return _context.CashType.Any(e => e.id == id);
        }
    }
}
