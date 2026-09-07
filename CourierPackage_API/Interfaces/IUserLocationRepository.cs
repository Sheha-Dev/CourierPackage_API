using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IUserLocationRepository
    {
        Task<(IEnumerable<UserLocationResponseDto> userLocations, string message)> GetAllUserLocations();
        Task<(bool success, string message)> CreateUserLocation(UserLocationRequestDto request);
        Task<(bool success, string message)> UpdateUserLocation(UserLocationRequestDto request);
        Task<(bool success, string message)> DeleteUserLocation(int userLocationId);
    }
}
