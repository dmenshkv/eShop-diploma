namespace Basket.Core.Models.DTOs;

[ExcludeFromCodeCoverage]
public class CustomerBasketDto
{
    public IEnumerable<BasketItemDto> Items { get; set; } = null!;
}