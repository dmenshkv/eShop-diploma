using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Requests.Catalog;

[ExcludeFromCodeCoverage]
public class CreateMechanicRequest
{
    public string Name { get; set; } = null!;
}