using System.Diagnostics.CodeAnalysis;

namespace Basket.Models.Requests;

[ExcludeFromCodeCoverage]
public class UpdateQuantityRequest
{
    public Guid Id { get; set; }

    public Dictionary<Guid, int> Quantities { get; set; } = null!;
}