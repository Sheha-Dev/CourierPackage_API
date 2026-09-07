namespace CourierPackage_API.Models.DTOs
{
    public class VehicleTypeResponseDto
    {
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string TrnUser { get; set; } = string.Empty;
    }
}
