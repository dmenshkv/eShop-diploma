using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Responses;

[ExcludeFromCodeCoverage]
public class GetItemsResponse<TItem>
{
    public int Count { get; set; }

    public IEnumerable<TItem> Value { get; set; } = null!;
}