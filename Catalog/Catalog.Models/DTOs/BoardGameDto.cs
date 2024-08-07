using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.DTOs;

[ExcludeFromCodeCoverage]
public class BoardGameDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string PictureUrl { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int AvailableStock { get; set; }

    public BrandDto Brand { get; set; } = null!;

    public ICollection<CategoryDto> Categories { get; set; } = null!;

    public ICollection<MechanicDto> Mechanics { get; set; } = null!;
}