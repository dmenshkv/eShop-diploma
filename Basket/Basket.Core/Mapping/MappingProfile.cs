using AutoMapper;
using Basket.Entites.Common;
using Basket.Models.DTOs;

namespace Basket.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<CustomerBasket, CustomerBasketDto>();
        }
    }
}