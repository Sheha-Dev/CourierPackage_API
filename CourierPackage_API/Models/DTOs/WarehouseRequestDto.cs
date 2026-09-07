namespace CourierPackage_API.Models.DTOs
{
    public class WarehouseRequestDto
    {
        public int WarehouseId { get; set; }

        public string WarehouseName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty ;

        public string StreetName { get; set; } = string.Empty;

        public int ProvinceId { get; set; }

        public int DistrictId { get; set; }

        public int WarehouseLocationId { get; set; }
        public string TrnUser { get; set; } = string.Empty;
    }
}
