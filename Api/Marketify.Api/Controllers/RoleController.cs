using Marketify.Business.DTOs.RoleDTOs;
using Marketify.Entity.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Marketify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateRole(string id)
        {
            var response = await _roleManager.CreateAsync(new Role { Id = Guid.NewGuid().ToString(), Name = id });
            IActionResult result = response.Succeeded ? Ok() : BadRequest();
            return result;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByNameAsync(id);
            var response = await _roleManager.DeleteAsync(role);
            IActionResult result = response.Succeeded ? Ok() : BadRequest();
            return result;
        }
        [HttpPost("AddUserToRoleById")]
        public async Task<IActionResult> AddUserToRole(IdentityUserRole<string> identityUserRole)
        {
            var user = await _userManager.FindByIdAsync(identityUserRole.UserId);
            var role = await _roleManager.FindByIdAsync(identityUserRole.RoleId);
            IdentityResult result = await _userManager.AddToRoleAsync(user, role.Name);
            IActionResult value = result.Succeeded ? Ok() : BadRequest();
            return value;
        }
        [HttpPost("AddUserToRoleByName")]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleDTO addUserToRoleDTO)
        {
            var user = await _userManager.FindByIdAsync(addUserToRoleDTO.UserId);
            var roles = await _userManager.GetRolesAsync(user);
            roles = roles.Where(x => x != addUserToRoleDTO.RoleName).ToList();
            await _userManager.RemoveFromRolesAsync(user, roles);
            IdentityResult result = await _userManager.AddToRoleAsync(user, addUserToRoleDTO.RoleName);
            IActionResult value = result.Succeeded ? Ok() : BadRequest();
            return value;
        }
        [HttpPost("AddUserToRoleByEmail")]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleByEmailDTO addUserToRoleByEmailDTO)
        {
            var user=await _userManager.FindByEmailAsync(addUserToRoleByEmailDTO.Email);
            if(user != null)
            {
             var result= await _userManager.AddToRoleAsync(user,addUserToRoleByEmailDTO.RoleName);
             if(result.Succeeded)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
