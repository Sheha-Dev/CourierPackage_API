using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
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
    }
}
