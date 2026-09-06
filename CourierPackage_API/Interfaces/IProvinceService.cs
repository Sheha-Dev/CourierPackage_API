using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IProvinceService
    {
        Task<(IEnumerable<ProvinceResponseDto> provinces, string message)> GetAllProvinces();
    }
}
