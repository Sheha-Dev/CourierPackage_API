using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Precision(18,4)]
        public decimal LatitudeCoordinate { get; set; }
        [Precision(18, 4)]
        public decimal LogitudeCoordinate { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
