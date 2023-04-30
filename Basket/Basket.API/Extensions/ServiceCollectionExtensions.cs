using Basket.API.Constants;
using Basket.Models.Configurations;
using System.Diagnostics.CodeAnalysis;

namespace Basket.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
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
}