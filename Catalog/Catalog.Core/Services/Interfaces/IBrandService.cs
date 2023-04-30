using Catalog.Models.DTOs;
using Catalog.Models.Requests;
using Catalog.Models.Responses;

namespace Catalog.Core.Services.Interfaces
{
    public interface IBrandService
    {
        Task<AddItemResponse> AddBrandAsync(AddItemRequest<BrandDto> addItemRequest);

        Task<UpdateItemResponse> UpdateBrandAsync(Guid id, UpdateItemRequest<BrandDto> updateItemRequest);

        Task<RemoveItemResponse> RemoveBrandAsync(Guid id);

        Task<GetAllItemsResponse<BrandDto>> GetAllBrandsAsync();
    }
}