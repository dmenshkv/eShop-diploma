using System.Diagnostics.CodeAnalysis;
using Catalog.Core.Mapping;
using Catalog.Core.Services;
using Catalog.Core.Services.Interfaces;
using Catalog.DataAccess.Extensions;
using Catalog.Models.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Core.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static void AddCoreServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(MappingProfile));

            serviceCollection.AddTransient<IBrandService, BrandService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IMechanicService, MechanicService>();
            serviceCollection.AddTransient<IBoardGameService, BoardGameService>();
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbRepositories();
        }

        public static void AddDatabaseContext(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddApplicationDbContext(connectionString);
        }
    }
}