using Marketplace.Models.Requests.Catalog;
using Marketplace.Models.ViewModels.Catalog;

namespace Marketplace.UI.Core.Services.Interfaces;

public interface ICategoryService
{
    Task<CategoryViewModel> CreateAsync(CreateCategoryRequest request);

    Task<CategoryViewModel> GetAsync(Guid id);

    Task<GetItemsResponse<CategoryViewModel>> GetAllAsync();

    Task<CategoryViewModel> UpdateAsync(Guid id, CategoryViewModel category);

    Task DeleteAsync(Guid id);
}