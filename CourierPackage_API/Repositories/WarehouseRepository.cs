using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class WarehouseRepository:IWarehouseRepository
    {
        private readonly AppDbContext _dbContext;

        public WarehouseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IEnumerable<WarehouseResponseDto> warehouses, string message)> GetAllWarehouses()
        {
            var list = await _dbContext.warehouses.ToListAsync();

            var result = new List<WarehouseResponseDto>();

            foreach (Warehouse warehouse in list)
            {
                var warehouseResponseDto = new WarehouseResponseDto();

                warehouseResponseDto.WarehouseId = warehouse.WarehouseId;
                warehouseResponseDto.WarehouseName = warehouse.WarehouseName;
                warehouseResponseDto.Address = warehouse.Address;
                warehouseResponseDto.StreetName = warehouse.StreetName;
                warehouseResponseDto.ProvinceId = warehouse.ProvinceId;
                warehouseResponseDto.DistrictId = warehouse.DistrictId;
                warehouseResponseDto.WarehouseLocationId = warehouse.WarehouseLocationId;
                warehouseResponseDto.IsActive = warehouse.IsActive;

                result.Add(warehouseResponseDto);
            }

            return (result, "Warehouse retrieved successfully.");
        }

        public async Task<(bool success, string message)> CreateWarehouse(
            WarehouseRequestDto request, LocationRequestDto locRequest)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                

                var location = new Location
                {
                    LatitudeCoordinate = locRequest.Latitude,
                    LogitudeCoordinate = locRequest.Longitude,
                    CreatedBy = locRequest.TrnUser,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                };

                _dbContext.locations.Add(location);

                await _dbContext.SaveChangesAsync();

                var warehouse = new Warehouse
                {
                    WarehouseName = request.WarehouseName,
                    Address = request.Address,
                    StreetName = request.StreetName,
                    ProvinceId = request.ProvinceId,
                    DistrictId = request.DistrictId,
                    WarehouseLocationId = location.LocationId,
                    CreatedBy = request.TrnUser,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.warehouses.AddAsync(warehouse);

                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return (true, "Warehouse created successfully.");

            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task<(bool success, string message)> UpdateWarehouse(
            WarehouseRequestDto request, LocationRequestDto locRequest)
        {

            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var location = await _dbContext.locations
                .FirstOrDefaultAsync(x =>
                    x.LocationId == locRequest.LocationId);

                if (location == null)
                {
                    return (false, "Location not found.");
                }

                location.LatitudeCoordinate =
                    locRequest.Latitude;

                location.LogitudeCoordinate =
                    locRequest.Longitude;

                location.UpdatedBy = locRequest.TrnUser;
                location.UpdatedDate = DateTime.Now;

                location.IsActive =
                    true;

                _dbContext.locations.Update(location);
                var warehouse = await _dbContext.warehouses
                .FirstOrDefaultAsync(x =>
                    x.WarehouseId == request.WarehouseId);

            if (warehouse == null)
            {
                return (false, "Warehouse not found.");
            }

            warehouse.WarehouseName = request.WarehouseName;
            warehouse.Address = request.Address;
            warehouse.StreetName = request.StreetName;
            warehouse.ProvinceId = request.ProvinceId;
            warehouse.DistrictId = request.DistrictId;
            warehouse.WarehouseLocationId = request.WarehouseLocationId;
            warehouse.UpdatedBy = request.TrnUser;
            warehouse.UpdatedDate = DateTime.Now;

            await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return (true, "Warehouse updated successfully.");
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<(bool success, string message)> DeactivateWarehouse(
            int warehouseId)
        {
            var warehouse = await _dbContext.warehouses
                .FirstOrDefaultAsync(x =>
                    x.WarehouseId == warehouseId);

            if (warehouse == null)
            {
                return (false, "Warehouse not found.");
            }

            warehouse.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return (true, "Warehouse deactivated successfully.");
        }
    }
}
