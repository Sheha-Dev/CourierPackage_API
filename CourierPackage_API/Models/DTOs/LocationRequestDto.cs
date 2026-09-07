namespace CourierPackage_API.Models.DTOs
{
    public class LocationRequestDto
    {
        public int LocationId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string TrnUser { get; set; } = string.Empty;
    }
}
