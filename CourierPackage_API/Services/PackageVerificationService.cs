using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class PackageVerificationService:IPackageVerificationService
    {
        private readonly IPackageVerificationRepository _packageVerificationRepository;

        public PackageVerificationService(IPackageVerificationRepository packageVerificationRepository)
        {
            _packageVerificationRepository = packageVerificationRepository;
        }

        public async Task<(IEnumerable<PackageVerificationResponseDto> packageVerifications, string message)> GetAllPackageVerifications()
        {
            return await _packageVerificationRepository.GetAllPackageVerifications();
        }
        public async Task<(bool success, string message)> CreatePackageVerification(PackageVerificationRequestDto request)
        {
            return await _packageVerificationRepository.CreatePackageVerification(request);
        }
        public async Task<(bool success, string message)> UpdatePackageVerification(PackageVerificationRequestDto request)
        {
            return await _packageVerificationRepository.UpdatePackageVerification(request);
        }
        public async Task<(bool success, string message)> DeletePackageVerification(int packageVerificationId)
        {
            return await _packageVerificationRepository.DeletePackageVerification(packageVerificationId);
        }
    }
}
