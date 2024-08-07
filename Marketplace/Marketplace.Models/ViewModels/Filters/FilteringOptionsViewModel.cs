using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.ViewModels.Filters;

[ExcludeFromCodeCoverage]
public class FilteringOptionsViewModel
{
    public List<string> Brands { get; set; } = null!;

    public List<string> SortingCategories { get; set; } = null!;

    public List<string> Categories { get; set; } = null!;

    public List<string> Mechanics { get; set; } = null!;
}