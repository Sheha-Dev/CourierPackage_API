using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageDto>> GetAllByUserIdAsync(
            string userId,
            CancellationToken cancellationToken);
    }
}
