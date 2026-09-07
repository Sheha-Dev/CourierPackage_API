using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageVerificationController : ControllerBase
    {
        private readonly IPackageVerificationService _packageVerificationService;

        public PackageVerificationController(IPackageVerificationService packageVerificationService)
        {
            _packageVerificationService = packageVerificationService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllPackageVerifications()
        {
            var result = await _packageVerificationService.GetAllPackageVerifications();

            return Ok(new { data = result.packageVerifications, message = result.message });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(
           [FromBody] PackageVerificationRequestDto request)
        {
            var result =
                await _packageVerificationService.CreatePackageVerification(request);

            return Ok(new
            {
                message = result.message
            });
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(
            [FromBody] PackageVerificationRequestDto request)
        {
            var result =
                await _packageVerificationService.UpdatePackageVerification(request);

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
        public async Task<IActionResult> Deactivate(int packageVerificationId)
        {
            var result =
                await _packageVerificationService.DeletePackageVerification(packageVerificationId);

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
