namespace Basket.DataAccess.Entities.Common;

[ExcludeFromCodeCoverage]
public class BasketItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string PictureUrl { get; set; } = null!;

    public int Quantity { get; set; }
}