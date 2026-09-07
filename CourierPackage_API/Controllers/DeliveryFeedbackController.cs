using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryFeedbackController : ControllerBase
    {
        private readonly IDeliveryFeedbackService _DeliveryFeedbackService;

        public DeliveryFeedbackController(IDeliveryFeedbackService DeliveryFeedbackService)
        {
            _DeliveryFeedbackService = DeliveryFeedbackService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllDeliveryFeedbacks()
        {
            var result = await _DeliveryFeedbackService.GetAllDeliveryFeedbacks();

            return Ok(new { data = result.deliveryFeedbacks, message = result.message });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(
           [FromBody] DeliveryFeedbackRequestDto request)
        {
            var result =
                await _DeliveryFeedbackService.CreateDeliveryFeedback(request);

            return Ok(new
            {
                message = result.message
            });
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(
            [FromBody] DeliveryFeedbackRequestDto request)
        {
            var result =
                await _DeliveryFeedbackService.UpdateDeliveryFeedback(request);

            if (!result.success)
            {
                return NotFound(new
                {
                    message = result.message
                });
            }

            return Ok(new
            {
                message = result.message
            });
        }

        [HttpPatch]
        [Route("Deactivate")]
        public async Task<IActionResult> Deactivate(int DeliveryFeedbackId)
        {
            var result =
                await _DeliveryFeedbackService.DeleteDeliveryFeedback(DeliveryFeedbackId);

            if (!result.success)
            {
                return NotFound(new
                {
                    message = result.message
                });
            }

            return Ok(new
            {
                message = result.message
            });
        }
    }
}
