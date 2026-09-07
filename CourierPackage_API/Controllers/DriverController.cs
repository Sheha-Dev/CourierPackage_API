using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllDrivers()
        {
            var result = await _driverService.GetAllDrivers();

            return Ok(new { data = result.drivers, message = result.message });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(
           [FromBody] DriverRequestDto request)
        {
            var result =
                await _driverService.CreateDriver(request);

            return Ok(new
            {
                message = result.message
            });
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(
            [FromBody] DriverRequestDto request)
        {
            var result =
                await _driverService.UpdateDriver(request);

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
        public async Task<IActionResult> Deactivate(int driverId)
        {
            var result =
                await _driverService.DeleteDriver(driverId);

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
