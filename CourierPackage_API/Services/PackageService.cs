using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }
        public async Task<IEnumerable<PackageDto>> GetAllByUserIdAsync(
            string userId,
            CancellationToken cancellationToken)
        {
            return await _packageRepository.GetAllByUserIdAsync(userId, cancellationToken);
        }
    }
}
