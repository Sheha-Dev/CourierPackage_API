using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class DeliveryFeedbackRepository :IDeliveryFeedbackRepository
    {
        private readonly AppDbContext _dbContext;
        public DeliveryFeedbackRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<(IEnumerable<DeliveryFeedbackResponseDto> deliveryFeedbacks, string message)> GetAllDeliveryFeedbacks()
        {
            var list = await _dbContext.deliveryFeedback.ToListAsync();

            var result = new List<DeliveryFeedbackResponseDto>();

            foreach (DeliveryFeedback deliveryFeedback in list)
            {
                var deliveryFeedbackResponseDto = new DeliveryFeedbackResponseDto();

                deliveryFeedbackResponseDto.DelveryFeedbackId = deliveryFeedback.DeliveryFeedbackId;
                deliveryFeedbackResponseDto.Rate = deliveryFeedback.Rate;
                deliveryFeedbackResponseDto.Comment = deliveryFeedback.Comment;
                deliveryFeedbackResponseDto.IsActive = deliveryFeedback.IsActive;

                result.Add(deliveryFeedbackResponseDto);
            }

            return (result, "DeliveryFeedbacks retrieved successfully.");
        }

        public async Task<(bool success, string message)> CreateDeliveryFeedback(
           DeliveryFeedbackRequestDto request)
        {
            var deliveryFeedback = new DeliveryFeedback
            {
                DeliveryFeedbackId = request.DelveryFeedbackId,
                PackageRouteId = request.PackageRouteId,
                Rate = request.Rate,
                Comment = request.Comment,
                CreatedBy = request.TrnUser,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            await _dbContext.deliveryFeedback.AddAsync(deliveryFeedback);

            await _dbContext.SaveChangesAsync();

            return (true, "DeliveryFeedback created successfully.");
        }

        public async Task<(bool success, string message)> UpdateDeliveryFeedback(
            DeliveryFeedbackRequestDto request)
        {
            var deliveryFeedback = await _dbContext.deliveryFeedback
                .FirstOrDefaultAsync(x =>
                    x.DeliveryFeedbackId == request.DelveryFeedbackId);

            if (deliveryFeedback == null)
            {
                return (false, "DeliveryFeedback not found.");
            }

            deliveryFeedback.DeliveryFeedbackId =
                request.DelveryFeedbackId;

            deliveryFeedback.PackageRouteId =
                request.PackageRouteId;

            deliveryFeedback.Rate = request.Rate;
            deliveryFeedback.Comment = request.Comment;

            deliveryFeedback.UpdatedBy = request.TrnUser;
            deliveryFeedback.UpdatedDate = DateTime.Now;

            deliveryFeedback.IsActive =
                true;

            _dbContext.deliveryFeedback.Update(deliveryFeedback);

            await _dbContext.SaveChangesAsync();

            return (true, "DeliveryFeedback updated successfully.");
        }

        public async Task<(bool success, string message)> DeleteDeliveryFeedback(
            int DeliveryFeedbackId)
        {
            var deliveryFeedback = await _dbContext.deliveryFeedback
                .FirstOrDefaultAsync(x =>
                    x.DeliveryFeedbackId == DeliveryFeedbackId);

            if (deliveryFeedback == null)
            {
                return (false, "DeliveryFeedback not found.");
            }

            deliveryFeedback.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return (true, "DeliveryFeedback deleted successfully.");
        }
    }
}
