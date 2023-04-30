using Marketplace.Models.Requests;
using Marketplace.Models.Responses;
using Marketplace.Models.ViewModels;

namespace Marketplace.UI.Core.Services.Interfaces
{
    public interface IMechanicService
    {
        Task<AddItemResponse> AddMechanicAsync(AddItemRequest<MechanicViewModel> addItemRequest);

        Task<UpdateItemResponse> UpdateMechanicAsync(Guid id, UpdateItemRequest<MechanicViewModel> updateItemRequest);

        Task<RemoveItemResponse> RemoveMechanicAsync(Guid id);

        Task<GetAllItemsResponse<MechanicViewModel>> GetAllMechanicsAsync();
    }
}
