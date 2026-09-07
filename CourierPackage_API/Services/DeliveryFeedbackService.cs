using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;

namespace CourierPackage_API.Services
{
    public class DeliveryFeedbackService : IDeliveryFeedbackService
    {
        private readonly IDeliveryFeedbackRepository _deliveryFeedbackRepository;
        public DeliveryFeedbackService(IDeliveryFeedbackRepository deliveryFeedbackRepository)
        {
            _deliveryFeedbackRepository = deliveryFeedbackRepository;
        }

        public async Task<(IEnumerable<DeliveryFeedbackResponseDto> deliveryFeedbacks, string message)> GetAllDeliveryFeedbacks()
        {
            return await _deliveryFeedbackRepository.GetAllDeliveryFeedbacks();
        }
        public async Task<(bool success, string message)> CreateDeliveryFeedback(DeliveryFeedbackRequestDto request)
        {
            return await _deliveryFeedbackRepository.CreateDeliveryFeedback(request);
        }
        public async Task<(bool success, string message)> UpdateDeliveryFeedback(DeliveryFeedbackRequestDto request)
        {
            return await _deliveryFeedbackRepository.UpdateDeliveryFeedback(request);
        }
        public async Task<(bool success, string message)> DeleteDeliveryFeedback(int DeliveryFeedbackId)
        {
            return await _deliveryFeedbackRepository.DeleteDeliveryFeedback(DeliveryFeedbackId);
        }
    }
}
