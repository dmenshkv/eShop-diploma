using System.Diagnostics.CodeAnalysis;
using Marketplace.Models.ViewModels.Basket;

namespace Marketplace.Models.Responses.Basket;

[ExcludeFromCodeCoverage]
public class GetBasketResponse
{
    public IEnumerable<BasketItemViewModel> Items { get; set; } = null!;
}