using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IPackageService
    {
        Task<List<PackageResponseDto>> GetAllPackages();

        Task<PackageResponseDto?> GetPackageByPackageId(
            int packageId
        );

        Task<List<PackageResponseDto>> GetPackageByDateRange(
            DateTime startDate,
            DateTime endDate
        );

        Task<(bool success, string message, int packageId)>
            CreatePackage(
                PackageRequestDto request
            );

        Task<(bool success, string message)>
            UpdatePackage(
                PackageRequestDto request
            );

        Task<(bool success, string message)>
            DeactivatePackage(
                int packageId,
                string trnUser
            );
    }
}
