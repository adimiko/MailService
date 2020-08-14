using Microsoft.AspNetCore.Builder;

namespace Api.Framework
{
    public static class ExceptionExtensions
    {
        public static void UseErrorHandler(this IApplicationBuilder app)
            => app.UseMiddleware<ErrorHandlerMiddleware>();

    }
}