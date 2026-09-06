using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IDistrictRepository
    {
        Task<(IEnumerable<DistrictResponseDto> districts, string message)> GetAllDistricts();
    }
}
