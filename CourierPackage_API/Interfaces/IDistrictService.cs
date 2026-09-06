using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IDistrictService
    {
        Task<(IEnumerable<DistrictResponseDto> districts, string message)> GetAllDistricts();
    }
}
