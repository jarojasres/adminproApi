using AdminPro.Api.Configurations.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace AdminPro.Api.Configurations.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseNewUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NewUserMiddleware>();
        }
    }
}
