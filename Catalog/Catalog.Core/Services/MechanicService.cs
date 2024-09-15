namespace Catalog.Core.Services;

public class MechanicService : BaseService<Mechanic, MechanicDto>, IMechanicService
{
    public MechanicService(IMapper mapper, IBaseRepository<Mechanic> baseRepository)
        : base(mapper, baseRepository)
    {
    }

    public override async Task<MechanicDto> CreateAsync<CreateMechanicRequest>(CreateMechanicRequest request)
    {
        return await base.CreateAsync(request);
    }

    public override async Task<MechanicDto> GetByIdAsync(Guid id)
    {
        return await base.GetByIdAsync(id);
    }

    public override async Task<GetItemsResponse<MechanicDto>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    public override async Task<MechanicDto> UpdateAsync(Guid id, MechanicDto mechanic)
    {
        return await base.UpdateAsync(id, mechanic);
    }

    public override async Task DeleteAsync(Guid id)
    {
        await base.DeleteAsync(id);
    }
}