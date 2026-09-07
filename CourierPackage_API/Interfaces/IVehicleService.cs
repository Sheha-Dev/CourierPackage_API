using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IVehicleService
    {
        Task<(IEnumerable<VehicleResponseDto> vehicles, string message)> GetAllVehicles();
        Task<(bool success, string message)> CreateVehicle(VehicleRequestDto request);
        Task<(bool success, string message)> UpdateVehicle(VehicleRequestDto request);
        Task<(bool success, string message)> DeleteVehicle(int vehicleId);
    }
}
