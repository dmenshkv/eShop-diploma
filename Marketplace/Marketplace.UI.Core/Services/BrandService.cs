namespace Marketplace.UI.Core.Services;

public class BrandService : BaseService<BrandViewModel>, IBrandService
{
    private readonly string _baseApiPath;

    private readonly IOptions<AppSettings> _appSettings;

    public BrandService(IHttpClientService httpClientService, IOptions<AppSettings> appSettings)
        : base(httpClientService)
    {
        _appSettings = appSettings;

        _baseApiPath = string.Format(ApiRouteTemplates.ApiFormat, _appSettings.Value.CatalogUrl, ApiEndpoints.Brand);
    }

    public async Task<BrandViewModel> CreateAsync(CreateBrandRequest request)
    {
        return await AddAsync(_baseApiPath, request);
    }

    public async Task<BrandViewModel> GetAsync(Guid id)
    {
        return await GetAsync($"{_baseApiPath}/{id}");
    }

    public async Task<GetItemsResponse<BrandViewModel>> GetAllAsync()
    {
        return await GetAllAsync(_baseApiPath);
    }

    public async Task<BrandViewModel> UpdateAsync(Guid id, BrandViewModel brand)
    {
        return await UpdateAsync($"{_baseApiPath}/{id}", brand);
    }

    public async Task DeleteAsync(Guid id)
    {
        await RemoveAsync($"{_baseApiPath}/{id}");
    }
}