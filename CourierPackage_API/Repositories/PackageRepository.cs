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

                                BoxHeight = 
                                    p.BoxDimension.Height,

                                BoxLength = 
                                    p.BoxDimension.Length,

                                BoxWidth = 
                                    p.BoxDimension.Width,

                                SenderId =
                                    p.SenderId,

                                RecipientId =
                                    p.RecipientId ?? 0,

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
                                    p.RecipientId ?? 0,

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
                                    p.RecipientId ?? 0,

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

        public async Task<(bool success, string message, int packageId)>
    CreatePackage(PackageRequestDto request)
        {
            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                int boxDiId;

                var dimension = await _context.boxDimensions
                    .FirstOrDefaultAsync(di =>
                        di.Length == request.boxDimensionRequestDto.Length &&
                        di.Width == request.boxDimensionRequestDto.Width &&
                        di.Height == request.boxDimensionRequestDto.Height);

                if (dimension != null)
                {
                    boxDiId = dimension.BoxDimensionId;
                }
                else
                {
                    var boxDi = new BoxDimension
                    {
                        Length = request.boxDimensionRequestDto.Length,
                        Width = request.boxDimensionRequestDto.Width,
                        Height = request.boxDimensionRequestDto.Height,
                        CreatedBy = request.TrnUser,
                        CreatedDate = DateTime.UtcNow
                    };

                    await _context.boxDimensions.AddAsync(boxDi);

                    // Required to generate BoxDimensionId
                    await _context.SaveChangesAsync();

                    boxDiId = boxDi.BoxDimensionId;
                }

                // get status id 

                var status = await _context.packageStatus.FirstOrDefaultAsync( x => x.StatusName == "Initial");

                // set destination location and get destination location id 

                int desId;

                var destination = await _context.locations
                    .FirstOrDefaultAsync(l =>
                        l.LatitudeCoordinate == request.Destination.Latitude &&
                        l.LogitudeCoordinate == request.Destination.Longitude );

                if (destination != null)
                {
                    desId = destination.LocationId;
                }
                else
                {
                    var location = new Location
                    {
                        LatitudeCoordinate = request.Destination.Latitude,
                        LogitudeCoordinate = request.Destination.Longitude,
                        CreatedBy = request.TrnUser,
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true,
                    };

                    await _context.locations.AddAsync(location);

                    // Required to generate BoxDimensionId
                    await _context.SaveChangesAsync();

                    desId = location.LocationId;
                }

                var now = DateTime.UtcNow;

                var package = new PackageMaster
                {
                    PackageTrackingId = "0",
                    BoxTypeId = request.BoxTypeId,
                    BoxDimensionId = boxDiId,
                    SenderId = request.SenderId,
                    RecipientId = request.RecipientId,
                    EstimatedWeight = request.EstimatedWeight,
                    IsVerified = request.IsVerified,
                    StatusId = status.PackageStatusId,
                    HandOverWarehouseId = request.HandOverWarehouseId,
                    DestinationId = desId,
                    EstimatedAmount = request.EstimatedAmount,
                    ActualAmount = 0,
                    ReceivedDate = request.ReceivedDate,
                    ExpectedDeliverDate = request.ExpectedDeliverDate,

                    CreatedDate = now,
                    CreatedBy = request.TrnUser,
                    UpdatedDate = now,
                    UpdatedBy = request.TrnUser,
                    IsActive = true
                };

                await _context.packageMaster.AddAsync(package);

                await _context.SaveChangesAsync();

                //var package = await _context.packageMaster.FirstOrDefaultAsync(x => x.PackageId == package.PackageId);

                package.PackageTrackingId = "00000"+package.PackageId;

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return (
                    true,
                    "Package created successfully.",
                    package.PackageId
                );
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return (
                    false,
                    ex.Message,
                    0
                );
            }
        }


        // =========================================
        // UPDATE PACKAGE
        // ONLY WHEN STATUS = INITIAL
        // =========================================

        public async Task<(bool success, string message)>
            UpdatePackage(PackageRequestDto request)
        {
            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                // =========================================
                // GET PACKAGE
                // =========================================

                var package =
                    await _context.packageMaster
                        .Include(p => p.PackageStatus)
                        .FirstOrDefaultAsync(p =>
                            p.PackageId == request.PackageId &&
                            p.IsActive);

                if (package == null)
                {
                    return (
                        false,
                        "Package not found."
                    );
                }


                // =========================================
                // CHECK PACKAGE STATUS
                // ONLY INITIAL CAN BE UPDATED
                // =========================================

                if (!string.Equals(
                        package.PackageStatus.StatusName,
                        "Initial",
                        StringComparison.OrdinalIgnoreCase))
                {
                    return (
                        false,
                        "Package cannot be updated because its status is not Initial."
                    );
                }


                // =========================================
                // GET / CREATE BOX DIMENSION
                // =========================================

                int boxDiId;

                var dimension =
                    await _context.boxDimensions
                        .FirstOrDefaultAsync(di =>
                            di.Length ==
                                request.boxDimensionRequestDto.Length &&

                            di.Width ==
                                request.boxDimensionRequestDto.Width &&

                            di.Height ==
                                request.boxDimensionRequestDto.Height
                        );

                if (dimension != null)
                {
                    // Existing dimension
                    boxDiId =
                        dimension.BoxDimensionId;
                }
                else
                {
                    // Create new dimension
                    var boxDi =
                        new BoxDimension
                        {
                            Length =
                                request.boxDimensionRequestDto.Length,

                            Width =
                                request.boxDimensionRequestDto.Width,

                            Height =
                                request.boxDimensionRequestDto.Height,

                            CreatedBy =
                                request.TrnUser,

                            CreatedDate =
                                DateTime.UtcNow
                        };

                    await _context.boxDimensions
                        .AddAsync(boxDi);

                    // Generate BoxDimensionId
                    await _context.SaveChangesAsync();

                    boxDiId =
                        boxDi.BoxDimensionId;
                }


                // =========================================
                // GET / CREATE DESTINATION LOCATION
                // =========================================

                int desId;

                var destination =
                    await _context.locations
                        .FirstOrDefaultAsync(l =>
                            l.LatitudeCoordinate ==
                                request.Destination.Latitude &&

                            l.LogitudeCoordinate ==
                                request.Destination.Longitude
                        );

                if (destination != null)
                {
                    // Existing destination
                    desId =
                        destination.LocationId;
                }
                else
                {
                    // Create new destination
                    var location =
                        new Location
                        {
                            LatitudeCoordinate =
                                request.Destination.Latitude,

                            LogitudeCoordinate =
                                request.Destination.Longitude,

                            CreatedBy =
                                request.TrnUser,

                            CreatedDate =
                                DateTime.UtcNow,

                            IsActive = true
                        };

                    await _context.locations
                        .AddAsync(location);

                    // Generate LocationId
                    await _context.SaveChangesAsync();

                    desId =
                        location.LocationId;
                }


                // =========================================
                // UPDATE PACKAGE
                // =========================================

                package.BoxTypeId =
                    request.BoxTypeId;

                package.BoxDimensionId =
                    boxDiId;

                package.SenderId =
                    request.SenderId;

                package.RecipientId =
                    request.RecipientId;

                package.EstimatedWeight =
                    request.EstimatedWeight;

                package.HandOverWarehouseId =
                    request.HandOverWarehouseId;

                package.DestinationId =
                    desId;

                package.EstimatedAmount =
                    request.EstimatedAmount;

                package.ReceivedDate =
                    request.ReceivedDate;

                package.ExpectedDeliverDate =
                    request.ExpectedDeliverDate;

                package.UpdatedDate =
                    DateTime.UtcNow;

                package.UpdatedBy =
                    request.TrnUser;


                // =========================================
                // SAVE
                // =========================================

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return (
                    true,
                    "Package updated successfully."
                );
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

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