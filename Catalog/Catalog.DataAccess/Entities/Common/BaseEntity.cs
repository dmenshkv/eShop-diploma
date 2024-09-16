namespace Catalog.DataAccess.Entities.Common;

[ExcludeFromCodeCoverage]
public class BaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}