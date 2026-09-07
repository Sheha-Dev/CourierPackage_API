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
        public async Task<List<PackageResponseDto>> GetAllPackages()
        {
            return await _packageRepository.GetAllPackages();
        }

        public async Task<PackageResponseDto?> GetPackageByPackageId(
            int packageId
        )
        {
            return await _packageRepository.GetPackageByPackageId( packageId );
        }

        public async Task<List<PackageResponseDto>> GetPackageByDateRange(
            DateTime startDate,
            DateTime endDate
        )
        {
            return await _packageRepository.GetPackageByDateRange(startDate, endDate);
        }

        public async Task<(bool success, string message, int packageId)>
            CreatePackage(
                PackageRequestDto request
            )
        {
            return await _packageRepository.CreatePackage( request );
        }

        public async Task<(bool success, string message)>
            UpdatePackage(
                PackageRequestDto request
            )
        {
            return await _packageRepository.UpdatePackage( request );
        }

        public async Task<(bool success, string message)>
            DeactivatePackage(
                int packageId,
                string trnUser
            )
        {
            return await _packageRepository.DeactivatePackage(packageId, trnUser);
        }
    }
}
