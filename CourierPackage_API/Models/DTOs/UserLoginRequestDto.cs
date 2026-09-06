using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class UserLoginRequestDto
    {
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
    }
}
