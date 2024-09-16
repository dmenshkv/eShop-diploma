namespace Catalog.DataAccess.Entities.Common;

[ExcludeFromCodeCoverage]
public class Mechanic : BaseEntity
{
    public virtual ICollection<BoardGame>? BoardGames { get; set; }
}