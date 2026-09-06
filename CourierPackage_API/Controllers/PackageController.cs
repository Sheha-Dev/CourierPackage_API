using CourierPackage_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(
            IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllByUserId(
        string userId,
        CancellationToken cancellationToken)
        {
            var packages =
                await _packageService.GetAllByUserIdAsync(
                    userId,
                    cancellationToken);

            return Ok(packages);
        }
    }
}
