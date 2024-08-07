using Catalog.DataAccess.Exceptions;
using Catalog.DataAccess.Repositories.Interfaces;

namespace Catalog.DataAccess.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext _applicationDbContext;

    public BaseRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public virtual async Task<Guid> AddAsync(TEntity item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item to add can not be null");
        }

        await _applicationDbContext.Set<TEntity>().AddAsync(item);
        await _applicationDbContext.SaveChangesAsync();

        return item.Id;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var items = await _applicationDbContext.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

        return items;
    }

    public virtual async Task<bool> RemoveAsync(Guid id)
    {
        var item = await _applicationDbContext.Set<TEntity>().FindAsync(id);

        if (item == null)
        {
            throw new EntityNotFoundException($"Item with id {id} was not found");
        }

        _applicationDbContext.Remove(item);
        var rowsAffected = await _applicationDbContext.SaveChangesAsync();

        return rowsAffected > 0;
    }

    public virtual async Task<bool> UpdateAsync(Guid id, TEntity item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item to update can not be null");
        }

        var existingItem = await _applicationDbContext
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);

        if (existingItem == null)
        {
            throw new EntityNotFoundException($"Item with id {id} was not found");
        }

        _applicationDbContext.Set<TEntity>().Update(item);
        var rowsAffected = await _applicationDbContext.SaveChangesAsync();

        return rowsAffected > 0;
    }
}