namespace CourierPackage_API.Models.DTOs
{
    public class LocationRequestDto
    {
        public int LocationId { get; set; }
        public decimal LatitudeCoordinate { get; set; }
        public decimal LongitudeCoordinate { get; set; }
        public string TrnUser { get; set; }
    }
}
