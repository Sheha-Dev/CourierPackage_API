using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly AppDbContext _context;

        public PackageRepository(
            AppDbContext context
        )
        {
            _context = context;
        }


        // =========================================
        // GET ALL PACKAGES
        // =========================================

        public async Task<List<PackageResponseDto>>
            GetAllPackages()
        {
            var packages =
                await _context.packageMaster

                    .AsNoTracking()

                    .Where(
                        p => p.IsActive
                    )

                    .Select(
                        p =>
                            new PackageResponseDto
                            {
                                PackageId =
                                    p.PackageId,

                                PackageTrackingId =
                                    p.PackageTrackingId,

                                BoxTypeId =
                                    p.BoxTypeId,

                                BoxDimensionId =
                                    p.BoxDimensionId,

                                SenderId =
                                    p.SenderId,

                                RecipientId =
                                    p.RecipientId,

                                EstimatedWeight =
                                    p.EstimatedWeight,

                                IsVerified =
                                    p.IsVerified,

                                StatusId =
                                    p.StatusId,

                                HandOverWarehouseId =
                                    p.HandOverWarehouseId,

                                DestinationId =
                                    p.DestinationId,

                                EstimatedAmount =
                                    p.EstimatedAmount,

                                ActualAmount =
                                    p.ActualAmount,

                                ReceivedDate =
                                    p.ReceivedDate,

                                ExpectedDeliverDate =
                                    p.ExpectedDeliverDate,

                                CreatedDate =
                                    p.CreatedDate,

                                CreatedBy =
                                    p.CreatedBy,

                                UpdatedDate =
                                    p.UpdatedDate,

                                UpdatedBy =
                                    p.UpdatedBy,

                                IsActive =
                                    p.IsActive
                            }
                    )

                    .OrderByDescending(
                        p => p.PackageId
                    )

                    .ToListAsync();


            return packages;
        }


        // =========================================
        // GET PACKAGE BY ID
        // =========================================

        public async Task<PackageResponseDto?>
            GetPackageByPackageId(
                int packageId
            )
        {
            var package =
                await _context.packageMaster

                    .AsNoTracking()

                    .Where(
                        p =>
                            p.PackageId == packageId &&
                            p.IsActive
                    )

                    .Select(
                        p =>
                            new PackageResponseDto
                            {
                                PackageId =
                                    p.PackageId,

                                PackageTrackingId =
                                    p.PackageTrackingId,

                                BoxTypeId =
                                    p.BoxTypeId,

                                BoxDimensionId =
                                    p.BoxDimensionId,

                                SenderId =
                                    p.SenderId,

                                RecipientId =
                                    p.RecipientId,

                                EstimatedWeight =
                                    p.EstimatedWeight,

                                IsVerified =
                                    p.IsVerified,

                                StatusId =
                                    p.StatusId,

                                HandOverWarehouseId =
                                    p.HandOverWarehouseId,

                                DestinationId =
                                    p.DestinationId,

                                EstimatedAmount =
                                    p.EstimatedAmount,

                                ActualAmount =
                                    p.ActualAmount,

                                ReceivedDate =
                                    p.ReceivedDate,

                                ExpectedDeliverDate =
                                    p.ExpectedDeliverDate,

                                CreatedDate =
                                    p.CreatedDate,

                                CreatedBy =
                                    p.CreatedBy,

                                UpdatedDate =
                                    p.UpdatedDate,

                                UpdatedBy =
                                    p.UpdatedBy,

                                IsActive =
                                    p.IsActive
                            }
                    )

                    .FirstOrDefaultAsync();


            return package;
        }


        // =========================================
        // GET PACKAGES BY DATE RANGE
        // =========================================

        public async Task<List<PackageResponseDto>>
            GetPackageByDateRange(
                DateTime startDate,
                DateTime endDate
            )
        {
            /*
                Makes end date inclusive.

                Example:
                startDate = 2026-09-01
                endDate   = 2026-09-07

                This includes everything until
                2026-09-07 23:59:59...
            */

            var start =
                startDate.Date;

            var end =
                endDate.Date.AddDays(1);


            var packages =
                await _context.packageMaster

                    .AsNoTracking()

                    .Where(
                        p =>
                            p.IsActive &&

                            p.CreatedDate >= start &&

                            p.CreatedDate < end
                    )

                    .Select(
                        p =>
                            new PackageResponseDto
                            {
                                PackageId =
                                    p.PackageId,

                                PackageTrackingId =
                                    p.PackageTrackingId,

                                BoxTypeId =
                                    p.BoxTypeId,

                                BoxDimensionId =
                                    p.BoxDimensionId,

                                SenderId =
                                    p.SenderId,

                                RecipientId =
                                    p.RecipientId,

                                EstimatedWeight =
                                    p.EstimatedWeight,

                                IsVerified =
                                    p.IsVerified,

                                StatusId =
                                    p.StatusId,

                                HandOverWarehouseId =
                                    p.HandOverWarehouseId,

                                DestinationId =
                                    p.DestinationId,

                                EstimatedAmount =
                                    p.EstimatedAmount,

                                ActualAmount =
                                    p.ActualAmount,

                                ReceivedDate =
                                    p.ReceivedDate,

                                ExpectedDeliverDate =
                                    p.ExpectedDeliverDate,

                                CreatedDate =
                                    p.CreatedDate,

                                CreatedBy =
                                    p.CreatedBy,

                                UpdatedDate =
                                    p.UpdatedDate,

                                UpdatedBy =
                                    p.UpdatedBy,

                                IsActive =
                                    p.IsActive
                            }
                    )

                    .OrderByDescending(
                        p => p.CreatedDate
                    )

                    .ToListAsync();


            return packages;
        }


        // =========================================
        // CREATE PACKAGE
        // =========================================

        public async Task<
            (
                bool success,
                string message,
                int packageId
            )>
            CreatePackage(
                PackageRequestDto request
            )
        {
            try
            {
                var now =
                    DateTime.UtcNow;


                var package =
                    new PackageMaster
                    {
                        PackageTrackingId =
                            request.PackageTrackingId,

                        BoxTypeId =
                            request.BoxTypeId,

                        BoxDimensionId =
                            request.BoxDimensionId,

                        SenderId =
                            request.SenderId,

                        RecipientId =
                            request.RecipientId,

                        EstimatedWeight =
                            request.EstimatedWeight,

                        IsVerified =
                            request.IsVerified,

                        StatusId =
                            request.StatusId,

                        HandOverWarehouseId =
                            request.HandOverWarehouseId,

                        DestinationId =
                            request.DestinationId,

                        EstimatedAmount =
                            request.EstimatedAmount,

                        /*
                            ActualAmount should normally
                            be set after verification.
                        */
                        ActualAmount = 0,

                        ReceivedDate =
                            request.ReceivedDate,

                        ExpectedDeliverDate =
                            request.ExpectedDeliverDate,

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


                await _context.packageMaster
                    .AddAsync(
                        package
                    );


                await _context
                    .SaveChangesAsync();


                return (
                    true,
                    "Package created successfully.",
                    package.PackageId
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


        // =========================================
        // UPDATE PACKAGE
        // ONLY WHEN STATUS = RECEIVED
        // =========================================

        public async Task<
            (
                bool success,
                string message
            )>
            UpdatePackage(
                PackageRequestDto request
            )
        {
            try
            {
                /*
                    Get package including current status.

                    Important:
                    We check the CURRENT database status,
                    not request.StatusId.

                    Otherwise the frontend could simply
                    send a "Received" status and bypass
                    the rule.
                */

                var package =
                    await _context.packageMaster

                        .Include(
                            p => p.PackageStatus
                        )

                        .FirstOrDefaultAsync(
                            p =>
                                p.PackageId ==
                                    request.PackageId &&

                                p.IsActive
                        );


                if (package == null)
                {
                    return (
                        false,
                        "Package not found."
                    );
                }


                /*
                    Change StatusName to whatever your
                    PackageStatus property is actually
                    called.
                */

                if (
                    !string.Equals(
                        package.PackageStatus.StatusName,
                        "Received",
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                {
                    return (
                        false,
                        "Package cannot be updated because its status is not Received."
                    );
                }


                package.BoxTypeId =
                    request.BoxTypeId;

                package.BoxDimensionId =
                    request.BoxDimensionId;

                package.SenderId =
                    request.SenderId;

                package.RecipientId =
                    request.RecipientId;

                package.EstimatedWeight =
                    request.EstimatedWeight;

                package.HandOverWarehouseId =
                    request.HandOverWarehouseId;

                package.DestinationId =
                    request.DestinationId;

                package.EstimatedAmount =
                    request.EstimatedAmount;

                package.ReceivedDate =
                    request.ReceivedDate;

                package.ExpectedDeliverDate =
                    request.ExpectedDeliverDate;


                /*
                    I recommend NOT changing
                    StatusId from this general
                    update method.

                    Handle status changes in a separate
                    ChangePackageStatus() method.
                */


                package.UpdatedDate =
                    DateTime.UtcNow;

                package.UpdatedBy =
                    request.TrnUser;


                await _context
                    .SaveChangesAsync();


                return (
                    true,
                    "Package updated successfully."
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


        // =========================================
        // DEACTIVATE PACKAGE
        // =========================================

        public async Task<
            (
                bool success,
                string message
            )>
            DeactivatePackage(
                int packageId,
                string trnUser
            )
        {
            try
            {
                var package =
                    await _context.packageMaster

                        .FirstOrDefaultAsync(
                            p =>
                                p.PackageId ==
                                    packageId &&

                                p.IsActive
                        );


                if (package == null)
                {
                    return (
                        false,
                        "Package not found."
                    );
                }


                package.IsActive =
                    false;

                package.UpdatedDate =
                    DateTime.UtcNow;

                package.UpdatedBy =
                    trnUser;


                await _context
                    .SaveChangesAsync();


                return (
                    true,
                    "Package deactivated successfully."
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
    }
}