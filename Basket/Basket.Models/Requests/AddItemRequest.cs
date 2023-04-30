using System.Diagnostics.CodeAnalysis;
using Basket.Models.DTOs;

namespace Basket.Models.Requests
{
    [ExcludeFromCodeCoverage]
    public class AddItemRequest
    {
        public Guid Id { get; set; }

        public BasketItemDto Item { get; set; } = null!;
    }
}