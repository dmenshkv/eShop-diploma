using Marketplace.Models.Requests.Basket;
using Marketplace.Models.Responses.Basket;
using Marketplace.Models.ViewModels.Basket;

namespace Marketplace.UI.Core.Services.Interfaces;

public interface IBasketService
{
    public Task<AddItemResponse> AddBasketItemAsync(AddItemRequest request);

    public Task<CustomerBasketViewModel> GetBasketAsync(Guid id);

    public Task<CustomerBasketViewModel> UpdateBasketAsync(Guid id, UpdateBasketRequest request);
}