using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.DTOs
{
    [ExcludeFromCodeCoverage]
    public class MechanicDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
    }
}