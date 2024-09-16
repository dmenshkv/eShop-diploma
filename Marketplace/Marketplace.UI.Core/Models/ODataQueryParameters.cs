using Marketplace.UI.Core.Models.ViewModels.Filters;

namespace Marketplace.UI.Core.Models;

[ExcludeFromCodeCoverage]
public class ODataQueryParameters
{
    public int? Skip { get; set; }

    public int? Top { get; set; }

    public Dictionary<FilterCollectionModel, List<string>>? Filters { get; set; }

    public string? OrderBy { get; set; }
}