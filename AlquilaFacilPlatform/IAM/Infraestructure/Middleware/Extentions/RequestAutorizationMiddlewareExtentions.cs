using AlquilaFacilPlatform.IAM.Infraestructure.Middleware.Components;

namespace AlquilaFacilPlatform.IAM.Infraestructure.Middleware.Extentions;

public static class RequestAutorizationMiddlewareExtentions
{
    public static IApplicationBuilder UseRequestAutorizationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAutorizationMiddleware>();
    }
}