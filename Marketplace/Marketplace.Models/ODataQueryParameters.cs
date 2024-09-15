using System.Diagnostics.CodeAnalysis;
using Marketplace.Models.ViewModels.Filters;

namespace Marketplace.Models;

[ExcludeFromCodeCoverage]
public class ODataQueryParameters
{
    public int? Skip { get; set; }

    public int? Top { get; set; }

    public Dictionary<FilterCollectionModel, List<string>>? Filters { get; set; }

    public string? OrderBy { get; set; }
}