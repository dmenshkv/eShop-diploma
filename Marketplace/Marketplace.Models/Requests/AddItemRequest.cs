using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Requests
{
    [ExcludeFromCodeCoverage]
    public class AddItemRequest<TItem>
        where TItem : class
    {
        public TItem Item { get; set; } = null!;
    }
}