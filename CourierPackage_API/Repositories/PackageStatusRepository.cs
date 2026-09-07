using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class PackageStatusRepository : IPackageStatusRepository
    {
        private readonly AppDbContext _dbContext;
        public PackageStatusRepository(AppDbContext appDbContext) 
        {
            _dbContext = appDbContext;
        }

        public async Task<(IEnumerable<PackageStatusResponseDto> packageStatuses, string message)> GetAllPackageStatus()
        {
            var list = await _dbContext.packageStatus.ToListAsync();

            var result = new List<PackageStatusResponseDto>();

            foreach (PackageStatus packageStatus in list)
            {
                var packageStatusDto = new PackageStatusResponseDto();

                packageStatusDto.packageStatusId = packageStatus.PackageStatusId;
                packageStatusDto.packageStatusName = packageStatus.StatusName;

                packageStatusDto.IsActive = packageStatus.IsActive;

                result.Add(packageStatusDto);
            }

            return (result, "packageStatus retrieved successfully.");
        }
    }
}
