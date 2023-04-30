using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class BoardGameViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureUrl { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public int AvailableStock { get; set; }

        public BrandViewModel Brand { get; set; } = null!;

        public ICollection<CategoryViewModel> Categories { get; set; } = null!;

        public ICollection<MechanicViewModel> Mechanics { get; set; } = null!;
    }
}