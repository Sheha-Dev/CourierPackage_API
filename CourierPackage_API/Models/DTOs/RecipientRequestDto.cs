using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class RecipientRequestDto
    {
        public int RecipientId { get; set; }

        [MaxLength(450)]
        public string SenderId { get; set; } = string.Empty;
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string NickName { get; set; } = string.Empty;
        [MaxLength(20)]
        public string ContactNumber { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(50)]
        public string TrnUser { get; set; } = string.Empty ;
    }
}
