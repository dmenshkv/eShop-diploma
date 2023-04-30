using System.Diagnostics.CodeAnalysis;

namespace Basket.Entites.Common
{
    [ExcludeFromCodeCoverage]
    public class CustomerBasket
    {
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}