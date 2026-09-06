using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class BoxTypeRepository:IBoxTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public BoxTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IEnumerable<BoxTypeResponseDto> boxTypes, string message)> GetAllBoxTypes()
        {
            var list = await _dbContext.boxType.ToListAsync();

            var result = new List<BoxTypeResponseDto>();

            foreach (BoxType boxType in list)
            {
                var boxTypeDto = new BoxTypeResponseDto();

                boxTypeDto.BoxTypeId = boxType.BoxTypeId;
                boxTypeDto.BoxTypeName = boxType.BoxTypeName;
                boxTypeDto.IsActive = boxType.IsActive;

                result.Add(boxTypeDto);
            }

            return (result, "Box types retrieved successfully.");
        }
    }
}
