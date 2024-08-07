using Marketplace.Models.Requests.Basket;
using Marketplace.Models.Responses.Basket;

namespace Marketplace.UI.Core.Services.Interfaces;

public interface IBasketService
{
    public Task<GetBasketResponse> GetBasketAsync(Guid id);

    public Task<AddToBasketResponse> AddToBasketAsync(AddToBasketRequest addItemRequest);

    public Task<RemoveItemResponse> RemoveFromBasket(Guid id, Guid itemId);

    public Task<UpdateItemResponse> UpdateQuantities(Guid id, UpdateQuantityRequest updateQuantityRequest);
}