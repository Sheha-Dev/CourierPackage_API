using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class Recipient
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
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        // foreign keys
        public User Sender { get; set; } = null!;
    }
}
