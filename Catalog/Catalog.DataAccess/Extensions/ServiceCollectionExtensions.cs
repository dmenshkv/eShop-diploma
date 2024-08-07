using Catalog.DataAccess.Repositories;
using Catalog.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.DataAccess.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static void AddApplicationDbContext(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContextFactory<ApplicationDbContext>(opts => opts.UseNpgsql(connectionString));
    }

    public static void AddDbRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        serviceCollection.AddTransient<IBoardGameRepository, BoardGameRepository>();
    }
}