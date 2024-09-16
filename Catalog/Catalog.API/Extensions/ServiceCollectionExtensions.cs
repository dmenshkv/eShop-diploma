using Catalog.Core.Extensions;
using Catalog.Core.Models.Configurations;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.OpenApi.Models;

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

        public static void ConfigureOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<CatalogConfig>(configuration);
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Catalog API",
                    Description = "API for managing and retrieving catalog information, including board games and related entities.",
                    Version = "v1"
                });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Catalog.API.xml");

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
}