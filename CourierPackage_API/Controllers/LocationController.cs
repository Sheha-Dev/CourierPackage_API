using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _locationService.GetAllLocations();

            return Ok(new { data = result.locations, message = result.message });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(
           [FromBody] LocationRequestDto request)
        {
            var result =
                await _locationService.CreateLocation(request);

            return Ok(new
            {
                message = result.message
            });
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(
            [FromBody] LocationRequestDto request)
        {
            var result =
                await _locationService.UpdateLocation(request);

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

        [HttpPatch("{locationId}")]
        [Route("Deactivate")]
        public async Task<IActionResult> Delete(int locationId)
        {
            var result =
                await _locationService.DeleteLocation(locationId);

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
