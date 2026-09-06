using CourierPackage_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllWarehouses()
        {
            var result = await _warehouseService.GetAllWarehouses();

            return Ok(new { data = result.warehouses, message = result.message });
        }
    }
}
