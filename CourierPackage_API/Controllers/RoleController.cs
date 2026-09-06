using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roleList =  _roleManager.Roles.ToList();
            return Ok(new { data = roleList });
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(
    [FromQuery] string roleName
)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest(new
                {
                    message = "Role name is required."
                });
            }

            var existingRole =
                await _roleManager.RoleExistsAsync(roleName);

            if (existingRole)
            {
                return BadRequest(new
                {
                    message = "Role already exists."
                });
            }

            var role = new IdentityRole
            {
                Name = roleName.Trim()
            };

            var result =
                await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    message = "Role has been created successfully."
                });
            }

            return BadRequest(new
            {
                message = "Unable to create role.",
                errors = result.Errors.Select(x => new
                {
                    code = x.Code,
                    description = x.Description
                })
            });
        }
    }
}
