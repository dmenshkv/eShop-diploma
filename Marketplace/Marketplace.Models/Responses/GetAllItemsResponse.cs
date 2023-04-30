using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Responses
{
    [ExcludeFromCodeCoverage]
    public class GetAllItemsResponse<TItem>
    {
        public IEnumerable<TItem> Value { get; set; } = null!;
    }
}