using AutoMapper;
using Basket.Core.Services.Interfaces;
using Basket.DataAccess.Repositories.Interfaces;
using Basket.Entites.Common;
using Basket.Models.Requests;
using Basket.Models.Responses;

namespace Basket.Core.Services;

public class BasketService : IBasketService
{
    private readonly ICacheRepository _cacheRepository;
    private readonly IMapper _mapper;

    public BasketService(ICacheRepository cacheRepository, IMapper mapper)
    {
        _cacheRepository = cacheRepository;
        _mapper = mapper;
    }

    public async Task<CustomerBasketDto> GetBasketAsync(Guid id)
    {
        var customerBasket = await _cacheRepository.GetAsync(id);

        return _mapper.Map<CustomerBasketDto>(customerBasket) ?? new CustomerBasketDto();
    }

    public async Task<AddItemResponse> AddToBasketAsync(AddItemRequest addItemRequest)
    {
        var basket = await _cacheRepository.GetAsync(addItemRequest.Id) ?? new CustomerBasket();

        var existingBasketItem = basket.Items.FirstOrDefault(i => i.Id == addItemRequest.Item.Id);

        if (existingBasketItem is not null)
        {
            existingBasketItem.Quantity++;
        }
        else
        {
            basket.Items.Add(_mapper.Map<BasketItem>(addItemRequest.Item));
        }

        var result = await _cacheRepository.AddOrUpdateAsync(addItemRequest.Id, basket);

        return new AddItemResponse()
        {
            IsAdded = result
        };
    }

    public async Task<RemoveItemResponse> RemoveFromBasketAsync(Guid id, Guid itemId)
    {
        var basket = await _cacheRepository.GetAsync(id) ?? new CustomerBasket();

        var itemToRemove = basket.Items.FirstOrDefault(i => i.Id == itemId);

        if (itemToRemove is null)
        {
            return new RemoveItemResponse()
            {
                IsRemoved = false
            };
        }

        basket.Items.Remove(itemToRemove);

        var result = await _cacheRepository.AddOrUpdateAsync(id, basket);

        return new RemoveItemResponse()
        {
            IsRemoved = result
        };
    }

    public async Task<UpdateQuantityResponse> UpdateQuantityAsync(UpdateQuantityRequest updateQuantityRequest)
    {
        var basket = await _cacheRepository.GetAsync(updateQuantityRequest.Id) ?? new CustomerBasket();
        var quantites = updateQuantityRequest.Quantities;

        foreach (var item in quantites)
        {
            var basketItem = basket.Items.FirstOrDefault(f => f.Id == item.Key);
            if (basketItem is not null)
            {
                basketItem.Quantity = item.Value;
            }
        }

        var result = await _cacheRepository.AddOrUpdateAsync(updateQuantityRequest.Id, basket);

        return new UpdateQuantityResponse()
        {
            IsUpdated = result
        };
    }
}