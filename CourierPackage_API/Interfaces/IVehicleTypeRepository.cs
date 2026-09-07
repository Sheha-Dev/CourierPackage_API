using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IVehicleTypeRepository
    {
        Task<(IEnumerable<VehicleTypeResponseDto> VehicleTypes, string message)> GetAllVehicleTypes();
    }
}
