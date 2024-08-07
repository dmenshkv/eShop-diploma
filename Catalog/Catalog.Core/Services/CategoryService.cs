namespace Catalog.Core.Services;

public class CategoryService : BaseService<Category, CategoryDto>, ICategoryService
{
    public CategoryService(IMapper mapper, IBaseRepository<Category> baseRepository)
        : base(mapper, baseRepository)
    {
    }

    public async Task<AddItemResponse> AddCategoryAsync(AddItemRequest<CategoryDto> addItemRequest)
    {
        return await AddAsync(addItemRequest);
    }

    public async Task<GetAllItemsResponse<CategoryDto>> GetAllCategoriesAsync()
    {
        return await GetAllAsync();
    }

    public async Task<RemoveItemResponse> RemoveCategoryAsync(Guid id)
    {
        return await RemoveAsync(id);
    }

    public async Task<UpdateItemResponse> UpdateCategoryAsync(Guid id, UpdateItemRequest<CategoryDto> updateItemRequest)
    {
        return await UpdateAsync(id, updateItemRequest);
    }
}