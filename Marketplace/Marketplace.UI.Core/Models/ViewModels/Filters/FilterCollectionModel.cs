using Marketplace.UI.Core.Models.Enums;

namespace Marketplace.UI.Core.Models.ViewModels.Filters;

[ExcludeFromCodeCoverage]
public class FilterCollectionModel
{
    public FilterTypeEnum FilterTypeEnum { get; set; }

    public bool IsCollection { get; set; }
}