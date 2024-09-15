using Basket.Models.DTOs;

namespace Basket.Models.Requests;

public class UpdateBasketRequest
{
    public Guid CustomerId { get; set; }

    public CustomerBasketDto CustomerBasket { get; set; } = null!;
}