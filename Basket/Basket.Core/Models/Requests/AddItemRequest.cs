using Basket.Core.Models.DTOs;

namespace Basket.Core.Models.Requests;

[ExcludeFromCodeCoverage]
public class AddItemRequest
{
    public Guid CustomerId { get; set; }

    public BasketItemDto Item { get; set; } = null!;
}