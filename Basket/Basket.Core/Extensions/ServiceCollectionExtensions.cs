using Basket.Core.Constants;
using Basket.Core.Mapping;
using Basket.Core.Models.Configurations;
using Basket.Core.Services;
using Basket.Core.Services.Interfaces;
using Basket.DataAccess.Extensions;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Core.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static void AddCoreServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(MappingProfile));

        serviceCollection.AddTransient<IBasketService, BasketService>();
    }

    public static void AddRedisRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddRepositories();
    }

    public static void ConfigureRedis(this IServiceCollection serviceCollection, ConfigurationManager configuration)
    {
        var redisConfig = configuration.GetSection(ConfigurationSectionsNames.Redis).Get<RedisConfig>();

        serviceCollection.AddRedisCache(redisConfig!.Host);
    }

    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IJsonSerializer, JsonSerializer>();
    }
}