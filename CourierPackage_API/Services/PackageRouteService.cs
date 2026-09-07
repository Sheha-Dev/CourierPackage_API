using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class PackageRouteService:IPackageRouteService
    {
        private readonly IPackageRouteRepository _packageRouteRepository;
        public PackageRouteService(IPackageRouteRepository packageRouteRepository)
        {
            _packageRouteRepository = packageRouteRepository;
        }

        public async Task<List<PackageRouteResponseDto>> GetAllPackageRoutes()
        {
            return await _packageRouteRepository.GetAllPackageRoutes();
        }

        public async Task<List<PackageRouteResponseDto>>
            GetPackageRoutesByPackageId(int packageId)
        {
            return await _packageRouteRepository.GetPackageRoutesByPackageId(packageId);
        }

        public async Task<List<PackageRouteResponseDto>>
            GetPackageRouteByDestinationWarehouseIdAndExpectedDeliverDate(
                int destinationWarehouseId,
                DateTime expectedDeliverDate
            )
        {
            return await _packageRouteRepository.GetPackageRouteByDestinationWarehouseIdAndExpectedDeliverDate(destinationWarehouseId, expectedDeliverDate);
        }

        public async Task<List<PackageRouteResponseDto>>
            GetDeliveredPackageRoutesByDestinationWarehouseId(
                int destinationWarehouseId
            )
        {
            return await _packageRouteRepository.GetDeliveredPackageRoutesByDestinationWarehouseId(destinationWarehouseId);
        }

        public async Task<(bool success, string message, int packageRouteId)>
            CreatePackageRoute(PackageRouteRequestDto request)
        {
            return await _packageRouteRepository.CreatePackageRoute(request);
        }

        public async Task<(bool success, string message)>
            UpdatePackageRoute(PackageRouteRequestDto request)
        {
            return await _packageRouteRepository.UpdatePackageRoute(request);
        }

        public async Task<(bool success, string message)>
            DeactivatePackageRoute(
                int packageRouteId,
                string trnUser
            )
        {
            return await _packageRouteRepository.DeactivatePackageRoute(packageRouteId, trnUser);
        }
    }
}
