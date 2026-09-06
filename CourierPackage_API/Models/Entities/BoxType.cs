using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class BoxType
    {
        [Key]
        public int BoxTypeId { get; set; }
        [MaxLength(50)]
        public string BoxTypeName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // Navigation 
        public ICollection<PackageMaster> PackageMaster { get; set; } = null!;
    }
}
