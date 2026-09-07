using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class PackageRouteResponseDto
    {
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
        public bool IsActive { get; set; }
    }
}
