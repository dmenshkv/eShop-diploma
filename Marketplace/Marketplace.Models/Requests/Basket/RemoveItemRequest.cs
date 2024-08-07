using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Requests.Basket;

[ExcludeFromCodeCoverage]
public class RemoveItemRequest
{
    public Guid Id { get; set; }

    public Guid ItemId { get; set; }
}