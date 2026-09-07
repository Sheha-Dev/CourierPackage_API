using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class PackageStatusService:IPackageStatusService
    {
        private readonly IPackageStatusRepository _packageStatusRepository;
        public PackageStatusService(IPackageStatusRepository packageStatusRepository) 
        {
            _packageStatusRepository = packageStatusRepository;
        }

        public async Task<(IEnumerable<PackageStatusResponseDto> packageStatuses, string message)> GetAllPackageStatus()
        {
            return await _packageStatusRepository.GetAllPackageStatus();
        }
    }

}
