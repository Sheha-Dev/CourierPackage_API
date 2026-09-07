using CourierPackage_API.Interfaces;
using CourierPackage_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageStatusController : ControllerBase
    {
        private readonly IPackageStatusService _packageStatusService;
        public PackageStatusController(IPackageStatusService packageStatusService) 
        {
            _packageStatusService = packageStatusService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllPackageStatus()
        {
            var result = await _packageStatusService.GetAllPackageStatus();

            return Ok(new
            {
                data = result.packageStatuses,
                message = result.message
            });
        }
    }
}
