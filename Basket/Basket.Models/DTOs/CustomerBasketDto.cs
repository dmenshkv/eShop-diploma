using System.Diagnostics.CodeAnalysis;

namespace Basket.Models.DTOs;

[ExcludeFromCodeCoverage]
public class CustomerBasketDto
{
    public IEnumerable<BasketItemDto> Items { get; set; } = null!;
}