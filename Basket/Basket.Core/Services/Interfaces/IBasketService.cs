using Basket.Models.Requests;
using Basket.Models.Responses;

namespace Basket.Core.Services.Interfaces;

public interface IBasketService
{
    Task<AddItemResponse> AddBasketItemAsync(AddItemRequest request);

    Task<CustomerBasketDto> GetBasketAsync(Guid id);

    Task<CustomerBasketDto> UpdateBasketAsync(UpdateBasketRequest request);
}