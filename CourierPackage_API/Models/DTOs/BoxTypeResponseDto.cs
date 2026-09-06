using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class BoxTypeResponseDto
    {
        public int BoxTypeId { get; set; }
        public string BoxTypeName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
