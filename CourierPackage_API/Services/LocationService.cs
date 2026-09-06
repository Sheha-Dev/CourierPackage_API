using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<(IEnumerable<LocationResponseDto> locations, string message)> GetAllLocations()
        {
            return await _locationRepository.GetAllLocations();
        }
        public async Task<(bool success, string message)> CreateLocation(LocationRequestDto request)
        {
            return await _locationRepository.CreateLocation(request);
        }
        public async Task<(bool success, string message)> UpdateLocation(LocationRequestDto request)
        {
            return await _locationRepository.UpdateLocation(request);
        }
        public async Task<(bool success, string message)> DeleteLocation(int locationId)
        {
            return await _locationRepository.DeleteLocation(locationId);
        }
    }
}
