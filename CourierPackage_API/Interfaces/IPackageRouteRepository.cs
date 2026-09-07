using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IPackageRouteRepository
    {
        Task<List<PackageRouteResponseDto>> GetAllPackageRoutes();

        Task<List<PackageRouteResponseDto>>
            GetPackageRoutesByPackageId(int packageId);

        Task<List<PackageRouteResponseDto>>
            GetPackageRouteByDestinationWarehouseIdAndExpectedDeliverDate(
                int destinationWarehouseId,
                DateTime expectedDeliverDate
            );

        Task<List<PackageRouteResponseDto>>
            GetDeliveredPackageRoutesByDestinationWarehouseId(
                int destinationWarehouseId
            );

        Task<(bool success, string message, int packageRouteId)>
            CreatePackageRoute(PackageRouteRequestDto request);

        Task<(bool success, string message)>
            UpdatePackageRoute(PackageRouteRequestDto request);

        Task<(bool success, string message)>
            DeactivatePackageRoute(
                int packageRouteId,
                string trnUser
            );
    }
}