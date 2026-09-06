using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly AppDbContext _dbContext;

        public PackageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PackageDto>> GetAllByUserIdAsync(
            string userId,
            CancellationToken cancellationToken)
        {

            return null;
        }

        //public async Task<bool> AddPackage(
        //    string userId,
        //    CancellationToken cancellationToken)
        //{

        //    return null;
        //}
    }
}