namespace CourierPackage_API.Models.DTOs
{
    public class DeliveryFeedbackRequestDto
    {
        public int DelveryFeedbackId { get; set; }
        public int PackageRouteId { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string TrnUser { get; set; } = string.Empty ;
    }
}
