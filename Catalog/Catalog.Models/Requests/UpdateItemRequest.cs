using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.Requests;

[ExcludeFromCodeCoverage]
public class UpdateItemRequest<TItem>
    where TItem : class
{
    public TItem Item { get; init; } = null!;
}