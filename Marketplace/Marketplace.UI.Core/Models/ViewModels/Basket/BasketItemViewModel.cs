namespace Marketplace.UI.Core.Models.ViewModels.Basket;

public class BasketItemViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string PictureUrl { get; set; } = null!;

    public int Quantity { get; set; }
}