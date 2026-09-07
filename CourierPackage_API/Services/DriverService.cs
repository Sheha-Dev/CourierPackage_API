using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class DriverService
    {
        private readonly IDriverRepository _DriverRepository;

        public DriverService(IDriverRepository DriverRepository)
        {
            _DriverRepository = DriverRepository;
        }

        public async Task<(IEnumerable<DriverResponseDto> drivers, string message)> GetAllDrivers()
        {
            return await _DriverRepository.GetAllDrivers();
        }
        public async Task<(bool success, string message)> CreateDriver(DriverRequestDto request)
        {
            return await _DriverRepository.CreateDriver(request);
        }
        public async Task<(bool success, string message)> UpdateDriver(DriverRequestDto request)
        {
            return await _DriverRepository.UpdateDriver(request);
        }
        public async Task<(bool success, string message)> DeleteDriver(int DriverId)
        {
            return await _DriverRepository.DeleteDriver(DriverId);
        }
    }
}
