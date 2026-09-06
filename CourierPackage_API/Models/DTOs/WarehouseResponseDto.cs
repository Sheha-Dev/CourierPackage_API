using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class WarehouseResponseDto
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = string.Empty;
        public int WarehouseLocationId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
