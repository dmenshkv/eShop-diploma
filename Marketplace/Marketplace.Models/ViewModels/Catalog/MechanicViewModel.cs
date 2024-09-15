using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.ViewModels.Catalog;

[ExcludeFromCodeCoverage]
public class MechanicViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}