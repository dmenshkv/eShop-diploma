using Catalog.DataAccess.Exceptions;
using Catalog.DataAccess.Repositories.Interfaces;
using Catalog.DataAccess.Resources;

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
            throw new ArgumentNullException(nameof(item), ErrorMessages.AddItemNullError);
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
        var item = await _applicationDbContext.Set<TEntity>().FindAsync(id)
            ?? throw new EntityNotFoundException(string.Format(ErrorMessages.ItemNotFoundError, id));

        _applicationDbContext.Remove(item);

        var rowsAffected = await _applicationDbContext.SaveChangesAsync();

        return rowsAffected > 0;
    }

    public virtual async Task<bool> UpdateAsync(Guid id, TEntity item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), ErrorMessages.UpdateItemNullError);
        }

        var existingItem = await _applicationDbContext
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id)
            ?? throw new EntityNotFoundException(string.Format(ErrorMessages.ItemNotFoundError, id));

        _applicationDbContext.Set<TEntity>().Update(item);

        var rowsAffected = await _applicationDbContext.SaveChangesAsync();

        return rowsAffected > 0;
    }
}