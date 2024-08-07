namespace Catalog.Core.Services;

public class MechanicService : BaseService<Mechanic, MechanicDto>, IMechanicService
{
    public MechanicService(IMapper mapper, IBaseRepository<Mechanic> baseRepository)
        : base(mapper, baseRepository)
    {
    }

    public async Task<AddItemResponse> AddMechanicAsync(AddItemRequest<MechanicDto> addItemRequest)
    {
        return await AddAsync(addItemRequest);
    }

    public async Task<GetAllItemsResponse<MechanicDto>> GetAllMechanicsAsync()
    {
        return await GetAllAsync();
    }

    public async Task<RemoveItemResponse> RemoveMechanicAsync(Guid id)
    {
        return await RemoveAsync(id);
    }

    public async Task<UpdateItemResponse> UpdateMechanicAsync(Guid id, UpdateItemRequest<MechanicDto> updateItemRequest)
    {
        return await UpdateAsync(id, updateItemRequest);
    }
}