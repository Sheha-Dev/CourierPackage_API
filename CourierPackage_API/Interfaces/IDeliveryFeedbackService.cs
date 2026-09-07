using CourierPackage_API.Models.DTOs;

namespace CourierPackage_API.Interfaces
{
    public interface IDeliveryFeedbackService
    {
        Task<(IEnumerable<DeliveryFeedbackResponseDto> deliveryFeedbacks, string message)> GetAllDeliveryFeedbacks();
        Task<(bool success, string message)> CreateDeliveryFeedback(DeliveryFeedbackRequestDto request);
        Task<(bool success, string message)> UpdateDeliveryFeedback(DeliveryFeedbackRequestDto request);
        Task<(bool success, string message)> DeleteDeliveryFeedback(int DeliveryFeedbackId);
    }
}
