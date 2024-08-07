using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Responses;

[ExcludeFromCodeCoverage]
public class RemoveItemResponse
{
    public bool IsRemoved { get; set; }
}