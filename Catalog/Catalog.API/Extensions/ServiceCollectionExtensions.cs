using System.Diagnostics.CodeAnalysis;
using Catalog.API.Constants;
using Catalog.Core.Extensions;
using Catalog.Models.Configurations;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection serviceCollection, ConfigurationManager configuration)
        {
            serviceCollection.AddDatabaseContext(configuration.GetConnectionString(ConfigurationSectionsNames.SqlConnection)!);
        }

        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IJsonSerializer, JsonSerializer>();
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

        public static void ConfigureOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<CatalogConfig>(configuration);
        }
    }
}