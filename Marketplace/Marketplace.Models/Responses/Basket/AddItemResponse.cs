using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Responses.Basket;

[ExcludeFromCodeCoverage]
public class AddItemResponse
{
    public bool IsItemAdded { get; set; }
}