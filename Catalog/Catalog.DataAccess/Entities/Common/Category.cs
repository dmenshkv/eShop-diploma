namespace Catalog.DataAccess.Entities.Common;

[ExcludeFromCodeCoverage]
public class Category : BaseEntity
{
    public virtual ICollection<BoardGame>? BoardGames { get; set; }
}