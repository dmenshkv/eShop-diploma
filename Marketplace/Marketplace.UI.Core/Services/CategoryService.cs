using Marketplace.Models.Requests.Catalog;
using Marketplace.Models.ViewModels.Catalog;
using Marketplace.UI.Core.Constants;

namespace Marketplace.UI.Core.Services;

public class CategoryService : BaseService<CategoryViewModel>, ICategoryService
{
    private readonly string _baseApiPath;

    private readonly IOptions<AppSettings> _appSettings;

    public CategoryService(IHttpClientService httpClientService, IOptions<AppSettings> appSettings)
        : base(httpClientService)
    {
        _appSettings = appSettings;

        _baseApiPath = _baseApiPath = string.Format(RouteTemplates.ApiFormat, _appSettings.Value.CatalogUrl, ApiEndpoints.Category);
    }

    public async Task<CategoryViewModel> CreateAsync(CreateCategoryRequest request)
    {
        return await AddAsync(_baseApiPath, request);
    }

    public async Task<CategoryViewModel> GetAsync(Guid id)
    {
        return await GetAsync($"{_baseApiPath}/{id}");
    }

    public async Task<GetItemsResponse<CategoryViewModel>> GetAllAsync()
    {
        return await GetAllAsync(_baseApiPath);
    }

    public async Task<CategoryViewModel> UpdateAsync(Guid id, CategoryViewModel brand)
    {
        return await UpdateAsync($"{_baseApiPath}/{id}", brand);
    }

    public async Task DeleteAsync(Guid id)
    {
        await RemoveAsync($"{_baseApiPath}/{id}");
    }
}