using AutoMapper;
using Basket.Core.Constants;
using Basket.Core.Models.Requests;
using Basket.Core.Models.Responses;
using Basket.Core.Services.Interfaces;
using Basket.DataAccess.Entities.Common;
using Basket.DataAccess.Repositories.Interfaces;

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

    public async Task<AddItemResponse> AddBasketItemAsync(AddItemRequest request)
    {
        var basket = await _cacheRepository.GetAsync(request.CustomerId) ?? new CustomerBasket();

        var basketItem = basket.Items.FirstOrDefault(i => i.Id == request.Item.Id);

        if (basketItem is not null)
        {
            basketItem.Quantity++;
        }
        else
        {
            basket.Items.Add(_mapper.Map<BasketItem>(request.Item));
        }

        var result = await _cacheRepository.UpdateAsync(request.CustomerId, basket);

        return new AddItemResponse()
        {
            IsItemAdded = result
        };
    }

    public async Task<CustomerBasketDto> GetBasketAsync(Guid id)
    {
        var customerBasket = await _cacheRepository.GetAsync(id);

        return _mapper.Map<CustomerBasketDto>(customerBasket);
    }

    public async Task<CustomerBasketDto> UpdateBasketAsync(UpdateBasketRequest request)
    {
        var result = await _cacheRepository.UpdateAsync(request.CustomerId, _mapper.Map<CustomerBasket>(request.CustomerBasket));

        return result ? request.CustomerBasket : throw new InvalidOperationException(ErrorMessages.BasketUpdateFailedError);
    }
}