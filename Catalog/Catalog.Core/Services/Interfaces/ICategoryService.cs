namespace Catalog.Core.Services.Interfaces;

public interface ICategoryService
{
    Task<CategoryDto> CreateAsync<CreateCategoryRequest>(CreateCategoryRequest request)
        where CreateCategoryRequest : class;

    Task<CategoryDto> GetByIdAsync(Guid id);

    Task<GetItemsResponse<CategoryDto>> GetAllAsync();

    Task<CategoryDto> UpdateAsync(Guid id, CategoryDto category);

    Task DeleteAsync(Guid id);
}