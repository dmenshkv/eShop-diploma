using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Requests.Catalog;

[ExcludeFromCodeCoverage]
public class CreateCategoryRequest
{
    public string Name { get; set; } = null!;
}