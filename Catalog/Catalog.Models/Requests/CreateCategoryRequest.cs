using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.Requests;

[ExcludeFromCodeCoverage]
public class CreateCategoryRequest
{
    public string Name { get; set; } = null!;
}