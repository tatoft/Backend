using AlquilaFacilPlatform.IAM.Infraestructure.Pipeline.Middleware.Components;

namespace AlquilaFacilPlatform.IAM.Infraestructure.Pipeline.Middleware.Extentions;

public static class RequestAutorizationMiddlewareExtentions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAutorizationMiddleware>();
    }
}