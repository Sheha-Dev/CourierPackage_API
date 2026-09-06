using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class VehicleType
    {
        [Key]
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
