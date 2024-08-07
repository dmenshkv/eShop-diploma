using Catalog.API.Middlewares;
using Catalog.DataAccess.Contexts;
using Catalog.DataAccess.Initializators;

namespace Catalog.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ApplicationBuilderExtensions
{
    public static void UseErrorHandlingMiddleware(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<ErrorHandlingMiddleware>();
    }

    public static async Task InitializeDatabaseAsync(this IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        await DbInitializer.InitializeAsync(context!);
    }
}