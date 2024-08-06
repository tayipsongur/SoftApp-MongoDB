using Microsoft.AspNetCore.Http;
using SoftApp.Exceptions.ErrorModels;
using System.Net;

namespace SoftApp.Exceptions.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleException(httpContext, ex);
            }
        }

        private static Task HandleException(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                Message = ex.Message,
                StatusCode = httpContext.Response.StatusCode
            }.ToString());

        }
    }
}
