using Atelier.Cats.Application.Models;
using Atelier.Cats.WebApi.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AtelierExceptionBase ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, AtelierExceptionBase exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.HttpStatusCode;
            var message = exception switch
            {
                BadRequestException => exception.Message,
                NotFoundException => exception.Message,
                ConflictException => exception.Message,
                _ => "Internal Server Error from the custom middleware."
            };

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
