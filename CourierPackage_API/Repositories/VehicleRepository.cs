using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class VehicleRepository:IVehicleRepository
    {
        private readonly AppDbContext _dbContext;

        public VehicleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IEnumerable<VehicleResponseDto> vehicles, string message)> GetAllVehicles()
        {
            var list = await _dbContext.vehicle.ToListAsync();

            var result = new List<VehicleResponseDto>();

            foreach (Vehicle Vehicle in list)
            {
                var VehicleResponseDto = new VehicleResponseDto();

                VehicleResponseDto.VehicleId = Vehicle.VehicleId;
                VehicleResponseDto.DriverId = Vehicle.DriverId;
                VehicleResponseDto.VehicleTypeId = Vehicle.VehicleTypeId; 
                VehicleResponseDto.VehicleInsuranceExpireDate = Vehicle.VehicleInsuranceExpireDate;
                VehicleResponseDto.VehicleLicenceExpireDate = Vehicle.VehicleLicenceExpireDate;
                VehicleResponseDto.VerifiedBy = Vehicle.verifiedBy;
                VehicleResponseDto.VerifiedDate = DateTime.Now;
                VehicleResponseDto.IsActive = Vehicle.IsActive;

                result.Add(VehicleResponseDto);
            }

            return (result, "Vehicles retrieved successfully.");
        }

        public async Task<(bool success, string message)> CreateVehicle(
           VehicleRequestDto request)
        {
            var Vehicle = new Vehicle
            {
                VehicleId = request.VehicleId,
                DriverId = request.DriverId,
                VehicleTypeId = request.VehicleTypeId,
                VehicleInsuranceExpireDate = request.VehicleInsuranceExpireDate,
                VehicleLicenceExpireDate = request.VehicleLicenceExpireDate,
                verifiedBy = request.TrnUser,
                VerifiedDate = DateTime.Now,
                IsActive = true
            };

            await _dbContext.vehicle.AddAsync(Vehicle);

            await _dbContext.SaveChangesAsync();

            return (true, "Vehicle created successfully.");
        }

        public async Task<(bool success, string message)> UpdateVehicle(
            VehicleRequestDto request)
        {
            var Vehicle = await _dbContext.vehicle
                .FirstOrDefaultAsync(x =>
                    x.VehicleId == request.VehicleId);

            if (Vehicle == null)
            {
                return (false, "Vehicle not found.");
            }

            Vehicle.DriverId =
                request.DriverId;

            Vehicle.VehicleTypeId =
                request.VehicleTypeId;

            Vehicle.VehicleInsuranceExpireDate =
                request.VehicleInsuranceExpireDate;

            Vehicle.VehicleLicenceExpireDate =
                request.VehicleLicenceExpireDate;
            

            Vehicle.UpdatedBy = request.TrnUser;
            Vehicle.UpdatedDate = DateTime.Now;

            Vehicle.IsActive =
                true;

            _dbContext.vehicle.Update(Vehicle);

            await _dbContext.SaveChangesAsync();

            return (true, "Vehicle updated successfully.");
        }

        public async Task<(bool success, string message)> DeleteVehicle(
            int VehicleId)
        {
            var Vehicle = await _dbContext.vehicle
                .FirstOrDefaultAsync(x =>
                    x.VehicleId == VehicleId);

            if (Vehicle == null)
            {
                return (false, "Vehicle not found.");
            }

            Vehicle.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return (true, "Vehicle deleted successfully.");
        }

    }
}
