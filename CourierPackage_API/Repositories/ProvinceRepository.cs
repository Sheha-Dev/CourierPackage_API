using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class ProvinceRepository: IProvinceRepository
    {
        private readonly AppDbContext _dbContext;

        public ProvinceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IEnumerable<ProvinceResponseDto> provinces, string message)> GetAllProvinces()
        {
            var list = await _dbContext.province.ToListAsync();

            var result = new List<ProvinceResponseDto>();

            foreach (Province province in list)
            {
                var provinceResponseDto = new ProvinceResponseDto();

                provinceResponseDto.ProvinceId = province.ProvinceId;
                provinceResponseDto.ProvinceName = province.ProvinceName;
                provinceResponseDto.IsActive = province.IsActive;

                result.Add(provinceResponseDto);
            }

            return (result, "Provinces retrieved successfully.");
        }
    }
}
