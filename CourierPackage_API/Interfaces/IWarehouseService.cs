using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IWarehouseService
    {
        Task<(IEnumerable<WarehouseResponseDto> warehouses, string message)>
        GetAllWarehouses();

        Task<(bool success, string message)>
            CreateWarehouse(WarehouseRequestDto request, LocationRequestDto locRequest);

        Task<(bool success, string message)>
            UpdateWarehouse(WarehouseRequestDto request, LocationRequestDto locRequest);

        Task<(bool success, string message)>
            DeactivateWarehouse(int warehouseId);
    }
}
