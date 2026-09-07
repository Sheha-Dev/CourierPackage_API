using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; } = string.Empty;
        public DateTime VehicleExpirationDate { get; set; }
        public DateTime VerifiedDate { get; set; }
        [MaxLength(50)]
        public string VerifiedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys
        public User User { get; set; } = null!;
    }
}
