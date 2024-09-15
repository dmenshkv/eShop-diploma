namespace Catalog.Core.Services;

public abstract class BaseService<TEntity, TModel>
    where TEntity : BaseEntity
    where TModel : class
{
    protected readonly IMapper _mapper;
    protected readonly IBaseRepository<TEntity> _baseRepository;

    public BaseService(IMapper mapper, IBaseRepository<TEntity> baseRepository)
    {
        _mapper = mapper;
        _baseRepository = baseRepository;
    }

    public virtual async Task<TModel> CreateAsync<TRequest>(TRequest request)
        where TRequest : class
    {
        var mappedEntity = _mapper.Map<TEntity>(request);
        var createdEntity = await _baseRepository.CreateAsync(mappedEntity);

        return _mapper.Map<TModel>(createdEntity);
    }

    public virtual async Task<TModel> GetByIdAsync(Guid id)
    {
        var entity = await _baseRepository.GetByIdAsync(id);

        return _mapper.Map<TModel>(entity);
    }

    public virtual async Task<GetItemsResponse<TModel>> GetAllAsync()
    {
        var entities = await _baseRepository.GetAllAsync();

        return new GetItemsResponse<TModel>()
        {
            Count = entities.Count,
            Value = _mapper.Map<IEnumerable<TModel>>(entities)
        };
    }

    public virtual async Task<TModel> UpdateAsync(Guid id, TModel model)
    {
        var mappedEntity = _mapper.Map<TEntity>(model);
        var updatedEntity = await _baseRepository.UpdateAsync(id, mappedEntity);

        return _mapper.Map<TModel>(updatedEntity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _baseRepository.DeleteAsync(id);
    }
}