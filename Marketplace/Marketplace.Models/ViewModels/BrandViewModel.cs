using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.ViewModels;

[ExcludeFromCodeCoverage]
public class BrandViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;
}