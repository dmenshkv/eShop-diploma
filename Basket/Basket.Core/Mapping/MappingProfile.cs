using AutoMapper;
using Basket.DataAccess.Entities.Common;

namespace Basket.Core.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BasketItem, BasketItemDto>().ReverseMap();

        CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();
    }
}