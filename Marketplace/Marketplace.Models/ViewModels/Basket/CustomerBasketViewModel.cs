namespace Marketplace.Models.ViewModels.Basket
{
    public class CustomerBasketViewModel
    {
        public IEnumerable<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.Price * x.Quantity), 2);
        }
    }
}