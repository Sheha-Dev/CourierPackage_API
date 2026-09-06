namespace CourierPackage_API.Models.DTOs
{
    public class PackageDto
    {
        public int PackageId { get; set; }

        public string? PackageTrackingId { get; set; }

        public int BoxTypeId { get; set; }

        public int BoxDimensionId { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public decimal EstimatedWeight { get; set; }

        public bool IsVerified { get; set; }

        public int StatusId { get; set; }

        public int? HandOverWarehouseId { get; set; }

        public int DestinationId { get; set; }

        public decimal EstimatedAmount { get; set; }

        public decimal? ActualAmount { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? ExpectedDeliverDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
