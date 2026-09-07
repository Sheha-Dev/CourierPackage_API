using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class VehicleTypeRepository: IVehicleTypeRepository
    {
        private readonly AppDbContext _dbContext;
        public VehicleTypeRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<(IEnumerable<VehicleTypeResponseDto> VehicleTypes, string message)> GetAllVehicleTypes()
        {
            var list = await _dbContext.vehicleType.ToListAsync();

            var result = new List<VehicleTypeResponseDto>();

            foreach (VehicleType vehicleType in list)
            {
                var vehicleTypeDto = new VehicleTypeResponseDto();

                vehicleTypeDto.VehicleTypeId = vehicleType.VehicleTypeId;
                vehicleTypeDto.VehicleTypeName = vehicleType.VehicleTypeName;

                vehicleTypeDto.IsActive = vehicleType.IsActive;

                result.Add(vehicleTypeDto);
            }

            return (result, "VehicleTypes retrieved successfully.");
        }
    }
}
