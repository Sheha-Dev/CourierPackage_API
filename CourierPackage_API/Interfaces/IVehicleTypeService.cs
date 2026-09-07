using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IVehicleTypeService
    {
        Task<(IEnumerable<VehicleTypeResponseDto> VehicleTypes, string message)> GetAllVehicleTypes();
    }
}
