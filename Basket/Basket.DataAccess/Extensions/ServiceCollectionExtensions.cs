using Basket.DataAccess.Repositories;
using Basket.DataAccess.Repositories.Interfaces;
using Basket.Models.Configurations;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Basket.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRedisCache(this IServiceCollection serviceCollection, string host)
        {
            serviceCollection.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var options = ConfigurationOptions.Parse(host, true);

                return ConnectionMultiplexer.Connect(options);
            });
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICacheRepository, CacheRepository>();
        }
    }
}