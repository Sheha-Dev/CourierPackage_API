using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class PackageResponseDto
    {
        public int PackageId { get; set; }
        public int PackageTrackingId { get; set; }
        public int BoxTypeId { get; set; }
        public int BoxDimensionId { get; set; }
        public string SenderId { get; set; } = string.Empty;
        public int RecipientId { get; set; } 
        public decimal EstimatedWeight { get; set; }
        public bool IsVerified { get; set; }
        public int StatusId { get; set; }
        public int HandOverWarehouseId { get; set; }
        public int DestinationId { get; set; }
        public decimal EstimatedAmount { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ExpectedDeliverDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
