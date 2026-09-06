using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IBoxTypeRepository
    {
        Task<(IEnumerable<BoxTypeResponseDto> boxTypes, string message)> GetAllBoxTypes();
    }
}
