using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        public int ProvinceId { get; set; }
        [MaxLength(50)]
        public string DistrictName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys
        public Province Province { get; set; } = null!;
        public ICollection<UserLocation>? UserLocations { get; set; } = null!;
    }
}
