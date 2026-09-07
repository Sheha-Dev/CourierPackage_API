using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class UserLocationRequestDto
    {
        public int UserLocationId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        [MaxLength(50)]
        public string StreetName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;
        public string TrnUser { get; set; } = string.Empty;
    }
}
