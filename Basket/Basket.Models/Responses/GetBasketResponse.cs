using Basket.Models.DTOs;
using System.Diagnostics.CodeAnalysis;

namespace Basket.Models.Responses
{
    [ExcludeFromCodeCoverage]
    public class GetBasketResponse
    {
        public CustomerBasketDto CustomerBasket { get; set; } = null!;
    }
}