using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class PackageVerificationRequestDto
    {
        public int PackageVerificationId { get; set; }
        public int PackageId { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        [MaxLength(50)]
        public string VerifiedBy { get; set; } = string.Empty;
        public string TrnUser { get; set; } = string.Empty;
    }
}
