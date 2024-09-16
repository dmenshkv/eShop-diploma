using Marketplace.UI.Core.Models.ViewModels.Basket;

namespace Marketplace.UI.Core.Models.Requests.Basket;

[ExcludeFromCodeCoverage]
public class AddItemRequest
{
    public Guid CustomerId { get; set; }

    public BasketItemViewModel Item { get; set; } = null!;
}