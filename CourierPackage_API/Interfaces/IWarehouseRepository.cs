using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<(IEnumerable<WarehouseResponseDto> warehouses, string message)> GetAllWarehouses();
    }
}
