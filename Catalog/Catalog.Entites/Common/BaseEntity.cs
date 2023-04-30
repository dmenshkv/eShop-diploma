using System.Diagnostics.CodeAnalysis;

namespace Catalog.Entites.Common
{
    [ExcludeFromCodeCoverage]
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
    }
}