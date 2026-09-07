using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class PackageVerificationRepository:IPackageVerificationRepository
    {
        private readonly AppDbContext _dbContext;

        public PackageVerificationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IEnumerable<PackageVerificationResponseDto> packageVerifications, string message)> GetAllPackageVerifications()
        {
            var list = await _dbContext.packageVerification.ToListAsync();

            var result = new List<PackageVerificationResponseDto>();

            foreach (PackageVerification packageVerification in list)
            {
                var packageVerificationResponseDto = new PackageVerificationResponseDto();

                packageVerificationResponseDto.PackageVerificationId = packageVerification.PackageVerificationId;
                packageVerificationResponseDto.ActualWeight = packageVerification.ActualWeight;
                packageVerificationResponseDto.Height = packageVerification.Height;
                packageVerificationResponseDto.Width = packageVerification.Width;
                packageVerificationResponseDto.Length = packageVerification.Length;
                packageVerificationResponseDto.VerifiedBy = packageVerification.VerifiedBy;
                packageVerificationResponseDto.VerifiedDate = packageVerification.VerifiedDate;
                packageVerificationResponseDto.IsActive = packageVerification.IsActive;

                result.Add(packageVerificationResponseDto);
            }

            return (result, "PackageVerifications retrieved successfully.");
        }

        public async Task<(bool success, string message)> CreatePackageVerification(
           PackageVerificationRequestDto request)
        {
            var packageVerification = new PackageVerification
            {
                ActualWeight = request.ActualWeight,
                Height = request.Height,
                Width = request.Width,
                Length = request.Length,
                VerifiedBy = request.TrnUser,
                VerifiedDate = DateTime.Now,
                IsActive = true
            };

            await _dbContext.packageVerification.AddAsync(packageVerification);

            await _dbContext.SaveChangesAsync();

            return (true, "PackageVerification created successfully.");
        }

        public async Task<(bool success, string message)> UpdatePackageVerification(
            PackageVerificationRequestDto request)
        {
            var packageVerification = await _dbContext.packageVerification
                .FirstOrDefaultAsync(x =>
                    x.PackageVerificationId == request.PackageVerificationId);

            if (packageVerification == null)
            {
                return (false, "PackageVerification not found.");
            }

            packageVerification.ActualWeight =
                request.ActualWeight;

            packageVerification.Height =
                request.Height;
            packageVerification.Width =
                request.Width;

            packageVerification.Length =
                request.Length;


            packageVerification.VerifiedBy = request.TrnUser;
            packageVerification.VerifiedDate = DateTime.Now;

            packageVerification.IsActive =
                true;

            _dbContext.packageVerification.Update(packageVerification);

            await _dbContext.SaveChangesAsync();

            return (true, "PackageVerification updated successfully.");
        }

        public async Task<(bool success, string message)> DeletePackageVerification(
            int packageVerificationId)
        {
            var packageVerification = await _dbContext.packageVerification
                .FirstOrDefaultAsync(x =>
                    x.PackageVerificationId == packageVerificationId);

            if (packageVerification == null)
            {
                return (false, "PackageVerification not found.");
            }

            packageVerification.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return (true, "PackageVerification deleted successfully.");
        }

    }
}
