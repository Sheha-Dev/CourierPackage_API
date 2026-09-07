using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IRecipientRepository
    {
        Task<(IEnumerable<RecipientResponseDto> recipients, string message)> GetAllRecipients();
        Task<(bool success, string message)> CreateRecipient(RecipientRequestDto request);
        Task<(bool success, string message)> UpdateRecipient(RecipientRequestDto request);
        Task<(bool success, string message)> DeleteRecipient(int recipientId);
    }
}
