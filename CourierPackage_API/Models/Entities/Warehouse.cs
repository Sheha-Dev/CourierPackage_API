using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }
        [MaxLength(50)]
        public string WarehouseName { get; set; } = string.Empty;
        public int WarehouseLocationId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        [MaxLength(50)]
        public string StreetName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys

        public Location Location { get; set; } = null!;
        public Province Province { get; set; } = null!;
        public District District { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
    }
}
