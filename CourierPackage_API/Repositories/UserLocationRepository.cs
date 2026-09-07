using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class UserLocationRepository:IUserLocationRepository
    {
        private readonly AppDbContext _dbContext;

        public UserLocationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IEnumerable<UserLocationResponseDto> userLocations, string message)> GetAllUserLocations()
        {
            var list = await _dbContext.userLocation.ToListAsync();

            var result = new List<UserLocationResponseDto>();

            foreach (UserLocation userLocation in list)
            {
                var userLocationResponseDto = new UserLocationResponseDto();

                userLocationResponseDto.UserLocationId = userLocation.UserLocationId;
                userLocationResponseDto.UserId = userLocation.UserId;
                userLocationResponseDto.LocationId = userLocation.LocationId;
                userLocationResponseDto.ProvinceId = userLocation.ProvinceId;
                userLocationResponseDto.DistrictId = userLocation.DistrictId;
                userLocationResponseDto.StreetName = userLocation.StreetName;
                userLocationResponseDto.Address = userLocation.Address;
                userLocationResponseDto.IsActive = userLocation.IsActive;

                result.Add(userLocationResponseDto);
            }

            return (result, "UserLocations retrieved successfully.");
        }

        public async Task<(bool success, string message)> CreateUserLocation(
           UserLocationRequestDto request)
        {
            var userLocation = new UserLocation
            {
                UserId = request.UserId,
                LocationId = request.LocationId,
                ProvinceId = request.ProvinceId,
                DistrictId = request.DistrictId,
                StreetName = request.StreetName,
                Address = request.Address,
                CreatedBy = request.TrnUser,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            await _dbContext.userLocation.AddAsync(userLocation);

            await _dbContext.SaveChangesAsync();

            return (true, "UserLocation created successfully.");
        }

        public async Task<(bool success, string message)> UpdateUserLocation(
            UserLocationRequestDto request)
        {
            var userLocation = await _dbContext.userLocation
                .FirstOrDefaultAsync(x =>
                    x.UserLocationId == request.UserLocationId);

            if (userLocation == null)
            {
                return (false, "UserLocation not found.");
            }

            userLocation.UserId =
                request.UserId;

            userLocation.LocationId =
                request.LocationId;
            userLocation.ProvinceId =
                request.ProvinceId;

            userLocation.DistrictId =
                request.DistrictId;
            userLocation.StreetName =
                request.StreetName;

            userLocation.Address =
                request.Address;

            userLocation.UpdatedBy = request.TrnUser;
            userLocation.UpdatedDate = DateTime.Now;

            userLocation.IsActive =
                true;

            _dbContext.userLocation.Update(userLocation);

            await _dbContext.SaveChangesAsync();

            return (true, "UserLocation updated successfully.");
        }

        public async Task<(bool success, string message)> DeleteUserLocation(
            int userLocationId)
        {
            var userLocation = await _dbContext.userLocation
                .FirstOrDefaultAsync(x =>
                    x.UserLocationId == userLocationId);

            if (userLocation == null)
            {
                return (false, "UserLocation not found.");
            }

            userLocation.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return (true, "UserLocation deleted successfully.");
        }
    }
}
