using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
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
            IPackageService packageService
        )
        {
            _packageService = packageService;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllPackages()
        {
            var result =
                await _packageService
                    .GetAllPackages();

            return Ok(new
            {
                data = result,
                message = "Packages loaded successfully."
            });
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetPackageById(
            int packageId
        )
        {
            var result =
                await _packageService
                    .GetPackageByPackageId(
                        packageId
                    );

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Package not found."
                });
            }

            return Ok(new
            {
                data = result,
                message = "Package loaded successfully."
            });
        }


        [HttpGet]
        [Route("GetByDateRange")]
        public async Task<IActionResult> GetPackageByDateRange(
            DateTime startDate,
            DateTime endDate
        )
        {
            if (startDate > endDate)
            {
                return BadRequest(new
                {
                    message =
                        "Start date cannot be greater than end date."
                });
            }

            var result =
                await _packageService
                    .GetPackageByDateRange(
                        startDate,
                        endDate
                    );

            return Ok(new
            {
                data = result,
                message = "Packages loaded successfully."
            });
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreatePackage(
            [FromBody] PackageRequestDto request
        )
        {
            var result =
                await _packageService
                    .CreatePackage(
                        request
                    );

            if (!result.success)
            {
                return BadRequest(new
                {
                    message = result.message
                });
            }

            return Ok(new
            {
                packageId =
                    result.packageId,

                message =
                    result.message
            });
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdatePackage(
            [FromBody] PackageRequestDto request
        )
        {
            var result =
                await _packageService
                    .UpdatePackage(
                        request
                    );

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


        [HttpPatch]
        [Route("Deactivate")]
        public async Task<IActionResult> DeactivatePackage(
            int packageId,
            string trnUser
        )
        {
            var result =
                await _packageService
                    .DeactivatePackage(
                        packageId,
                        trnUser
                    );

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

        [HttpGet]
        [Route("GetByUserId")]
        public async Task<IActionResult> GetByUserId(
            string userId
        )
        {
            var result =
                await _packageService
                    .GetByUserId(
                        userId
                    );

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Package not found."
                });
            }

            return Ok(new
            {
                data = result,
                message = "Package loaded successfully."
            });
        }
    }
}
