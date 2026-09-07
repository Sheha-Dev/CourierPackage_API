using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageRouteController : ControllerBase
    {
        private readonly IPackageRouteRepository _packageRouteRepository;

        public PackageRouteController(
            IPackageRouteRepository packageRouteRepository
        )
        {
            _packageRouteRepository = packageRouteRepository;
        }


        // GET: api/PackageRoute/GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllPackageRoutes()
        {
            var result =
                await _packageRouteRepository
                    .GetAllPackageRoutes();

            return Ok(new
            {
                data = result,
                message = "Package routes loaded successfully."
            });
        }


        // GET: api/PackageRoute/GetByPackageId?packageId=1
        [HttpGet]
        [Route("GetByPackageId")]
        public async Task<IActionResult> GetPackageRoutesByPackageId(
            int packageId
        )
        {
            var result =
                await _packageRouteRepository
                    .GetPackageRoutesByPackageId(
                        packageId
                    );

            return Ok(new
            {
                data = result,
                message = "Package routes loaded successfully."
            });
        }


        // GET:
        // api/PackageRoute/GetByDestinationAndExpectedDate
        // ?destinationWarehouseId=2
        // &expectedDeliverDate=2026-09-10
        [HttpGet]
        [Route("GetByDestinationAndExpectedDate")]
        public async Task<IActionResult>
            GetPackageRouteByDestinationWarehouseIdAndExpectedDeliverDate(
                int destinationWarehouseId,
                DateTime expectedDeliverDate
            )
        {
            var result =
                await _packageRouteRepository
                    .GetPackageRouteByDestinationWarehouseIdAndExpectedDeliverDate(
                        destinationWarehouseId,
                        expectedDeliverDate
                    );

            return Ok(new
            {
                data = result,
                message = "Package routes loaded successfully."
            });
        }


        // GET:
        // api/PackageRoute/GetDeliveredByDestination
        // ?destinationWarehouseId=2
        [HttpGet]
        [Route("GetDeliveredByDestination")]
        public async Task<IActionResult>
            GetDeliveredPackageRoutesByDestinationWarehouseId(
                int destinationWarehouseId
            )
        {
            var result =
                await _packageRouteRepository
                    .GetDeliveredPackageRoutesByDestinationWarehouseId(
                        destinationWarehouseId
                    );

            return Ok(new
            {
                data = result,
                message = "Delivered package routes loaded successfully."
            });
        }


        // POST: api/PackageRoute/Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreatePackageRoute(
            [FromBody] PackageRouteRequestDto request
        )
        {
            var result =
                await _packageRouteRepository
                    .CreatePackageRoute(
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
                packageRouteId = result.packageRouteId,
                message = result.message
            });
        }


        // PUT: api/PackageRoute/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdatePackageRoute(
            [FromBody] PackageRouteRequestDto request
        )
        {
            var result =
                await _packageRouteRepository
                    .UpdatePackageRoute(
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


        // PATCH:
        // api/PackageRoute/Deactivate
        // ?packageRouteId=1
        // &trnUser=admin
        [HttpPatch]
        [Route("Deactivate")]
        public async Task<IActionResult> DeactivatePackageRoute(
            int packageRouteId,
            string trnUser
        )
        {
            var result =
                await _packageRouteRepository
                    .DeactivatePackageRoute(
                        packageRouteId,
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