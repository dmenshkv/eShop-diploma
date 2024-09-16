using Marketplace.UI.Core.Models.ViewModels.Basket;

namespace Marketplace.UI.Core.Models.Requests.Basket;

public class UpdateBasketRequest
{
    public Guid CustomerId { get; set; }

    public CustomerBasketViewModel CustomerBasket { get; set; } = null!;
}