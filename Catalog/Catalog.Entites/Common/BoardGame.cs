using System.Diagnostics.CodeAnalysis;

namespace Catalog.Entites.Common
{
    [ExcludeFromCodeCoverage]
    public class BoardGame : BaseEntity
    {
        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureFileName { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public int AvailableStock { get; set; }

        public Guid BrandId { get; set; }

        public virtual Brand? Brand { get; set; }

        public virtual ICollection<Category>? Categories { get; set; }

        public virtual ICollection<Mechanic>? Mechanics { get; set; }
    }
}