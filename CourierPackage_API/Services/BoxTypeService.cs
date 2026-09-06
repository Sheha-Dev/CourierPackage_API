using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Repositories;
using System.Runtime.CompilerServices;

namespace CourierPackage_API.Services
{
    public class BoxTypeService : IBoxTypeService
    {
        private readonly IBoxTypeRepository _boxTypeRepository;

        public BoxTypeService(IBoxTypeRepository boxTypeRepository)
        {
            _boxTypeRepository = boxTypeRepository;
        }

        public async Task<(IEnumerable<BoxTypeResponseDto> boxTypes, string message)> GetAllBoxTypes()
        {
            return await _boxTypeRepository.GetAllBoxTypes();
        }
    }
}
