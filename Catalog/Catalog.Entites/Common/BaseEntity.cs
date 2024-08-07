using System.Diagnostics.CodeAnalysis;

namespace Catalog.Entites.Common;

[ExcludeFromCodeCoverage]
public class BaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}