using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class PackageMaster
    {
        [Key]
        public int PackageId { get; set; }
        public int PackageTrackingId { get; set; }
        public int BoxTypeId { get; set; }
        public int BoxDimensionId { get; set; }
        [MaxLength(450)]
        public string SenderId { get; set; } = string.Empty;
        [MaxLength(450)]
        public string RecipientId { get; set; } = string.Empty;
        [Precision(18,4)]
        public decimal EstimatedWeight { get; set; }
        public bool IsVerified { get; set; }
        public int StatusId { get; set; }
        public int HandOverWarehouseId { get; set; }
        public int DestinationId { get; set; }
        [Precision(18,4)]
        public decimal EstimatedAmount { get; set; }
        [Precision(18, 4)]
        public decimal ActualAmount { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ExpectedDeliverDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys

        public BoxType BoxType { get; set; } = null!;
        public BoxDimension BoxDimension { get; set; } = null!;
        public User Sender { get; set; } = null!;
        public User Recipient { get; set; } = null!;
        public PackageStatus PackageStatus { get; set; } = null!;
        public Warehouse SourceWarehouse { get; set; } = null!;
        public Warehouse DestinationWarehouse { get; set; } = null!;
        public ICollection<Notification> Notifications { get; set; } = null!;
        public PackageVerification PackageVerification { get; set; } = null!;


    }
}
