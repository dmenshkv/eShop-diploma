using System.Diagnostics.CodeAnalysis;
using Marketplace.Models.ViewModels.Basket;

namespace Marketplace.Models.Requests.Basket;

[ExcludeFromCodeCoverage]
public class AddToBasketRequest
{
    public Guid Id { get; set; }

    public BasketItemViewModel Item { get; set; } = null!;
}