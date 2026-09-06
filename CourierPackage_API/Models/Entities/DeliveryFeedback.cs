using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class DeliveryFeedback
    {
        public int DeliveryFeedbackId { get; set; }
        public int PackageRouteId { get; set; }
        public int Rate { get; set; }
        [MaxLength(50)]
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys
        public PackageRoute PackageRoute { get; set; } = null!;
    }
}
