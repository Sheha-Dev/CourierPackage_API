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
    }
}
