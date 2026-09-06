using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class PackageRoute
    {
        [Key]
        public int PackageRouteId { get; set; }
        public int PackageId { get; set; }
        public int SourceWarehouseId { get; set; }
        public int DestinationWarehouseId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public DateTime ExpectedPickUpDate { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime ExpectedDeliverDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public bool Delivered { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys
        public PackageMaster PackageMaster { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
        public Warehouse SourceWarehouse { get; set; } = null!;
        public Warehouse DestinationWarehouse { get; set; } = null!;
        public DeliveryFeedback DeliveryFeedback { get; set; } = null!;
    }
}
