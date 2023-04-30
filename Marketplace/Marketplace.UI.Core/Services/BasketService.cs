using Marketplace.Models.Configurations;
using Marketplace.Models.Requests.Basket;
using Marketplace.Models.Responses;
using Marketplace.Models.Responses.Basket;
using Marketplace.UI.Core.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Marketplace.UI.Core.Services
{
    public class BasketService : IBasketService
    {
        private readonly string _baseApiPath;

        private readonly IOptions<AppSettings> _appSettings;
        private readonly IHttpClientService _httpClientService;

        public BasketService(IOptions<AppSettings> appSettings, IHttpClientService httpClientService)
        {
            _appSettings = appSettings;
            _httpClientService = httpClientService;

            _baseApiPath = $"{_appSettings.Value.BasketUrl}/basket";
        }

        public async Task<GetBasketResponse> GetBasketAsync(Guid id)
        {
            return await _httpClientService.GetAsync<GetBasketResponse>($"{_baseApiPath}/{id}");
        }

        public async Task<AddToBasketResponse> AddToBasketAsync(AddToBasketRequest addItemRequest)
        {
            return await _httpClientService.PostAsync<AddToBasketResponse, AddToBasketRequest>(_baseApiPath, addItemRequest);
        }

        public async Task<RemoveItemResponse> RemoveFromBasket(Guid id, Guid itemId)
        {
            return await _httpClientService.DeleteAsync<RemoveItemResponse>($"{_baseApiPath}/{id}/{itemId}");
        }

        public async Task<UpdateItemResponse> UpdateQuantities(Guid id, UpdateQuantityRequest updateQuantityRequest)
        {
            return await _httpClientService.PutAsync<UpdateItemResponse, UpdateQuantityRequest>($"{_baseApiPath}/{id}", updateQuantityRequest);
        }
    }
}