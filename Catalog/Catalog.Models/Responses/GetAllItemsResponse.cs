using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.Responses;

[ExcludeFromCodeCoverage]
public class GetAllItemsResponse<T>
{
    public IEnumerable<T> Value { get; set; } = null!;
}