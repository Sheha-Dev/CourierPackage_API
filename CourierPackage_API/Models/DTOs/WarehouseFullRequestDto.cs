namespace CourierPackage_API.Models.DTOs
{
    public class WarehouseFullRequestDto
    {
        public WarehouseRequestDto Warehouse { get; set; } = null!;
        public LocationRequestDto Location { get; set; } = null!;
    }
}
