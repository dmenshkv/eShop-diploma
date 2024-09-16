using Basket.Core.Models.DTOs;

namespace Basket.Core.Models.Requests;

public class UpdateBasketRequest
{
    public Guid CustomerId { get; set; }

    public CustomerBasketDto CustomerBasket { get; set; } = null!;
}