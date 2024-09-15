using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Requests.Catalog;

[ExcludeFromCodeCoverage]
public class CreateBrandRequest
{
    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;
}