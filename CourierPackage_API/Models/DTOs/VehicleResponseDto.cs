using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class VehicleResponseDto
    {
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public int VehicleTypeId { get; set; }
        public DateTime VehicleInsuranceExpireDate { get; set; }
        public DateTime VehicleLicenceExpireDate { get; set; }
        public DateTime VehicleExpirationDate { get; set; }
        public DateTime VerifiedDate { get; set; }
        [MaxLength(50)]
        public string VerifiedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
