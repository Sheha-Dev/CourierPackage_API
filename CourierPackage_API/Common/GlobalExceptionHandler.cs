using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Common
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(
            ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(
                exception,
                "An exception occurred: {Message}",
                exception.Message);

            var problemDetails = new ProblemDetails();

            switch (exception)
            {
                case FileNotFoundException:
                    problemDetails.Status = StatusCodes.Status404NotFound;
                    problemDetails.Title = "Resource not found";
                    problemDetails.Detail = exception.Message;
                    break;

                case ArgumentException:
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "Invalid request";
                    problemDetails.Detail = exception.Message;
                    break;

                default:
                    problemDetails.Status =
                        StatusCodes.Status500InternalServerError;

                    problemDetails.Title = "Internal Server Error";

                    problemDetails.Detail = exception.Message;
                    break;
            }

            httpContext.Response.StatusCode =
                problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(
                problemDetails,
                cancellationToken);

            return true;
        }
    }
}
