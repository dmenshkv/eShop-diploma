using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Requests;

[ExcludeFromCodeCoverage]
public class UpdateItemRequest<TItem>
    where TItem : class
{
    public TItem Item { get; set; } = null!;
}