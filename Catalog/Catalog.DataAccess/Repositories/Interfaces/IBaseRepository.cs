namespace Catalog.DataAccess.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<Guid> AddAsync(TEntity item);

    Task<bool> UpdateAsync(Guid id, TEntity item);

    Task<bool> RemoveAsync(Guid id);

    Task<IEnumerable<TEntity>> GetAllAsync();
}