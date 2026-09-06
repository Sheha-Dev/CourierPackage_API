using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _repository;
        public ProvinceService(IProvinceRepository repository)
        {
            _repository = repository;
        }

        public async Task<(IEnumerable<ProvinceResponseDto> provinces, string message)> GetAllProvinces()
        {
            return await _repository.GetAllProvinces();
        }

    }
}
