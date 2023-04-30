using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models
{
    [ExcludeFromCodeCoverage]
    public class ODataQueryParameters
    {
        public int? Skip { get; set; }

        public int? Top { get; set; }

        public Dictionary<FilterCollectionModel, List<string>>? Filters { get; set; }

        public string? OrderBy { get; set; }
    }
}