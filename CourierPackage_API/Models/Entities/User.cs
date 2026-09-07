using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string NickName { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        // Navigation 
        public Driver Driver { get; set; } = null!;
        public ICollection<UserLocation> UserLocations { get; set; } = null!;
        public RefreshToken RefreshToken { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
    }
}
