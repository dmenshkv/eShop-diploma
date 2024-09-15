using Basket.Models.DTOs;
using System.Diagnostics.CodeAnalysis;

namespace Basket.Models.Requests;

[ExcludeFromCodeCoverage]
public class AddItemRequest
{
    public Guid CustomerId { get; set; }

    public BasketItemDto Item { get; set; } = null!;
}