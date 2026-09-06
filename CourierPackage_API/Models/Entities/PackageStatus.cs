using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class PackageStatus
    {
        [Key]
        public int PackageStatusId { get; set; }
        [MaxLength(50)]
        public string StatusName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
