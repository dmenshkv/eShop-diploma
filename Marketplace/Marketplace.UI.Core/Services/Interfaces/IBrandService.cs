using Marketplace.Models.Requests.Catalog;
using Marketplace.Models.ViewModels.Catalog;

namespace Marketplace.UI.Core.Services.Interfaces;

public interface IBrandService
{
    Task<BrandViewModel> CreateAsync(CreateBrandRequest request);

    Task<BrandViewModel> GetAsync(Guid id);

    Task<GetItemsResponse<BrandViewModel>> GetAllAsync();

    Task<BrandViewModel> UpdateAsync(Guid id, BrandViewModel brand);

    Task DeleteAsync(Guid id);
}