﻿using System;
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
    public class ShippingTypesController : ControllerBase
    {
        private readonly tawseel _context;

        public ShippingTypesController(tawseel context)
        {
            _context = context;
        }

        // GET: api/ShippingTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingType>>> GetShippingType()
        {
            return await _context.ShippingType.ToListAsync();
        }

        // GET: api/ShippingTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingType>> GetShippingType(int id)
        {
            var shippingType = await _context.ShippingType.FindAsync(id);

            if (shippingType == null)
            {
                return NotFound();
            }

            return shippingType;
        }

        // PUT: api/ShippingTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingType(int id, ShippingType shippingType)
        {
            if (id != shippingType.id)
            {
                return BadRequest();
            }

            _context.Entry(shippingType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingTypeExists(id))
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

        // POST: api/ShippingTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShippingType>> PostShippingType(ShippingType shippingType)
        {
            _context.ShippingType.Add(shippingType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShippingType", new { id = shippingType.id }, shippingType);
        }

        // DELETE: api/ShippingTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingType(int id)
        {
            var shippingType = await _context.ShippingType.FindAsync(id);
            if (shippingType == null)
            {
                return NotFound();
            }

            _context.ShippingType.Remove(shippingType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShippingTypeExists(int id)
        {
            return _context.ShippingType.Any(e => e.id == id);
        }
    }
}
