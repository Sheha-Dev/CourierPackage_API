using CourierPackage_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxTypeController : ControllerBase
    {
        private readonly IBoxTypeService _boxTypeService;
        public BoxTypeController(IBoxTypeService boxTypeService) 
        {
            _boxTypeService = boxTypeService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllBoxTypes()
        {
            var result = await _boxTypeService.GetAllBoxTypes();

            return Ok(new { data = result.boxTypes, message = result.message });
        }
    }
}
