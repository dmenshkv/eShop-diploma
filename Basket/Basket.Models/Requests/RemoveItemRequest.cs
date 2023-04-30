using System.Diagnostics.CodeAnalysis;

namespace Basket.Models.Requests
{
    [ExcludeFromCodeCoverage]
    public class RemoveItemRequest
    {
        public string Id { get; set; } = null!;

        public Guid ItemId { get; set; }
    }
}