namespace Basket.DataAccess.Entities.Common;

[ExcludeFromCodeCoverage]
public class CustomerBasket
{
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
}