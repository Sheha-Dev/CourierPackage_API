using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class UserRegisterRequestDto
    {
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        [MaxLength(10)]
        public string Password { get; set; } = string.Empty;
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(50)]
        public string NickName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string RoleName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string TrnUser { get; set; } = string.Empty;
    }
}
