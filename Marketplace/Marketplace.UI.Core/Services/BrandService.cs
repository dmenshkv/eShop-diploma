namespace Marketplace.UI.Core.Services;

public class BrandService : BaseService<BrandViewModel>, IBrandService
{
    private readonly string _baseApiPath;

    private readonly IOptions<AppSettings> _appSettings;

    public BrandService(IHttpClientService httpClientService, IOptions<AppSettings> appSettings)
        : base(httpClientService)
    {
        _appSettings = appSettings;

        _baseApiPath = $"{_appSettings.Value.CatalogUrl}/brands";
    }

    public async Task<AddItemResponse> AddBrandAsync(AddItemRequest<BrandViewModel> addItemRequest)
    {
        return await AddAsync(_baseApiPath, addItemRequest);
    }

    public async Task<GetAllItemsResponse<BrandViewModel>> GetAllBrandsAsync()
    {
        return await GetAllAsync(_baseApiPath);
    }

    public async Task<RemoveItemResponse> RemoveBrandAsync(Guid id)
    {
        return await RemoveAsync($"{_baseApiPath}/{id}");
    }

    public async Task<UpdateItemResponse> UpdateBrandAsync(Guid id, UpdateItemRequest<BrandViewModel> updateItemRequest)
    {
        return await UpdateAsync($"{_baseApiPath}/{id}", updateItemRequest);
    }
}