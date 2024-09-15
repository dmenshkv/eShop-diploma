using AutoMapper;
using Basket.Entites.Common;

namespace Basket.Core.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BasketItem, BasketItemDto>().ReverseMap();

        CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();
    }
}