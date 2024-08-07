using Basket.API.Middlewares;

namespace Basket.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ApplicationBuilderExtensions
{
    public static void UseErrorHandlingMiddleware(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}