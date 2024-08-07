using System.Diagnostics.CodeAnalysis;

namespace Basket.Models.DTOs;

[ExcludeFromCodeCoverage]
public class BasketItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string PictureUrl { get; set; } = null!;

    public int Quantity { get; set; }
}