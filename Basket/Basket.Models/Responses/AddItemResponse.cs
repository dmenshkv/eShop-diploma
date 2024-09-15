using System.Diagnostics.CodeAnalysis;

namespace Basket.Models.Responses;

[ExcludeFromCodeCoverage]
public class AddItemResponse
{
    public bool IsItemAdded { get; set; }
}