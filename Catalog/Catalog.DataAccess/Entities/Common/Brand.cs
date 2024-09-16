namespace Catalog.DataAccess.Entities.Common;

[ExcludeFromCodeCoverage]
public class Brand : BaseEntity
{
    public string Country { get; set; } = null!;

    public virtual ICollection<BoardGame>? BoardGames { get; set; }
}