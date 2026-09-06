using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IBoxTypeService
    {
        Task<(IEnumerable<BoxTypeResponseDto> boxTypes, string message)> GetAllBoxTypes();
    }
}
