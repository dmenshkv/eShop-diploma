namespace Catalog.Core.Services.Interfaces;

public interface IBrandService
{
    Task<BrandDto> CreateAsync<CreateBrandRequest>(CreateBrandRequest request)
        where CreateBrandRequest : class;

    Task<BrandDto> GetByIdAsync(Guid id);

    Task<GetItemsResponse<BrandDto>> GetAllAsync();

    Task<BrandDto> UpdateAsync(Guid id, BrandDto brand);

    Task DeleteAsync(Guid id);
}