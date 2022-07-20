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
    public class ShipmentWeightsController : ControllerBase
    {
        private readonly tawseel _context;

        public ShipmentWeightsController(tawseel context)
        {
            _context = context;
        }

        // GET: api/ShipmentWeights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipmentWeight>>> GetWeightSettings()
        {
            return await _context.WeightSettings.ToListAsync();
        }

        // GET: api/ShipmentWeights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentWeight>> GetShipmentWeight(int id)
        {
            var shipmentWeight = await _context.WeightSettings.FindAsync(id);

            if (shipmentWeight == null)
            {
                return NotFound();
            }

            return shipmentWeight;
        }

        // PUT: api/ShipmentWeights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipmentWeight(int id, ShipmentWeight shipmentWeight)
        {
            if (id != shipmentWeight.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipmentWeight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentWeightExists(id))
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

        // POST: api/ShipmentWeights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShipmentWeight>> PostShipmentWeight(ShipmentWeight shipmentWeight)
        {
            _context.WeightSettings.Add(shipmentWeight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipmentWeight", new { id = shipmentWeight.Id }, shipmentWeight);
        }

        // DELETE: api/ShipmentWeights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipmentWeight(int id)
        {
            var shipmentWeight = await _context.WeightSettings.FindAsync(id);
            if (shipmentWeight == null)
            {
                return NotFound();
            }

            _context.WeightSettings.Remove(shipmentWeight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipmentWeightExists(int id)
        {
            return _context.WeightSettings.Any(e => e.Id == id);
        }
    }
}
