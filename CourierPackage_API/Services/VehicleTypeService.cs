using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        public VehicleTypeService(IVehicleTypeRepository vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }
        public async Task<(IEnumerable<VehicleTypeResponseDto> VehicleTypes, string message)> GetAllVehicleTypes()
        {
            return await _vehicleTypeRepository.GetAllVehicleTypes();
        }
    }
}
