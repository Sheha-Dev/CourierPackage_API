using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class PackageVerification
    {
        [Key]
        public int PackageVerificationId { get; set; }
        public int PackageId { get; set; }
        [Precision(18, 4)]
        public decimal ActualWeight { get; set; }
        [Precision(18, 4)]
        public decimal Height { get; set; }
        [Precision(18, 4)]
        public decimal Width { get; set; }
        [Precision(18, 4)]
        public decimal Length { get; set; }
        public DateTime VerifiedDate { get; set; }
        [MaxLength(50)]
        public string VerifiedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys

        public PackageMaster Package { get; set; } = null!;
    }
}
