namespace Catalog.Core.Models.Responses;

[ExcludeFromCodeCoverage]
public class GetItemsResponse<TModel>
{
    public int Count { get; set; }

    public IEnumerable<TModel> Value { get; set; } = null!;
}