using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLocationController : ControllerBase
    {
        private readonly IUserLocationService _userUserLocationService;

        public UserLocationController(IUserLocationService userUserLocationService)
        {
            _userUserLocationService = userUserLocationService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllUserLocations()
        {
            var result = await _userUserLocationService.GetAllUserLocations();

            return Ok(new { data = result.userLocations, message = result.message });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(
           [FromBody] UserLocationRequestDto request)
        {
            var result =
                await _userUserLocationService.CreateUserLocation(request);

            return Ok(new
            {
                message = result.message
            });
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(
            [FromBody] UserLocationRequestDto request)
        {
            var result =
                await _userUserLocationService.UpdateUserLocation(request);

            if (!result.success)
            {
                return NotFound(new
                {
                    message = result.message
                });
            }

            return Ok(new
            {
                message = result.message
            });
        }

        [HttpPatch]
        [Route("Deactivate")]
        public async Task<IActionResult> Deactivate(int userUserLocationId)
        {
            var result =
                await _userUserLocationService.DeleteUserLocation(userUserLocationId);

            if (!result.success)
            {
                return NotFound(new
                {
                    message = result.message
                });
            }

            return Ok(new
            {
                message = result.message
            });
        }
    }
}
