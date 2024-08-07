using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.Responses;

[ExcludeFromCodeCoverage]
public class RemoveItemResponse
{
    public bool IsRemoved { get; set; }
}