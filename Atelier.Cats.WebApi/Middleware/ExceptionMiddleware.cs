using Atelier.Cats.Application.Models;
using Atelier.Cats.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Middleware
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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AtelierExceptionBase ex)
            {
                await HandleCustomExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleCustomExceptionAsync(HttpContext context, AtelierExceptionBase exception)
        {
            _logger.LogError($"Logs ===> Message: { exception.Message }, Stack Trace: { exception.StackTrace }");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.HttpStatusCode;

            await context.Response.WriteAsync(new ExceptionDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
