using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IPackageStatusRepository
    {
        Task<(IEnumerable<PackageStatusResponseDto> packageStatuses, string message)> GetAllPackageStatus();
    }
}
