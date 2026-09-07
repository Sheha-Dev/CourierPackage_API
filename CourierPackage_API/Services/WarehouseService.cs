using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class WarehouseService:IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseService(IWarehouseRepository warehouseRepository) 
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<(IEnumerable<WarehouseResponseDto> warehouses, string message)> GetAllWarehouses()
        {
            return await _warehouseRepository.GetAllWarehouses();
        }
        

        public async Task<(bool success, string message)>CreateWarehouse(WarehouseRequestDto request, LocationRequestDto locRequest)
        {
            return await _warehouseRepository.CreateWarehouse(request, locRequest);
        }

        public async Task<(bool success, string message)>UpdateWarehouse(WarehouseRequestDto request, LocationRequestDto locRequest)
        {
            return await _warehouseRepository.UpdateWarehouse(request, locRequest);
        }

        public async Task<(bool success, string message)>DeactivateWarehouse(int warehouseId)
        {
            return await _warehouseRepository.DeactivateWarehouse(warehouseId);
        }
    }
}
