using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IProvinceRepository
    {
        Task<(IEnumerable<ProvinceResponseDto> provinces, string message)> GetAllProvinces();
    }
}
