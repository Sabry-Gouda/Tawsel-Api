using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tawsel.Helpers;
using tawsel.models;

namespace tawsel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomRolesController : ControllerBase
    {
        private readonly RoleManager<CustomRole> _roleManager;

        public CustomRolesController(RoleManager<CustomRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: api/CustomRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomRole>>> GetCustomRoles()
        {
            return _roleManager.Roles.ToList();
        }

        // GET: api/CustomRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomRole>> GetCustomRole(string id)
        {
            var customRole = await _roleManager.FindByIdAsync(id);

            if (customRole == null)
            {
                return NotFound(new {message = "Can not find this role"});
            }

            return customRole;
        }

        [HttpPut("{id}")]
        [RequestsFilter("update", "CustomRoles")]

        public async Task<IActionResult> PutCustomRole(string id, CustomRole customRole)
        {
            if (id != customRole.Id)
            {
                return BadRequest();
            }

            await _roleManager.UpdateAsync(customRole);

            return NoContent();
        }

        // POST: api/CustomRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [RequestsFilter("insert", "CustomRoles")]

        public async Task<ActionResult<CustomRole>> PostCustomRole(CustomRole customRole)
        {
            await _roleManager.CreateAsync(customRole);
            return CreatedAtAction("GetCustomRole", new { id = customRole.Id }, customRole);
        }

        // DELETE: api/CustomRoles/5
        [HttpDelete("{id}")]
        [RequestsFilter("delete", "CustomRoles")]

        public async Task<IActionResult> DeleteCustomRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role is null)
                return BadRequest(new { message = "This role dose not exits" });

            await _roleManager.DeleteAsync(role);
            return NoContent();
        }

        private async Task<bool> CustomRoleExists(string id)
        {
           var role = await _roleManager.FindByIdAsync(id);
            return role is null ? false : true;
        }
    }
}
