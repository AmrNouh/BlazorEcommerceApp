using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Website.Shared.DTOs;

namespace WesiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostRole(RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityRole role = new IdentityRole();
            role.Name = roleDto.RoleName;
            IdentityResult result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                foreach (IdentityError? item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return Ok("Role Created Successfully");

        }
    }
}
