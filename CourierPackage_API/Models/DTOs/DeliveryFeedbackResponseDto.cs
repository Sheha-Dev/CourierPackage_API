namespace CourierPackage_API.Models.DTOs
{
    public class DeliveryFeedbackResponseDto
    {
        public int DelveryFeedbackId { get; set; }
        public int PackageRouteId { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }
}
