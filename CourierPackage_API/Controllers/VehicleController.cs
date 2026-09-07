using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllVehicles()
        {
            var result = await _vehicleService.GetAllVehicles();

            return Ok(new { data = result.vehicles, message = result.message });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(
           [FromBody] VehicleRequestDto request)
        {
            var result =
                await _vehicleService.CreateVehicle(request);

            return Ok(new
            {
                message = result.message
            });
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(
            [FromBody] VehicleRequestDto request)
        {
            var result =
                await _vehicleService.UpdateVehicle(request);

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
        public async Task<IActionResult> Deactivate(int vehicleId)
        {
            var result =
                await _vehicleService.DeleteVehicle(vehicleId);

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
