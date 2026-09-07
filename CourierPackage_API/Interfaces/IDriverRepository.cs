using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IDriverRepository
    {
        Task<(IEnumerable<DriverResponseDto> drivers, string message)> GetAllDrivers();
        Task<(bool success, string message)> CreateDriver(DriverRequestDto request);
        Task<(bool success, string message)> UpdateDriver(DriverRequestDto request);
        Task<(bool success, string message)> DeleteDriver(int locationId);
    }
}
