using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }
        [MaxLength(50)]
        public string ProvinceName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // navigation 
        public ICollection<Warehouse>? Warehouses { get; set; } = null!;
        public ICollection<UserLocation>? UserLocation { get; set; } = null!;
    }
}
