using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class UserLocationService :IUserLocationService
    {
        private readonly IUserLocationRepository _userLocationRepository;

        public UserLocationService(IUserLocationRepository userLocationRepository)
        {
            _userLocationRepository = userLocationRepository;
        }

        public async Task<(IEnumerable<UserLocationResponseDto> userLocations, string message)> GetAllUserLocations()
        {
            return await _userLocationRepository.GetAllUserLocations();
        }
        public async Task<(bool success, string message)> CreateUserLocation(UserLocationRequestDto request)
        {
            return await _userLocationRepository.CreateUserLocation(request);
        }
        public async Task<(bool success, string message)> UpdateUserLocation(UserLocationRequestDto request)
        {
            return await _userLocationRepository.UpdateUserLocation(request);
        }
        public async Task<(bool success, string message)> DeleteUserLocation(int userLocationId)
        {
            return await _userLocationRepository.DeleteUserLocation(userLocationId);
        }
    }
}
