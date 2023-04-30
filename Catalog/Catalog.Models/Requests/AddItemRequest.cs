using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.Requests
{
    [ExcludeFromCodeCoverage]
    public class AddItemRequest<TItem>
        where TItem : class
    {
        public TItem Item { get; init; } = null!;
    }
}