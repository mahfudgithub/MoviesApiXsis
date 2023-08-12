using Microsoft.AspNetCore.Builder;

namespace Movies21Xsis.Exceptions
{
    public static class ExceptionMiddlewareExtentions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionErrorHandling>();
        }
    }
}
