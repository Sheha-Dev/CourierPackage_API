using CourierPackage_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllProvinces()
        {
            var result = await _provinceService.GetAllProvinces();

            return Ok(new { data = result.provinces, message = result.message });
        }
    }
}
