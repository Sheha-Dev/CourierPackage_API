namespace CourierPackage_API.Models.DTOs
{
    public class DistrictResponseDto
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public bool IsActive { get; set; }
    }
}
