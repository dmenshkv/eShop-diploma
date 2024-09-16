namespace Marketplace.UI.Core.Services.Interfaces;

public interface IMechanicService
{
    Task<MechanicViewModel> CreateAsync(CreateMechanicRequest request);

    Task<MechanicViewModel> GetAsync(Guid id);

    Task<GetItemsResponse<MechanicViewModel>> GetAllAsync();

    Task<MechanicViewModel> UpdateAsync(Guid id, MechanicViewModel mechanic);

    Task DeleteAsync(Guid id);
}