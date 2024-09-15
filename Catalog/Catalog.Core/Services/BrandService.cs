namespace Catalog.Core.Services;

public class BrandService : BaseService<Brand, BrandDto>, IBrandService
{
    public BrandService(IMapper mapper, IBaseRepository<Brand> baseRepository)
        : base(mapper, baseRepository)
    {
    }

    public override async Task<BrandDto> CreateAsync<CreateBrandRequest>(CreateBrandRequest request)
    {
        return await base.CreateAsync(request);
    }

    public override async Task<BrandDto> GetByIdAsync(Guid id)
    {
        return await base.GetByIdAsync(id);
    }

    public override async Task<BrandDto> UpdateAsync(Guid id, BrandDto brand)
    {
        return await base.UpdateAsync(id, brand);
    }

    public override async Task<GetItemsResponse<BrandDto>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    public override async Task DeleteAsync(Guid id)
    {
        await base.DeleteAsync(id);
    }
}