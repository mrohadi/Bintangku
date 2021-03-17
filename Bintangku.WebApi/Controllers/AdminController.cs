using System.Linq;
using System.Threading.Tasks;
using Bintangku.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly UserManager<NakesUser> _userManager;
        public AdminController(UserManager<NakesUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Policy = "RequirePuskesmasRole")]
        [HttpGet("admin-with-roles")] 
        public async Task<ActionResult> GetUsersWithRoles()
        {
            var user = await _userManager.Users
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new 
                {
                    u.Id,
                    Username = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                })
                .ToListAsync();
            
            return Ok(user);
        }

        [HttpPost("edit-roles/{id}")]
        public async Task<ActionResult> EditRole(string id, [FromQuery] string roles)
        {
            var selectedRoles = roles.Split(",").ToArray();

            var user = await _userManager.FindByIdAsync(id);
            
            if (user == null) return NotFound("User could not found");
            
            var currentUserRole = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(
                user, selectedRoles.Except(currentUserRole));
            
            if (!result.Succeeded) return BadRequest("Failed to add role");

            result = await _userManager.RemoveFromRolesAsync(
                user, currentUserRole.Except(selectedRoles));
            
            if (!result.Succeeded) return BadRequest("Failed to remove from roles");

            return Ok(await _userManager.GetRolesAsync(user));
        }
        
        [Authorize(Policy = "RequirePuskesmasRole")]
        [HttpGet("puskesmas-with-roles")] 
        public ActionResult GetPuskesmasRoles()
        {
            return Ok("Only admin or puskesmas can see this");
        }
    }
}