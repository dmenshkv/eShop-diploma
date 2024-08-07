using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.Configurations;

[ExcludeFromCodeCoverage]
public class CatalogConfig
{
    public string ImageUrl { get; set; } = null!;
}