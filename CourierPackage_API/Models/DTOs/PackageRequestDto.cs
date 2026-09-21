using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class PackageRequestDto
    {
        public int PackageId { get; set; }
        public int PackageTrackingId { get; set; }
        public int BoxTypeId { get; set; }
        public BoxDimensionRequestDto boxDimensionRequestDto { get; set; } = null!;
        public string SenderId { get; set; } = string.Empty;
        public int RecipientId { get; set; }
        public decimal EstimatedWeight { get; set; }
        public bool IsVerified { get; set; }
        public int StatusId { get; set; }
        public int HandOverWarehouseId { get; set; }
        public int DestinationId { get; set; }
        public decimal EstimatedAmount { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ExpectedDeliverDate { get; set; }
        public LocationRequestDto Destination { get; set; }
        public string TrnUser { get; set; } = string.Empty;
    }
}
