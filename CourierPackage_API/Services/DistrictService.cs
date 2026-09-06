using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictService(IDistrictRepository districtRepository) 
        {
            _districtRepository = districtRepository;
        }

        public async Task<(IEnumerable<DistrictResponseDto> districts, string message)> GetAllDistricts()
        {
            return await _districtRepository.GetAllDistricts();
        }
    }
}
