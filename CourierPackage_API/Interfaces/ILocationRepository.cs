using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface ILocationRepository
    {
        Task<(IEnumerable<LocationResponseDto> locations, string message)> GetAllLocations();
        Task<(bool success, string message)> CreateLocation(LocationRequestDto request);
        Task<(bool success, string message)> UpdateLocation(LocationRequestDto request);
        Task<(bool success, string message)> DeleteLocation(int locationId);
    }
}
