using CourierPackage_API.Interfaces;
using CourierPackage_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllDistricts()
        {
            var result = await _districtService.GetAllDistricts();

            return Ok(new { data = result.districts, message = result.message });
        }
    }
}
