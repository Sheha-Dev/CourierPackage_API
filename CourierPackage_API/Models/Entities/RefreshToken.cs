using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class RefreshToken
    {
        [Key]
        public int RefreshTokenId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime ExpireDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        // Navigation 
        public User User { get; set; } = null!;
    }
}
