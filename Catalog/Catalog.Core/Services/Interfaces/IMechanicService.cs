namespace Catalog.Core.Services.Interfaces;

public interface IMechanicService
{
    Task<MechanicDto> CreateAsync<CreateMechanicRequest>(CreateMechanicRequest request)
        where CreateMechanicRequest : class;

    Task<MechanicDto> GetByIdAsync(Guid id);

    Task<GetItemsResponse<MechanicDto>> GetAllAsync();

    Task<MechanicDto> UpdateAsync(Guid id, MechanicDto mechanic);

    Task DeleteAsync(Guid id);
}