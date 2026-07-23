using System.Net;
using System.Text.Json;

namespace StudentManagementSystem.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Unhandled Exception occurred. Path: {Path}",context.Request.Path);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new ErrorResponse
                {
                    Success = false,
                    StatusCode = context.Response.StatusCode,
                    Message = "An unexpected error occurred.",
                    Details = ex.Message
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
            }
        }
    }

    public class ErrorResponse
    {
        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public string Details { get; set; } = string.Empty;
    }
}