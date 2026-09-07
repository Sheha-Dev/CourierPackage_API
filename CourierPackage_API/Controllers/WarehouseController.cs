using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using CourierPackage_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly ILocationService _locationService;

        public WarehouseController(IWarehouseService warehouseService,ILocationService locationService)
        {
            _warehouseService = warehouseService;
            _locationService = locationService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllWarehouses()
        {
            var result = await _warehouseService.GetAllWarehouses();

            return Ok(new
            {
                data = result.warehouses,
                message = result.message
            });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(
            [FromBody] WarehouseFullRequestDto fullRequestDto)
        {
            //var locationResult = await _locationService.CreateLocation(fullRequestDto.Location);
            var result = await _warehouseService.CreateWarehouse(fullRequestDto.Warehouse,fullRequestDto.Location);

            if (!result.success)
            {
                return BadRequest(new
                {
                    message = result.message
                });
            }

            return Ok(new
            {
                message = result.message
            });
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(
            [FromBody] WarehouseFullRequestDto fullRequestDto)
        {
            //var locationResult = await _locationService.UpdateLocation(fullRequestDto.Location);
            var result = await _warehouseService.UpdateWarehouse(fullRequestDto.Warehouse,fullRequestDto.Location);

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
        public async Task<IActionResult> Deactivate(
            int warehouseId)
        {
            var result =
                await _warehouseService.DeactivateWarehouse(warehouseId);

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