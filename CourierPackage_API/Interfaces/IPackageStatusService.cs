using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IPackageStatusService
    {
        Task<(IEnumerable<PackageStatusResponseDto> packageStatuses, string message)> GetAllPackageStatus();
    }
}
