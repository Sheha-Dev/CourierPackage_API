using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Models.DTOs
{
    public class BoxDimensionRequestDto
    {
        public int BoxDimensionId { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
    }
}
