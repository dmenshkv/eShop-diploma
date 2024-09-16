namespace Catalog.Core.Models.DTOs;

[ExcludeFromCodeCoverage]
public class BrandDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;
}