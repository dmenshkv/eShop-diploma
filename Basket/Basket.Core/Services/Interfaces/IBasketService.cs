using Basket.Models.DTOs;
using Basket.Models.Requests;
using Basket.Models.Responses;

namespace Basket.Core.Services.Interfaces
{
    public interface IBasketService
    {
        Task<CustomerBasketDto> GetBasketAsync(Guid id);

        Task<AddItemResponse> AddToBasketAsync(AddItemRequest addItemRequest);

        Task<RemoveItemResponse> RemoveFromBasketAsync(Guid id, Guid itemId);

        Task<UpdateQuantityResponse> UpdateQuantityAsync(UpdateQuantityRequest updateQuantityRequest);
    }
}