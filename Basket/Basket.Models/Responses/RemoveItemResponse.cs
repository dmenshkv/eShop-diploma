using System.Diagnostics.CodeAnalysis;

namespace Basket.Models.Responses;

[ExcludeFromCodeCoverage]
public class RemoveItemResponse
{
    public bool IsRemoved { get; set; }
}