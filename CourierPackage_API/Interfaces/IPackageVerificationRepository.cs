using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IPackageVerificationRepository
    {
        Task<(IEnumerable<PackageVerificationResponseDto> packageVerifications, string message)> GetAllPackageVerifications();
        Task<(bool success, string message)> CreatePackageVerification(PackageVerificationRequestDto request);
        Task<(bool success, string message)> UpdatePackageVerification(PackageVerificationRequestDto request);
        Task<(bool success, string message)> DeletePackageVerification(int packageVerificationId);
    }
}
