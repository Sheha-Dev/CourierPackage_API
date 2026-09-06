using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; } = string.Empty;
        public int WarehouseId { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys
        public Warehouse Warehouse { get; set; } = null!;
        public User User { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
    }
}
