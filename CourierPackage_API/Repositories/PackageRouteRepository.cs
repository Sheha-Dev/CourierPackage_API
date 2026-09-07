using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class PackageRouteRepository : IPackageRouteRepository
    {
        private readonly AppDbContext _context;

        public PackageRouteRepository(
            AppDbContext context
        )
        {
            _context = context;
        }


        // ==================================================
        // GET ALL PACKAGE ROUTES
        // ==================================================

        public async Task<List<PackageRouteResponseDto>>
            GetAllPackageRoutes()
        {
            return await _context.packageRoute
                .AsNoTracking()
                .Where(x => x.IsActive)
                .Select(x => new PackageRouteResponseDto
                {
                    PackageRouteId = x.PackageRouteId,
                    PackageId = x.PackageId,
                    SourceWarehouseId = x.SourceWarehouseId,
                    DestinationWarehouseId = x.DestinationWarehouseId,
                    DriverId = x.DriverId,
                    VehicleId = x.VehicleId,
                    ExpectedPickUpDate = x.ExpectedPickUpDate,
                    PickUpDate = x.PickUpDate,
                    ExpectedDeliverDate = x.ExpectedDeliverDate,
                    DeliverDate = x.DeliverDate,
                    Delivered = x.Delivered,
                    Priority = x.Priority,
                    IsActive = x.IsActive
                })
                .OrderByDescending(x => x.PackageRouteId)
                .ToListAsync();
        }


        // ==================================================
        // GET ROUTES BY PACKAGE ID
        // ==================================================

        public async Task<List<PackageRouteResponseDto>>
            GetPackageRoutesByPackageId(
                int packageId
            )
        {
            return await _context.packageRoute
                .AsNoTracking()
                .Where(x =>
                    x.PackageId == packageId &&
                    x.IsActive
                )
                .Select(x => new PackageRouteResponseDto
                {
                    PackageRouteId = x.PackageRouteId,
                    PackageId = x.PackageId,
                    SourceWarehouseId = x.SourceWarehouseId,
                    DestinationWarehouseId = x.DestinationWarehouseId,
                    DriverId = x.DriverId,
                    VehicleId = x.VehicleId,
                    ExpectedPickUpDate = x.ExpectedPickUpDate,
                    PickUpDate = x.PickUpDate,
                    ExpectedDeliverDate = x.ExpectedDeliverDate,
                    DeliverDate = x.DeliverDate,
                    Delivered = x.Delivered,
                    Priority = x.Priority,
                    IsActive = x.IsActive
                })
                .OrderBy(x => x.Priority)
                .ThenBy(x => x.ExpectedPickUpDate)
                .ToListAsync();
        }


        // ==================================================
        // GET BY DESTINATION WAREHOUSE + EXPECTED DELIVERY DATE
        // ==================================================

        public async Task<List<PackageRouteResponseDto>>
            GetPackageRouteByDestinationWarehouseIdAndExpectedDeliverDate(
                int destinationWarehouseId,
                DateTime expectedDeliverDate
            )
        {
            var startDate =
                expectedDeliverDate.Date;

            var endDate =
                startDate.AddDays(1);

            return await _context.packageRoute
                .AsNoTracking()
                .Where(x =>
                    x.DestinationWarehouseId ==
                        destinationWarehouseId &&

                    x.ExpectedDeliverDate >= startDate &&

                    x.ExpectedDeliverDate < endDate &&

                    x.IsActive
                )
                .Select(x => new PackageRouteResponseDto
                {
                    PackageRouteId = x.PackageRouteId,
                    PackageId = x.PackageId,
                    SourceWarehouseId = x.SourceWarehouseId,
                    DestinationWarehouseId =
                        x.DestinationWarehouseId,

                    DriverId = x.DriverId,
                    VehicleId = x.VehicleId,
                    ExpectedPickUpDate =
                        x.ExpectedPickUpDate,

                    PickUpDate = x.PickUpDate,

                    ExpectedDeliverDate =
                        x.ExpectedDeliverDate,

                    DeliverDate = x.DeliverDate,
                    Delivered = x.Delivered,
                    Priority = x.Priority,
                    IsActive = x.IsActive
                })
                .OrderBy(x => x.ExpectedDeliverDate)
                .ToListAsync();
        }


        // ==================================================
        // GET DELIVERED ROUTES BY DESTINATION WAREHOUSE
        // ==================================================

        public async Task<List<PackageRouteResponseDto>>
            GetDeliveredPackageRoutesByDestinationWarehouseId(
                int destinationWarehouseId
            )
        {
            return await _context.packageRoute
                .AsNoTracking()
                .Where(x =>
                    x.Delivered == true &&

                    x.DestinationWarehouseId ==
                        destinationWarehouseId &&

                    x.IsActive
                )
                .Select(x => new PackageRouteResponseDto
                {
                    PackageRouteId = x.PackageRouteId,
                    PackageId = x.PackageId,
                    SourceWarehouseId = x.SourceWarehouseId,
                    DestinationWarehouseId =
                        x.DestinationWarehouseId,

                    DriverId = x.DriverId,
                    VehicleId = x.VehicleId,

                    ExpectedPickUpDate =
                        x.ExpectedPickUpDate,

                    PickUpDate = x.PickUpDate,

                    ExpectedDeliverDate =
                        x.ExpectedDeliverDate,

                    DeliverDate = x.DeliverDate,

                    Delivered = x.Delivered,
                    Priority = x.Priority,
                    IsActive = x.IsActive
                })
                .OrderByDescending(x => x.DeliverDate)
                .ToListAsync();
        }


        // ==================================================
        // CREATE PACKAGE ROUTE
        // ==================================================

        public async Task<
            (
                bool success,
                string message,
                int packageRouteId
            )>
            CreatePackageRoute(
                PackageRouteRequestDto request
            )
        {
            try
            {
                var validation =
                    await ValidateDriverAndVehicle(
                        request.DriverId,
                        request.VehicleId,
                        request.ExpectedDeliverDate
                    );

                if (!validation.success)
                {
                    return (
                        false,
                        validation.message,
                        0
                    );
                }


                var packageExists =
                    await _context.packageRoute
                        .AnyAsync(x =>
                            x.PackageId ==
                                request.PackageId &&

                            x.IsActive
                        );

                if (!packageExists)
                {
                    return (
                        false,
                        "Selected package does not exist or is inactive.",
                        0
                    );
                }


                var sourceWarehouseExists =
                    await _context.warehouses
                        .AnyAsync(x =>
                            x.WarehouseId ==
                                request.SourceWarehouseId &&

                            x.IsActive
                        );

                if (!sourceWarehouseExists)
                {
                    return (
                        false,
                        "Selected source warehouse does not exist or is inactive.",
                        0
                    );
                }


                var destinationWarehouseExists =
                    await _context.warehouses
                        .AnyAsync(x =>
                            x.WarehouseId ==
                                request.DestinationWarehouseId &&

                            x.IsActive
                        );

                if (!destinationWarehouseExists)
                {
                    return (
                        false,
                        "Selected destination warehouse does not exist or is inactive.",
                        0
                    );
                }


                if (
                    request.SourceWarehouseId ==
                    request.DestinationWarehouseId
                )
                {
                    return (
                        false,
                        "Source warehouse and destination warehouse cannot be the same.",
                        0
                    );
                }


                if (
                    request.ExpectedDeliverDate <
                    request.ExpectedPickUpDate
                )
                {
                    return (
                        false,
                        "Expected delivery date cannot be earlier than expected pickup date.",
                        0
                    );
                }


                var now = DateTime.UtcNow;

                var route =
                    new PackageRoute
                    {
                        PackageId =
                            request.PackageId,

                        SourceWarehouseId =
                            request.SourceWarehouseId,

                        DestinationWarehouseId =
                            request.DestinationWarehouseId,

                        DriverId =
                            request.DriverId,

                        VehicleId =
                            request.VehicleId,

                        ExpectedPickUpDate =
                            request.ExpectedPickUpDate,

                        PickUpDate =
                            request.PickUpDate,

                        ExpectedDeliverDate =
                            request.ExpectedDeliverDate,

                        DeliverDate =
                            request.DeliverDate,

                        Delivered =
                            request.Delivered,

                        Priority =
                            request.Priority,

                        CreatedDate =
                            now,

                        CreatedBy =
                            request.TrnUser,

                        UpdatedDate =
                            now,

                        UpdatedBy =
                            request.TrnUser,

                        IsActive = true
                    };


                await _context.packageRoute
                    .AddAsync(route);

                await _context
                    .SaveChangesAsync();


                return (
                    true,
                    "Package route created successfully.",
                    route.PackageRouteId
                );
            }
            catch (Exception ex)
            {
                return (
                    false,
                    ex.Message,
                    0
                );
            }
        }


        // ==================================================
        // UPDATE PACKAGE ROUTE
        // ==================================================

        public async Task<
            (
                bool success,
                string message
            )>
            UpdatePackageRoute(
                PackageRouteRequestDto request
            )
        {
            try
            {
                var route =
                    await _context.packageRoute
                        .FirstOrDefaultAsync(x =>
                            x.PackageRouteId ==
                                request.PackageRouteId &&

                            x.IsActive
                        );


                if (route == null)
                {
                    return (
                        false,
                        "Package route not found."
                    );
                }


                var validation =
                    await ValidateDriverAndVehicle(
                        request.DriverId,
                        request.VehicleId,
                        request.ExpectedDeliverDate
                    );


                if (!validation.success)
                {
                    return (
                        false,
                        validation.message
                    );
                }


                if (
                    request.ExpectedDeliverDate <
                    request.ExpectedPickUpDate
                )
                {
                    return (
                        false,
                        "Expected delivery date cannot be earlier than expected pickup date."
                    );
                }


                if (
                    request.SourceWarehouseId ==
                    request.DestinationWarehouseId
                )
                {
                    return (
                        false,
                        "Source warehouse and destination warehouse cannot be the same."
                    );
                }


                route.PackageId =
                    request.PackageId;

                route.SourceWarehouseId =
                    request.SourceWarehouseId;

                route.DestinationWarehouseId =
                    request.DestinationWarehouseId;

                route.DriverId =
                    request.DriverId;

                route.VehicleId =
                    request.VehicleId;

                route.ExpectedPickUpDate =
                    request.ExpectedPickUpDate;

                route.PickUpDate =
                    request.PickUpDate;

                route.ExpectedDeliverDate =
                    request.ExpectedDeliverDate;

                route.DeliverDate =
                    request.DeliverDate;

                route.Delivered =
                    request.Delivered;

                route.Priority =
                    request.Priority;

                route.UpdatedDate =
                    DateTime.UtcNow;

                route.UpdatedBy =
                    request.TrnUser;


                await _context
                    .SaveChangesAsync();


                return (
                    true,
                    "Package route updated successfully."
                );
            }
            catch (Exception ex)
            {
                return (
                    false,
                    ex.Message
                );
            }
        }


        // ==================================================
        // DEACTIVATE PACKAGE ROUTE
        // ==================================================

        public async Task<
            (
                bool success,
                string message
            )>
            DeactivatePackageRoute(
                int packageRouteId,
                string trnUser
            )
        {
            try
            {
                var route =
                    await _context.packageRoute
                        .FirstOrDefaultAsync(x =>
                            x.PackageRouteId ==
                                packageRouteId &&

                            x.IsActive
                        );


                if (route == null)
                {
                    return (
                        false,
                        "Package route not found."
                    );
                }


                route.IsActive =
                    false;

                route.UpdatedDate =
                    DateTime.UtcNow;

                route.UpdatedBy =
                    trnUser;


                await _context
                    .SaveChangesAsync();


                return (
                    true,
                    "Package route deactivated successfully."
                );
            }
            catch (Exception ex)
            {
                return (
                    false,
                    ex.Message
                );
            }
        }


        // ==================================================
        // DRIVER / VEHICLE VALIDATION
        // ==================================================

        private async Task<
            (
                bool success,
                string message
            )>
            ValidateDriverAndVehicle(
                int driverId,
                int vehicleId,
                DateTime expectedDeliverDate
            )
        {
            /*
                Driver/vehicle documents must remain
                valid for 30 days after the expected
                delivery date.

                Example:

                Expected delivery:
                2026-09-10

                Required validity until:
                2026-10-10
            */

            var requiredValidDate =
                expectedDeliverDate.Date
                    .AddDays(30);


            var driver =
                await _context.driver
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.DriverId == driverId &&
                        x.IsActive
                    );


            if (driver == null)
            {
                return (
                    false,
                    "Selected driver does not exist or is inactive."
                );
            }


            /*
                Assuming Driver.VehicleExpirationDate
                represents driver licence expiration.

                Prefer renaming it to:
                DriverLicenseExpireDate
            */

            if (
                driver.VehicleExpirationDate.Date <
                requiredValidDate
            )
            {
                return (
                    false,

                    $"Selected driver's licence expires on " +
                    $"{driver.VehicleExpirationDate:yyyy-MM-dd}. " +
                    $"The licence must be valid until at least " +
                    $"{requiredValidDate:yyyy-MM-dd}, which is " +
                    $"30 days after the expected delivery date."
                );
            }


            var vehicle =
                await _context.vehicle
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.VehicleId == vehicleId &&
                        x.IsActive
                    );


            if (vehicle == null)
            {
                return (
                    false,
                    "Selected vehicle does not exist or is inactive."
                );
            }


            /*
                Ensure selected vehicle belongs
                to selected driver.
            */

            if (
                vehicle.DriverId != driverId
            )
            {
                return (
                    false,
                    "Selected vehicle is not assigned to the selected driver."
                );
            }


            if (
                vehicle.VehicleLicenceExpireDate.Date <
                requiredValidDate
            )
            {
                return (
                    false,

                    $"Selected vehicle licence expires on " +
                    $"{vehicle.VehicleLicenceExpireDate:yyyy-MM-dd}. " +
                    $"The vehicle licence must be valid until at least " +
                    $"{requiredValidDate:yyyy-MM-dd}, which is " +
                    $"30 days after the expected delivery date."
                );
            }


            if (
                vehicle.VehicleInsuranceExpireDate.Date <
                requiredValidDate
            )
            {
                return (
                    false,

                    $"Selected vehicle insurance expires on " +
                    $"{vehicle.VehicleInsuranceExpireDate:yyyy-MM-dd}. " +
                    $"The insurance must be valid until at least " +
                    $"{requiredValidDate:yyyy-MM-dd}, which is " +
                    $"30 days after the expected delivery date."
                );
            }


            if (
                vehicle.VehicleExpirationDate.Date <
                requiredValidDate
            )
            {
                return (
                    false,

                    $"Selected vehicle expires on " +
                    $"{vehicle.VehicleExpirationDate:yyyy-MM-dd}. " +
                    $"The vehicle must be valid until at least " +
                    $"{requiredValidDate:yyyy-MM-dd}."
                );
            }


            return (
                true,
                "Driver and vehicle are valid."
            );
        }
    }
}