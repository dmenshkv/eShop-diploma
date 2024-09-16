namespace Marketplace.UI.Core.Models.Responses.Catalog;

[ExcludeFromCodeCoverage]
public class GetItemsResponse<TItem>
{
    public int Count { get; set; }

    public IEnumerable<TItem> Value { get; set; } = null!;
}