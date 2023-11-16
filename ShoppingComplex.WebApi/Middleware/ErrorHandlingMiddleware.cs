using Newtonsoft.Json;
using ShoppingComplex.Domain.DTOs;
using System.Text;

namespace ShoppingComplex.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }

        private static void HandleException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var errorDto = new ErrorDto
            {
                Code = 500, 
                Message = ex.Message 
            };

            var result = JsonConvert.SerializeObject(errorDto);
            context.Response.WriteAsync(result, Encoding.UTF8);
        }
    }
}
