namespace CourierPackage_API.Models.DTOs
{
    public class DriverRequestDto
    {
        public int DriverId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime VehicleExpDate { get; set; }
        public string TrnUser { get; set; } = string.Empty;
        public DateTime VerifiedDate { get; set; }
  
    }
}
