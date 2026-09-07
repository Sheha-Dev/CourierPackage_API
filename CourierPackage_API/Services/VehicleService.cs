using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class VehicleService:IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<(IEnumerable<VehicleResponseDto> vehicles, string message)> GetAllVehicles()
        {
            return await _vehicleRepository.GetAllVehicles();
        }
        public async Task<(bool success, string message)> CreateVehicle(VehicleRequestDto request)
        {
            return await _vehicleRepository.CreateVehicle(request);
        }
        public async Task<(bool success, string message)> UpdateVehicle(VehicleRequestDto request)
        {
            return await _vehicleRepository.UpdateVehicle(request);
        }
        public async Task<(bool success, string message)> DeleteVehicle(int vehicleId)
        {
            return await _vehicleRepository.DeleteVehicle(vehicleId);
        }
    }
}
