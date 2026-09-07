using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Services
{
    public class RecipientService:IRecipientService
    {
        private readonly IRecipientRepository _recipientRepository;

        public RecipientService(IRecipientRepository recipientRepository)
        {
            _recipientRepository = recipientRepository;
        }

        public async Task<(IEnumerable<RecipientResponseDto> recipients, string message)> GetAllRecipients()
        {
            return await _recipientRepository.GetAllRecipients();
        }
        public async Task<(bool success, string message)> CreateRecipient(RecipientRequestDto request)
        {
            return await _recipientRepository.CreateRecipient(request);
        }
        public async Task<(bool success, string message)> UpdateRecipient(RecipientRequestDto request)
        {
            return await _recipientRepository.UpdateRecipient(request);
        }
        public async Task<(bool success, string message)> DeleteRecipient(int recipientId)
        {
            return await _recipientRepository.DeleteRecipient(recipientId);
        }
    }
}
