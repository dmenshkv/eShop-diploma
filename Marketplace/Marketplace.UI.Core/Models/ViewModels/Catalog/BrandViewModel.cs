namespace Marketplace.UI.Core.Models.ViewModels.Catalog;

[ExcludeFromCodeCoverage]
public class BrandViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;
}