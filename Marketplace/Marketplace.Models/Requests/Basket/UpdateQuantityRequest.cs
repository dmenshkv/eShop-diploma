using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Requests.Basket
{
    [ExcludeFromCodeCoverage]
    public class UpdateQuantityRequest
    {
        public Guid Id { get; set; }

        public Dictionary<Guid, int> Quantities { get; set; } = null!;
    }
}