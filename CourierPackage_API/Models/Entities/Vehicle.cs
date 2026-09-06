using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public int VehicleTypeId { get; set; }
        public DateTime VehicleInsuranceExpireDate { get; set; }
        public DateTime VehicleLicenceExpireDate { get; set; }
        public DateTime VehicleExpirationDate { get; set; }
        public DateTime VerifiedDate { get; set; }
        [MaxLength(50)]
        public string verifiedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys
        public Driver Driver { get; set; } = null!;
        public VehicleType VehicleType { get; set; } = null!;
    }
}
