using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.Entities
{
    public class Recipient
    {
        [Key]
        public int RecipientId { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; } = string.Empty;
        [MaxLength(450)]
        public string SenderId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // foreign keys
        public User Sender { get; set; } = null!;
        public User Receiver { get; set; } = null!;
    }
}
