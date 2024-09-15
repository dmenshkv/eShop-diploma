using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.Requests;

[ExcludeFromCodeCoverage]
public class CreateMechanicRequest
{
    public string Name { get; set; } = null!;
}