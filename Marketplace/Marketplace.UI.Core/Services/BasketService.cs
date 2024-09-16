using Marketplace.UI.Core.Models.Requests.Basket;
using Marketplace.UI.Core.Models.Responses.Basket;
using Marketplace.UI.Core.Models.ViewModels.Basket;

namespace Marketplace.UI.Core.Services;

public class BasketService : IBasketService
{
    private readonly string _baseApiPath;

    private readonly IOptions<AppSettings> _appSettings;
    private readonly IHttpClientService _httpClientService;

    public BasketService(IOptions<AppSettings> appSettings, IHttpClientService httpClientService)
    {
        _appSettings = appSettings;
        _httpClientService = httpClientService;

        _baseApiPath = string.Format(ApiRouteTemplates.ApiFormat, _appSettings.Value.BasketUrl, ApiEndpoints.Basket);
    }

    public async Task<AddItemResponse> AddBasketItemAsync(AddItemRequest request)
    {
        return await _httpClientService.PostAsync<AddItemResponse, AddItemRequest>(_baseApiPath, request);
    }

    public async Task<CustomerBasketViewModel> GetBasketAsync(Guid id)
    {
        return await _httpClientService.GetAsync<CustomerBasketViewModel>($"{_baseApiPath}/{id}");
    }

    public async Task<CustomerBasketViewModel> UpdateBasketAsync(Guid id, UpdateBasketRequest request)
    {
        return await _httpClientService.PutAsync<CustomerBasketViewModel, UpdateBasketRequest>($"{_baseApiPath}/{id}", request);
    }
}