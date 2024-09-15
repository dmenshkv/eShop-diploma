using Marketplace.Models.ViewModels.Basket;

namespace Marketplace.Models.Requests.Basket;

public class UpdateBasketRequest
{
    public Guid CustomerId { get; set; }

    public CustomerBasketViewModel CustomerBasket { get; set; } = null!;
}