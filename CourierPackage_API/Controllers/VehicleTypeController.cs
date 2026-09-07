using CourierPackage_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        public VehicleTypeController(IVehicleTypeService vehicleTypeService) 
        {
            _vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllVehicleTypes()
        {
            var result = await _vehicleTypeService.GetAllVehicleTypes();

            return Ok(new
            {
                data = result.VehicleTypes,
                message = result.message
            });
        }
    }
}
