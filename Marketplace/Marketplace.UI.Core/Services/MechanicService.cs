using Marketplace.Models.Requests.Catalog;
using Marketplace.Models.ViewModels.Catalog;
using Marketplace.UI.Core.Constants;

namespace Marketplace.UI.Core.Services;

public class MechanicService : BaseService<MechanicViewModel>, IMechanicService
{
    private readonly string _baseApiPath;

    private readonly IOptions<AppSettings> _appSettings;

    public MechanicService(IHttpClientService httpClientService, IOptions<AppSettings> appSettings)
        : base(httpClientService)
    {
        _appSettings = appSettings;

        _baseApiPath = string.Format(RouteTemplates.ApiFormat, _appSettings.Value.CatalogUrl, ApiEndpoints.Mechanic);
    }

    public async Task<MechanicViewModel> CreateAsync(CreateMechanicRequest request)
    {
        return await AddAsync(_baseApiPath, request);
    }

    public async Task<MechanicViewModel> GetAsync(Guid id)
    {
        return await GetAsync($"{_baseApiPath}/{id}");
    }

    public async Task<GetItemsResponse<MechanicViewModel>> GetAllAsync()
    {
        return await GetAllAsync(_baseApiPath);
    }

    public async Task<MechanicViewModel> UpdateAsync(Guid id, MechanicViewModel brand)
    {
        return await UpdateAsync($"{_baseApiPath}/{id}", brand);
    }

    public async Task DeleteAsync(Guid id)
    {
        await RemoveAsync($"{_baseApiPath}/{id}");
    }
}