using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class BoxDimension
    {
        [Key]
        public int BoxDimensionId { get; set; }
        [Precision(18,4)]
        public decimal Height { get; set; }
        [Precision(18, 4)]
        public decimal Width { get; set; }
        [Precision(18, 4)]
        public decimal Length { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // Navigation 
        public ICollection<PackageMaster> PackageMaster { get; set; } = null!;
    }
}
