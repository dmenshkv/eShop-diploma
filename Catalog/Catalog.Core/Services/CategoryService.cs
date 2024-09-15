namespace Catalog.Core.Services;

public class CategoryService : BaseService<Category, CategoryDto>, ICategoryService
{
    public CategoryService(IMapper mapper, IBaseRepository<Category> baseRepository)
        : base(mapper, baseRepository)
    {
    }

    public override async Task<CategoryDto> CreateAsync<CreateCategoryRequest>(CreateCategoryRequest request)
    {
        return await base.CreateAsync(request);
    }

    public override async Task<CategoryDto> GetByIdAsync(Guid id)
    {
        return await base.GetByIdAsync(id);
    }

    public override async Task<GetItemsResponse<CategoryDto>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    public override async Task<CategoryDto> UpdateAsync(Guid id, CategoryDto category)
    {
        return await base.UpdateAsync(id, category);
    }

    public override async Task DeleteAsync(Guid id)
    {
        await base.DeleteAsync(id);
    }
}