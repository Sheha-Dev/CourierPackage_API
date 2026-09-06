namespace CourierPackage_API.Models.DTOs
{
    public class LocationResponseDto
    {
        public int LocationId { get; set; }
        public decimal LatitudeCoordinate { get; set; }
        public decimal LongitudeCoordinate { get; set; }
        public bool IsActive { get; set; }
    }
}
