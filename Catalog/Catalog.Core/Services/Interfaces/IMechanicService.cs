using Catalog.Models.DTOs;
using Catalog.Models.Requests;
using Catalog.Models.Responses;

namespace Catalog.Core.Services.Interfaces
{
    public interface IMechanicService
    {
        Task<AddItemResponse> AddMechanicAsync(AddItemRequest<MechanicDto> addItemRequest);

        Task<UpdateItemResponse> UpdateMechanicAsync(Guid id, UpdateItemRequest<MechanicDto> updateItemRequest);

        Task<RemoveItemResponse> RemoveMechanicAsync(Guid id);

        Task<GetAllItemsResponse<MechanicDto>> GetAllMechanicsAsync();
    }
}