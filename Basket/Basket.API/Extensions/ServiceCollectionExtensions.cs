using Microsoft.OpenApi.Models;
using Basket.Models.Configurations;

namespace Basket.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Basket API",
                Description = "API for managing customer baskets, including adding, updating, and retrieving basket items.",
                Version = "v1"
            });

            var xmlPath = Path.Combine(AppContext.BaseDirectory, "Basket.API.xml");

            options.IncludeXmlComments(xmlPath);
        });
    }

    public static void ConfigureCorsForOrigins(this IServiceCollection services, ConfigurationManager configuration)
    {
        var corsOriginConfiguration = configuration.GetSection(ConfigurationSectionsNames.CorsOrigin)
            .Get<CorsOriginConfig>();

        services.AddCors(options =>
        {
            options.AddPolicy(
                ConfigurationSectionsNames.CorsOrigin,
                builder => builder
                    .WithOrigins(corsOriginConfiguration!.AllowedOrigins.ToArray())
                    .WithHeaders("Content-Type")
                    .AllowAnyMethod());
        });
    }
}