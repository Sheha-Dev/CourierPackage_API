namespace CourierPackage_API.Models.DTOs
{
    public class DriverResponseDto
    {
        public int DriverId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime VehicleExpDate { get; set; }
        public string VerifiedBy { get; set; } = string.Empty;
        public DateTime VerifiedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
