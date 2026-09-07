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
        private readonly IPackageRepository _packageRepository;

        public PackageController(
            IPackageRepository packageRepository
        )
        {
            _packageRepository = packageRepository;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllPackages()
        {
            var result =
                await _packageRepository
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
                await _packageRepository
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
                await _packageRepository
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
                await _packageRepository
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
                await _packageRepository
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
                await _packageRepository
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
    }
}
