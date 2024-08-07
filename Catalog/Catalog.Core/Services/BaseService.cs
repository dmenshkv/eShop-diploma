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

    public virtual async Task<AddItemResponse> AddAsync(AddItemRequest<TModel> addItemRequest)
    {
        var mappedEntity = _mapper.Map<TEntity>(addItemRequest.Item);
        var entityId = await _baseRepository.AddAsync(mappedEntity);

        return new AddItemResponse()
        {
            Id = entityId
        };
    }

    public virtual async Task<GetAllItemsResponse<TModel>> GetAllAsync()
    {
        var items = await _baseRepository.GetAllAsync();

        return new GetAllItemsResponse<TModel>()
        {
            Value = _mapper.Map<IEnumerable<TModel>>(items)
        };
    }

    public virtual async Task<RemoveItemResponse> RemoveAsync(Guid id)
    {
        var isRemoved = await _baseRepository.RemoveAsync(id);

        return new RemoveItemResponse()
        {
            IsRemoved = isRemoved
        };
    }

    public virtual async Task<UpdateItemResponse> UpdateAsync(Guid id, UpdateItemRequest<TModel> updateItemRequest)
    {
        var mappedEntity = _mapper.Map<TEntity>(updateItemRequest.Item);
        var isUpdated = await _baseRepository.UpdateAsync(id, mappedEntity);

        return new UpdateItemResponse()
        {
            IsUpdated = isUpdated
        };
    }
}