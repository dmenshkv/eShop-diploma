using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Requests.Catalog;

[ExcludeFromCodeCoverage]
public class CreateBoardGameRequest
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string PictureFileName { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int AvailableStock { get; set; }

    public Guid BrandId { get; set; }

    public ICollection<Guid> CategoryIds { get; set; } = null!;

    public ICollection<Guid> MechanicIds { get; set; } = null!;
}