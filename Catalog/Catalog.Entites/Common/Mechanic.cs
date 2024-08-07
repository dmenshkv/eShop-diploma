using System.Diagnostics.CodeAnalysis;

namespace Catalog.Entites.Common;

[ExcludeFromCodeCoverage]
public class Mechanic : BaseEntity
{
    public virtual ICollection<BoardGame>? BoardGames { get; set; }
}