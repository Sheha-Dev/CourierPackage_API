namespace CourierPackage_API.Models.DTOs
{
    public class PackageStatusResponseDto
    {
        public int packageStatusId { get; set; }
        public string packageStatusName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string TrnUser { get; set; } = string.Empty;
    }
}
