using System;
using System.Net;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Api.Framework
{
    public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
 
    public ErrorHandlerMiddleware(RequestDelegate next)
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
            await HandleExceptionAsync(httpContext, ex);
        }
    }
 
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var exceptionType = exception.GetType();
        var statusCode = HttpStatusCode.InternalServerError;

        switch(exception)
        {
            case Exception e when exceptionType == typeof(Exception):
                statusCode = HttpStatusCode.BadRequest;
                break;
        }

        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }
            .ToString());
    }
}
}