namespace Marketplace.Models.ViewModels.Basket;

public class CustomerBasketViewModel
{
    public IList<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();

    public decimal CalculateTotal()
    {
        return Math.Round(Items.Sum(x => x.Price * x.Quantity), 2);
    }
}