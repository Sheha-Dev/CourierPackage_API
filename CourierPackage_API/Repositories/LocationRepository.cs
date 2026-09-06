using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class LocationRepository: ILocationRepository
    {
        private readonly AppDbContext _dbContext;

        public LocationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IEnumerable<LocationResponseDto> locations, string message)> GetAllLocations()
        {
            var list = await _dbContext.locations.ToListAsync();

            var result = new List<LocationResponseDto>();

            foreach (Location location in list)
            {
                var locationResponseDto = new LocationResponseDto();

                locationResponseDto.LocationId = location.LocationId;
                locationResponseDto.LatitudeCoordinate = location.LatitudeCoordinate;
                locationResponseDto.LongitudeCoordinate = location.LogitudeCoordinate;
                locationResponseDto.IsActive = location.IsActive;

                result.Add(locationResponseDto);
            }

            return (result, "Locations retrieved successfully.");
        }

        public async Task<(bool success, string message)> CreateLocation(
           LocationRequestDto request)
        {
            var location = new Location
            {
                LatitudeCoordinate = request.LatitudeCoordinate,
                LogitudeCoordinate = request.LongitudeCoordinate,
                CreatedBy = request.TrnUser,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            await _dbContext.locations.AddAsync(location);

            await _dbContext.SaveChangesAsync();

            return (true, "Location created successfully.");
        }

        public async Task<(bool success, string message)> UpdateLocation(
            LocationRequestDto request)
        {
            var location = await _dbContext.locations
                .FirstOrDefaultAsync(x =>
                    x.LocationId == request.LocationId);

            if (location == null)
            {
                return (false, "Location not found.");
            }

            location.LatitudeCoordinate =
                request.LatitudeCoordinate;

            location.LogitudeCoordinate =
                request.LongitudeCoordinate;

            location.UpdatedBy = request.TrnUser;
            location.UpdatedDate = DateTime.Now;

            location.IsActive =
                true;

            _dbContext.locations.Update(location);

            await _dbContext.SaveChangesAsync();

            return (true, "Location updated successfully.");
        }

        public async Task<(bool success, string message)> DeleteLocation(
            int locationId)
        {
            var location = await _dbContext.locations
                .FirstOrDefaultAsync(x =>
                    x.LocationId == locationId);

            if (location == null)
            {
                return (false, "Location not found.");
            }

            location.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return (true, "Location deleted successfully.");
        }

    }
}
