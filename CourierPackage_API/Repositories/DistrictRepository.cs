using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class DistrictRepository: IDistrictRepository
    {
        private readonly AppDbContext _dbContext;

        public DistrictRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IEnumerable<DistrictResponseDto> districts, string message)> GetAllDistricts()
        {
            var list = await _dbContext.district.ToListAsync();

            var result = new List<DistrictResponseDto>();

            foreach (District district in list)
            {
                var districtResponseDto = new DistrictResponseDto();

                districtResponseDto.DistrictId = district.DistrictId;
                districtResponseDto.DistrictName = district.DistrictName;
                districtResponseDto.IsActive = district.IsActive;
                districtResponseDto.ProvinceId = district.ProvinceId;
                result.Add(districtResponseDto);
            }

            return (result, "Districts retrieved successfully.");
        }
    }
}
