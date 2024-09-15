using System.Linq.Expressions;

namespace Catalog.DataAccess.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<TEntity> CreateAsync(TEntity entity);

    Task<TEntity> GetByIdAsync(Guid id);

    Task<IReadOnlyList<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression, bool asNoTracking = true);

    Task<TEntity> UpdateAsync(Guid id, TEntity entity);

    Task DeleteAsync(Guid id);
}