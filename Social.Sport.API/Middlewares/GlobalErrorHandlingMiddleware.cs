using Social.Sport.API.Helper;
using System.Net;
using System.Text.Json;

namespace Social.Sport.API.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate requestDelegate, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new ErrorResult(ex.Message);
            var json = JsonSerializer.Serialize(errorDetails);

            await context.Response.WriteAsync(json);
        }
    }
}
