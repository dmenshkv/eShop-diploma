using Catalog.Models.DTOs;
using Catalog.Models.Requests;
using Catalog.Models.Responses;

namespace Catalog.Core.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<AddItemResponse> AddCategoryAsync(AddItemRequest<CategoryDto> addItemRequest);

        Task<UpdateItemResponse> UpdateCategoryAsync(Guid id, UpdateItemRequest<CategoryDto> updateItemRequest);

        Task<RemoveItemResponse> RemoveCategoryAsync(Guid id);

        Task<GetAllItemsResponse<CategoryDto>> GetAllCategoriesAsync();
    }
}