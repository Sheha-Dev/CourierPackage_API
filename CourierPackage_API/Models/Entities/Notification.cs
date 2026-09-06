using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public int PackageId { get; set; }
        [MaxLength(500)]
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys

        public PackageMaster Package { get; set; } = null!;
    }
}
