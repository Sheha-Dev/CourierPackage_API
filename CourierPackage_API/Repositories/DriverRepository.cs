using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly AppDbContext _dbContext;

        public DriverRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IEnumerable<DriverResponseDto> drivers, string message)> GetAllDrivers()
        {
            var list = await _dbContext.driver.ToListAsync();

            var result = new List<DriverResponseDto>();

            foreach (Driver driver in list)
            {
                var driverResponseDto = new DriverResponseDto();

                driverResponseDto.DriverId = driver.DriverId;
                driverResponseDto.UserId = driver.UserId;
                driverResponseDto.VehicleExpDate = driver.VehicleExpirationDate;
                driverResponseDto.IsActive = driver.IsActive;

                result.Add(driverResponseDto);
            }

            return (result, "Drivers retrieved successfully.");
        }

        public async Task<(bool success, string message)> CreateDriver(
           DriverRequestDto request)
        {
            var Driver = new Driver
            {
                UserId = request.UserId,
                VehicleExpirationDate = request.VehicleExpDate,
                VerifiedBy = request.TrnUser,
                VerifiedDate = DateTime.Now,
                IsActive = true
            };

            await _dbContext.driver.AddAsync(Driver);

            await _dbContext.SaveChangesAsync();

            return (true, "Driver created successfully.");
        }

        public async Task<(bool success, string message)> UpdateDriver(
            DriverRequestDto request)
        {
            var Driver = await _dbContext.driver
                .FirstOrDefaultAsync(x =>
                    x.DriverId == request.DriverId);

            if (Driver == null)
            {
                return (false, "Driver not found.");
            }

            Driver.UserId =
                request.UserId;

            Driver.VehicleExpirationDate =
                request.VehicleExpDate;

            Driver.UpdatedBy = request.TrnUser;
            Driver.UpdatedDate = DateTime.Now;

            Driver.IsActive =
                true;

            _dbContext.driver.Update(Driver);

            await _dbContext.SaveChangesAsync();

            return (true, "Driver updated successfully.");
        }

        public async Task<(bool success, string message)> DeleteDriver(
            int DriverId)
        {
            var driver = await _dbContext.driver
                .FirstOrDefaultAsync(x =>
                    x.DriverId == DriverId);

            if (driver == null)
            {
                return (false, "Driver not found.");
            }

            driver.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return (true, "Driver deleted successfully.");
        }
    }
}
