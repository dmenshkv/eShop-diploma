using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.DTOs
{
    [ExcludeFromCodeCoverage]
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
    }
}