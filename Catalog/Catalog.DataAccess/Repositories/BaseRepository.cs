using System.Linq.Expressions;
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

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), ErrorMessages.AddItemNullError);
        }

        await _applicationDbContext.Set<TEntity>().AddAsync(entity);
        await _applicationDbContext.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext
            .Set<TEntity>()
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.Id == id)
            ?? throw new EntityNotFoundException(string.Format(ErrorMessages.ItemNotFoundError, id));
    }

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await _applicationDbContext.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression, bool asNoTracking = true)
    {
        if (expression is null)
        {
            throw new ArgumentNullException(nameof(expression), ErrorMessages.FilterExpressionNullError);
        }

        var query = _applicationDbContext.Set<TEntity>().Where(expression);

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync();
    }

    public virtual async Task<TEntity> UpdateAsync(Guid id, TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), ErrorMessages.UpdateItemNullError);
        }

        var existingEntity = await _applicationDbContext
            .Set<TEntity>()
            .SingleOrDefaultAsync(e => e.Id == id)
            ?? throw new EntityNotFoundException(string.Format(ErrorMessages.ItemNotFoundError, id));

        _applicationDbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

        await _applicationDbContext.SaveChangesAsync();

        return entity;
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _applicationDbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id)
            ?? throw new EntityNotFoundException(string.Format(ErrorMessages.ItemNotFoundError, id));

        _applicationDbContext.Remove(entity);

        await _applicationDbContext.SaveChangesAsync();
    }
}